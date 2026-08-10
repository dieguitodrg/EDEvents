using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDCrew
{
    public enum PromptType
    {
        None = -1,
        Event = 0,
        Message = 1,
        Command = 2,
        Inventory = 3,
        Navigation = 4,
        Combat = 5,
        MissionAccepted = 6,
        MissionCompleted = 7,
        MissionFailed = 8,
        Merits = 9,

        InterestellarFactor = 1000,
        MaterialTrader = 1001,
        Help = 1002,
        InventoryPanel = 1004,
        BodySignals = 1005,


        ExoMastery = 1006,
        Conflictos = 1007,
        Ordenes = 1008,


        Statistics = 1010,
        ColonisationList = 1011,
        ColonisationProgress = 1012,

        Exceptions = 2000,

        Types = 3000
    }

    /// <summary>
    /// Estado del copiloto que el prompter necesita para ensamblar la pantalla
    /// lógica. Form1 lo implementa; los tests podrán usar dobles.
    /// </summary>
    public interface IPrompterHost
    {
        bool OverlaysEnabled { get; }

        string ShipName { get; }

        string Commander { get; }

        string Ship { get; }

        JournalPowerplayMerits JournalPowerMerits { get; }

        JournalPowerplayRank JournalPowerRank { get; }

        Counters Counters { get; }

        string FaccionObjetivo { get; }

        string StarSystem { get; }

        Dictionary<string, JournalMissionAccepted> MissionAccepted { get; }

        JournalStatistics JournalStatistics { get; }

        List<ExoMastery> ExoMasteryRoute { get; }

        List<StationListItem> ConflictosUUCC { get; }

        List<Order> OrdenesUUCC { get; }

        List<StationListItem> FactoresInterestelar { get; }

        List<StationListItem> Comerciantes { get; }

        List<JournalFSSBodySignals> BodySignals { get; }

        CategoriasInventario CategoriasInventario { get; }

        Int64 SystemAddress { get; }

        JournalShipTargeted EventMarked { get; }

        IDictionaryStore DictionaryStore { get; }
    }

    /// <summary>
    /// Una línea de texto con su estilo y posición, ya preparada para pintar.
    /// Es el único dato que cruza la frontera del renderer (que no conoce
    /// Form1, Log, Cursores ni WhatTo).
    /// </summary>
    public class PromptLine
    {
        public string Text { get; }

        public byte R { get; }

        public byte G { get; }

        public byte B { get; }

        public int X { get; }

        public int Y { get; }

        public PromptLine(string text, byte r, byte g, byte b, int x, int y)
        {
            Text = text ?? "";
            R = r;
            G = g;
            B = b;
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            PromptLine other = obj as PromptLine;
            if (other == null) return false;
            return Text == other.Text && R == other.R && G == other.G && B == other.B && X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + (Text != null ? Text.GetHashCode() : 0);
                hash = hash * 31 + R.GetHashCode();
                hash = hash * 31 + G.GetHashCode();
                hash = hash * 31 + B.GetHashCode();
                hash = hash * 31 + X.GetHashCode();
                hash = hash * 31 + Y.GetHashCode();
                return hash;
            }
        }
    }

    /// <summary>
    /// Contrato del renderer de overlay. El exterior no sabe nada de Direct3D
    /// ni de Capture; solo intercambia PromptLine.
    /// </summary>
    public interface IOverlayRenderer
    {
        bool IsReady { get; }

        void Draw(IReadOnlyList<PromptLine> lines);

        void DrawPanel(IReadOnlyList<PromptLine> lines, int cursorRow);

        void Clear();
    }

    /// <summary>
    /// Pantalla lógica del overlay: mantiene el Log por sección, los cursores,
    /// la sección activa (WhatTo) y el timer de refresco (cada 2 s). Compara el
    /// contenido ensamblado antes de reenviarlo al renderer (dirty-check) para
    /// no disparar IPC/rebuild del overlay cuando nada cambió.
    /// Reemplaza Log/Cursores/WhatTo/tDisplay/SetDisplay de Form1.
    /// </summary>
    public class PrompterService
    {
        /// <summary>
        /// Paneles navegables (con cursor): se pintan con el estilo panel de
        /// juego (fondo, borde, fila resaltada). El resto sigue como texto.
        /// </summary>
        public static readonly HashSet<PromptType> NavigablePanels = new HashSet<PromptType>
        {
            PromptType.InterestellarFactor,
            PromptType.MaterialTrader,
            PromptType.ExoMastery,
            PromptType.Conflictos,
            PromptType.Ordenes,
            PromptType.BodySignals
        };

        private readonly IPrompterHost _host;
        private readonly PrompterContent _content;
        private readonly IOverlayRenderer _renderer;

        private readonly Dictionary<PromptType, List<string>> _log = new Dictionary<PromptType, List<string>>();
        private readonly Dictionary<PromptType, int> _cursores = new Dictionary<PromptType, int>();
        private readonly object _logLock = new object();

        private PromptType _whatTo = PromptType.Command;
        private System.Timers.Timer _timer;
        private IReadOnlyList<PromptLine> _lastLines;
        private bool _cleared;

        public PrompterService(IPrompterHost host, PrompterContent content, IOverlayRenderer renderer)
        {
            _host = host;
            _content = content;
            _renderer = renderer;
            Initialize();
        }

        public PromptType WhatTo
        {
            get { return _whatTo; }
            set { _whatTo = value; }
        }

        void Initialize()
        {
            foreach (PromptType type in Enum.GetValues(typeof(PromptType)))
            {
                _log[type] = new List<string>();
                _cursores[type] = 0;
            }
        }

        public void Start()
        {
            Stop();
            _timer = new System.Timers.Timer(2000);
            _timer.Elapsed += TDisplay_Elapsed;
            _timer.Enabled = true;
        }

        public void Stop()
        {
            if (_timer != null)
            {
                _timer.Enabled = false;
                _timer.Elapsed -= TDisplay_Elapsed;
                _timer.Dispose();
                _timer = null;
            }
        }

        public void AddPrompt(string s, PromptType prompttype)
        {
            lock (_logLock)
            {
                if (!_log.TryGetValue(prompttype, out List<string> list))
                {
                    list = new List<string>();
                    _log[prompttype] = list;
                }
                list.Add(s);
            }
        }

        public void SetHelp(IReadOnlyList<string> choices)
        {
            lock (_logLock)
            {
                _log[PromptType.Help] = choices != null ? choices.ToList() : new List<string>();
            }
        }

        public IReadOnlyList<string> GetLog(PromptType t)
        {
            lock (_logLock)
            {
                return _log.TryGetValue(t, out List<string> list) ? (IReadOnlyList<string>)list.ToList() : (IReadOnlyList<string>)new List<string>();
            }
        }

        public int GetCursor(PromptType t)
        {
            return _cursores.TryGetValue(t, out int v) ? v : 0;
        }

        public void SetCursor(PromptType t, int opcion)
        {
            if (opcion <= 0) opcion = 0;
            if (opcion >= 38) opcion = 37;
            _cursores[t] = opcion;
        }

        public void SiguienteOpcion()
        {
            int v = GetCursor(WhatTo) + 1;
            if (v >= 38) v = 37;
            _cursores[WhatTo] = v;
        }

        public void AnteriorOpcion()
        {
            int v = GetCursor(WhatTo) - 1;
            if (v <= 0) v = 0;
            _cursores[WhatTo] = v;
        }

        /// <summary>
        /// Fuerza un ensamblado y reenvío inmediato de la pantalla (equivale a
        /// la antigua SetDisplay de Form1).
        /// </summary>
        public void Refresh()
        {
            try
            {
                RefreshCore();
            }
            catch (Exception ex)
            {
                _lastLines = null;
            }
        }

        void TDisplay_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Refresh();
        }

        void RefreshCore()
        {
            bool overlayWanted = _host.OverlaysEnabled && _whatTo != PromptType.None;

            if (!overlayWanted)
            {
                if (!_cleared)
                {
                    _renderer.Clear();
                    _cleared = true;
                }
                _lastLines = null;
                return;
            }

            _cleared = false;

            Dictionary<PromptType, List<string>> logSnapshot;
            lock (_logLock)
            {
                logSnapshot = new Dictionary<PromptType, List<string>>();
                foreach (KeyValuePair<PromptType, List<string>> kv in _log)
                    logSnapshot[kv.Key] = kv.Value.ToList();
            }

            List<PromptLine> lines = _content.Build(_host, logSnapshot, GetCursor(_whatTo), _whatTo);

            if (_renderer.IsReady && _lastLines != null && lines.SequenceEqual(_lastLines))
            {
                return;
            }

            _lastLines = lines;

            if (NavigablePanels.Contains(_whatTo))
                _renderer.DrawPanel(lines, GetCursor(_whatTo));
            else
                _renderer.Draw(lines);
        }

        public static string RemoveBadChars(string word)
        {
            StringBuilder sb = new StringBuilder(word.ToUpper());
            sb.Replace("Á", "A");
            sb.Replace("À", "A");
            sb.Replace("Ä", "A");
            sb.Replace("É", "E");
            sb.Replace("È", "E");
            sb.Replace("Ë", "E");
            sb.Replace("Í", "I");
            sb.Replace("Ì", "I");
            sb.Replace("Ï", "I");
            sb.Replace("Ó", "O");
            sb.Replace("Ò", "O");
            sb.Replace("Ö", "O");
            sb.Replace("Ú", "U");
            sb.Replace("Ù", "U");
            sb.Replace("Ü", "U");
            sb.Replace("Ñ", "N");
            sb.Replace("¡", "");
            sb.Replace("¿", "");

            for (int i = 0; i < sb.Length; i++)
                if (sb[i] > 127) sb[i] = '*';

            return sb.ToString();
        }
    }
}
