using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using static System.Windows.Forms.LinkLabel;

using System.Linq;

using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Text;
using System.Net;

using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CsQuery.Implementation;
using System.Net.Http;
//using System.Speech.Synthesis;
using System.Net.NetworkInformation;
using CsQuery.StringScanner;
using Windows.UI.Xaml.Controls;
using CsQuery.Utility;
using static System.Net.Mime.MediaTypeNames;
using System.Numerics;
using Image = System.Drawing.Image;
using Windows.UI.StartScreen;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Xml.Linq;
using System.Runtime.InteropServices.ComTypes;
using DirectOutputCSharpWrapper;
using CsQuery.Engine.PseudoClassSelectors;
using Windows.Data.Pdf;
using Windows.System.Threading;

using System.Globalization;
using EDCrew.Properties;
using System.Net.Http.Headers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

using EDCrew.Speech;
//using LuminaController;

//using Windows.Web.Http;

namespace EDCrew
{


    public partial class Form1 : Form, IWebServerHost, Pipeline.ICopilotOutput, Pipeline.ICopilotState, Pipeline.IJournalReaderHost, IPrompterHost
    {

        readonly Pipeline.JournalEventDispatcher _journalDispatcher = new Pipeline.JournalEventDispatcher();

        readonly Pipeline.JournalReaderService _journalReader;

        readonly PrompterService _prompter;

        readonly Pipeline.EventCSharpService _eventCSharpService = new Pipeline.EventCSharpService();

        public List<Commodity> MasterCommodities;

        public Dictionary<decimal, JournalColonisationConstructionDepot> ColonisationProgress { get; set; } = new Dictionary<decimal, JournalColonisationConstructionDepot>();

        public Counters counters = new Counters();

        DateTime LastCombatTime = DateTime.Now;
        DateTime CombatTime = DateTime.Now;
        DateTime LastKill = DateTime.Now;
        //Bitmap bitmap = (Bitmap) Image.FromFile("e:\\dolphin.bmp");
        //Bitmap bitmap = (Bitmap) Image.FromFile("e:\\dolphin.bmp");

        //Dictionary<int, String> Filas = new Dictionary<int, string>();

        JournalPowerplayMerits JournalPowerMerits;
        JournalPowerplayRank JournalPowerRank;

        Dictionary<String, JournalMissionAccepted> MissionAccepted = new Dictionary<String, JournalMissionAccepted>();

        Dictionary<String, int> FactionVictims = new Dictionary<string, int>();
        Dictionary<String, int> ShipVictims = new Dictionary<string, int>();

        //        Dictionary<PageTypeMFD, List<String>> LogMFD = new Dictionary<PageTypeMFD, List<string>>();
        //        Dictionary<PageTypeMFD, String> TitlesMFD = new Dictionary<PageTypeMFD, string>();

        DateTime LastEvent;

        HttpServer httpServer;

        public Status Status { get; set; }

        public string bountyprompt { get; set; }

        public Status OldStatus { get; set; }
        public String Commander
        {
            get { return commander; }
            set
            {

                if (commander != value)
                {
                    commander = value;
                    /*                    info1 = commander;

                                        DisplayPage();*/
                }




            }
        }

        public String Ship
        {
            get { return ship; }
            set
            {
                /*
                if (ship != value)
                {
                    ship = value;

                    info1 = ShipIdent + " " + ShipName;

                    DisplayPage();


                }*/

            }
        }

        public String ShipName
        {
            get { return shipName; }
            set
            {

                if (shipName != value)
                {
                    shipName = value;

                    //                    LogMFD[PageTypeMFD.None].RemoveRange(0, 1);
                    //                    LogMFD[PageTypeMFD.None].Insert(0, ShipIdent + " " + ShipName);

                    DisplayPage();
                }

            }
        }

        public String ShipIdent
        {
            get { return shipIdent; }
            set
            {


                if (shipIdent != value)
                {
                    shipIdent = value;

                    //                    LogMFD[PageTypeMFD.None].RemoveRange(0, 1);
                    //                    LogMFD[PageTypeMFD.None].Insert(0, ShipIdent + " " + ShipName);

                    DisplayPage();
                }


            }
        }
        private String destination;
        public String Destination
        {
            get
            {
                return destination;
            }
            set
            {
                if (destination != value)
                {
                    destination = value;
                    //                    LogMFD[PageTypeMFD.None].RemoveRange(1, 1);
                    //                    LogMFD[PageTypeMFD.None].Insert(1, MFDLocation);
                    DisplayPage();

                }
            }
        }

        public int ShipId { get; private set; }
        public CategoriasInventario CategoriasInventario { get; set; }

        readonly Led.LedJsonWriter _ledWriter;

        public List<StationListItem> Comerciantes { get; set; }
        public List<StationListItem> FactoresInterestelar { get; set; }
        public List<StationListItem> ConflictosUUCC;
        public List<Order> OrdenesUUCC;

        private readonly InaraService _inara = new InaraService();

        readonly ArduinoService _arduino = new ArduinoService();
        ManualResetEvent _completed = null;
        readonly IVoiceRecognition _voice;
        readonly ISpeechSynthesizer _tts = new SpeechSynthesizer();
        readonly IDictionaryStore _dictionaryStore = new DictionaryStore();

        int lastcommandpos = 0;

        public string StarSystem
        {
            get { return starSystem; }
            set
            {


                if (starSystem != value)
                {
                    starSystem = value;

                    //                    LogMFD[PageTypeMFD.None].RemoveRange(1, 1);
                    //                    LogMFD[PageTypeMFD.None].Insert(1, MFDLocation);


                    DisplayPage();

                }


            }
        }

        public string MFDLocation
        {
            get
            {
                String result = "";
                if (StarSystem != null)
                {
                    result += StarSystem;
                }

                if (StationName != null && StationName != "")
                {
                    if (result.Length > 0) result += $"-{StationName}";
                }

                if (Destination != null && Destination != "")
                {
                    if (result.Length > 0) result += $">{Destination}";

                }

                return result;

            }
        }

        public string StationName {

            get { return stationName; }
            set
            {


                if (stationName != value)
                {
                    stationName = value;

                    //LogMFD[PageTypeMFD.None].RemoveRange(1, 1);
                    //LogMFD[PageTypeMFD.None].Insert(1, MFDLocation);

                    DisplayPage();

                }


            } }

        bool oldSupercruise = false;
        bool oldLanded = false;
        bool oldDocked = false;
        bool oldFSDMasslocked = false;
        bool oldFSDCooldown = false;
        bool oldLandingGearDown = false;

        string FaccionObjetivo = "";

        Int64 SystemAddress;
        Int64 oldSystemAdress = 0;

        List<JournalFSSBodySignals> BodySignals;

        List<ExoMastery> ExoMasteryRoute;

        Dictionary<String, bool> Scanned;

        public Form1()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            this.FormClosed += Form1_FormClosed;
            _prompter = new PrompterService(this, new PrompterContent(), new D3DOverlayRenderer());
            _ledWriter = new Led.LedJsonWriter(System.Configuration.ConfigurationManager.AppSettings["LEDFolder"])
            {
                Enabled = cbLED.Checked
            };
            _journalDispatcher.Register(new Pipeline.Handlers.LoadGameHandler(this, this));
            _journalDispatcher.Register(new Pipeline.Handlers.PowerplayCollectHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.CollectCargoHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.EjectCargoHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.DockingGrantedHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.StartJumpHandler(this, _ledWriter));
            _journalDispatcher.Register(new Pipeline.Handlers.PowerplayRankHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.PowerplayMeritsHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.SquadronStartupHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.StatisticsHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.LocationHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.DockedHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.UndockedHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.FSDJumpHandler(this, _ledWriter));
            _journalDispatcher.Register(new Pipeline.Handlers.MaterialsHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.MaterialCollectedHandler(this, this));
            _journalDispatcher.Register(new Pipeline.Handlers.EngineerCraftHandler(this, this));
            _journalDispatcher.Register(new Pipeline.Handlers.MaterialTradeHandler(this, this));
            _journalDispatcher.Register(new Pipeline.Handlers.MissionAcceptedHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.MissionCompletedHandler(this, this));
            _journalDispatcher.Register(new Pipeline.Handlers.MissionAbandonedHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.ColonisationConstructionDepotHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.FSSBodySignalsHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.ShipTargetedHandler(this, this));
            _journalDispatcher.Register(new Pipeline.Handlers.LoadoutHandler(this, this));
            _journalDispatcher.Register(new Pipeline.Handlers.ReceiveTextHandler(this, this));
            _journalDispatcher.Register(new Pipeline.Handlers.FactionKillBondHandler(this, this));
            _journalDispatcher.Register(new Pipeline.Handlers.BountyHandler(this, this));
            _journalDispatcher.Register(new Pipeline.Handlers.ScanOrganicHandler(this));
            _prompter.Start();


            try
            {

                List<String> voices = _tts.GetAvailableVoices();

                foreach (var voice in voices)
                {

                    comboBox1.Items.Add(voice);
                    comboBox2.Items.Add(voice);
                    comboBox3.Items.Add(voice);
                }

                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;

                _tts.Start();



            }
            catch (Exception ex)
            {

            }

            BodySignals = new List<JournalFSSBodySignals>();

            //SetDisplay();

            foreach (String s in _arduino.GetPortNames())
            {
                cbArduinoCOM.Items.Add(s);
            }

            _arduino.DataReceived += Arduino_DataReceived;
            _voice = new VoiceRecognitionService();
            _voice.CommandRecognized += VoiceRecognition_CommandRecognized;
            _voice.Start();

            _prompter.SetHelp(_voice.Choices.ToList());

            /*
                        MasterCommodities = JsonConvert.DeserializeObject<List<Commodity>>(System.IO.File.ReadAllText(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\mercancias.json"));

                        _listencommodities = new SpeechRecognitionEngine(CultureInfo.GetCultureInfo("es-ES"));
                        _listencommodities.SetInputToDefaultAudioDevice();

                        Choices commoditychoices = new Choices();

                        List<GrammarBuilder> gbcommodities = new List<GrammarBuilder>();

                        foreach(Commodity mc in MasterCommodities)
                        {
                            gbcommodities.Add(new SemanticResultValue("Comprar " + mc.name, "1|" + mc.value));
                            gbcommodities.Add(new SemanticResultValue("Vender " + mc.name, "2|" + mc.value));
                        }
                        commoditychoices.Add(gbcommodities.ToArray());

                        GrammarBuilder grammarBuilderComodities = new GrammarBuilder();
                        grammarBuilderComodities.Culture = CultureInfo.GetCultureInfo("es-ES");

                        grammarBuilderComodities.Append("Cotizaciones para ");

                        grammarBuilderComodities.Append(commoditychoices);

                        Grammar gcommodities = new Grammar(grammarBuilderComodities);

                        _listencommodities.LoadGrammar(gcommodities);
                        _listencommodities.RequestRecognizerUpdate();


                        _listencommodities.RecognizeAsync(RecognizeMode.Multiple);

                        // Add a handler for the speech recognized event.  
                        _listencommodities.SpeechRecognized +=
                                  new EventHandler<SpeechRecognizedEventArgs>(recognizerCommodities_SpeechRecognized);
                        */

            //_completed.WaitOne(); // wait until speech recognition is completed
            //_listen.Dispose(); // dispose the speech recognition engine

            // Configure input to the speech recognizer.  


            // Start asynchronous, continuous speech recognition.  
            //_listen.RecognizeAsync(RecognizeMode.Multiple);

            /*
            
            httpServer.Start();
            */

            httpServer = new HttpServer();
            httpServer.host = this;
            httpServer.inara = _inara;

            String pathWithEnv = "%USERPROFILE%\\Saved Games\\Frontier Developments\\Elite Dangerous";
            String filePath = Environment.ExpandEnvironmentVariables(pathWithEnv);

            _journalReader = new Pipeline.JournalReaderService(this, _journalDispatcher, filePath);

            CategoriasInventario = new CategoriasInventario();

            CategoriasInventario.Inventario = new Inventario();

            CategoriasInventario.CargarCategorias();

            _journalReader.Start();
        }

        void Form1_Load(object sender, EventArgs e)
        {
            MissionAccepted = _dictionaryStore.Add<JournalMissionAccepted>("MissionAccepted", "0", new JournalMissionAccepted());
            MissionAccepted = _dictionaryStore.Remove<JournalMissionAccepted>("MissionAccepted", "0");


        }

        void Form1_FormClosed(object sender, EventArgs e)
        {
            try { _prompter.Dispose(); } catch (Exception) { }

            try { _journalReader.Stop(); } catch (Exception) { }

            try { if (httpServer != null) httpServer.Stop(); } catch (Exception) { }

            try { _tts.Dispose(); } catch (Exception) { }

            try { _voice.Dispose(); } catch (Exception) { }

            try { _arduino.Dispose(); } catch (Exception) { }

            Environment.Exit(0);
        }

        void Arduino_DataReceived(object sender, EventArgs e)
        {
            Console.WriteLine(e.ToString());
        }

        bool IPrompterHost.OverlaysEnabled
        {
            get { return cbOverlays.Checked; }
        }

        string IPrompterHost.ShipName
        {
            get { return ShipName; }
        }

        string IPrompterHost.Commander
        {
            get { return Commander; }
        }

        string IPrompterHost.Ship
        {
            get { return Ship; }
        }

        JournalPowerplayMerits IPrompterHost.JournalPowerMerits
        {
            get { return JournalPowerMerits; }
        }

        JournalPowerplayRank IPrompterHost.JournalPowerRank
        {
            get { return JournalPowerRank; }
        }

        Counters IPrompterHost.Counters
        {
            get { return counters; }
        }

        string IPrompterHost.FaccionObjetivo
        {
            get { return FaccionObjetivo; }
        }

        string IPrompterHost.StarSystem
        {
            get { return StarSystem; }
        }

        Dictionary<string, JournalMissionAccepted> IPrompterHost.MissionAccepted
        {
            get { return MissionAccepted; }
        }

        JournalStatistics IPrompterHost.JournalStatistics
        {
            get { return JournalStatistics; }
        }

        List<ExoMastery> IPrompterHost.ExoMasteryRoute
        {
            get { return ExoMasteryRoute; }
        }

        List<StationListItem> IPrompterHost.ConflictosUUCC
        {
            get { return ConflictosUUCC; }
        }

        List<Order> IPrompterHost.OrdenesUUCC
        {
            get { return OrdenesUUCC; }
        }

        List<StationListItem> IPrompterHost.FactoresInterestelar
        {
            get { return FactoresInterestelar; }
        }

        List<StationListItem> IPrompterHost.Comerciantes
        {
            get { return Comerciantes; }
        }

        List<JournalFSSBodySignals> IPrompterHost.BodySignals
        {
            get { return BodySignals; }
        }

        CategoriasInventario IPrompterHost.CategoriasInventario
        {
            get { return CategoriasInventario; }
        }

        Int64 IPrompterHost.SystemAddress
        {
            get { return SystemAddress; }
        }

        JournalShipTargeted IPrompterHost.EventMarked
        {
            get { return EventMarked; }
        }

        IDictionaryStore IPrompterHost.DictionaryStore
        {
            get { return _dictionaryStore; }
        }

        void Pipeline.ICopilotOutput.AddPrompt(string text, PromptType promptType)
        {
            _prompter.AddPrompt(text, promptType);
        }

        void Pipeline.ICopilotOutput.Speak(string text, bool npc)
        {
            Speak(text, npc);
        }

        Counters Pipeline.ICopilotState.Counters
        {
            get { return counters; }
        }

        Int64 Pipeline.ICopilotState.SystemAddress
        {
            get { return SystemAddress; }
            set { SystemAddress = value; }
        }

        JournalPowerplayRank Pipeline.ICopilotState.JournalPowerRank
        {
            get { return JournalPowerRank; }
            set { JournalPowerRank = value; }
        }

        JournalPowerplayMerits Pipeline.ICopilotState.JournalPowerMerits
        {
            get { return JournalPowerMerits; }
            set { JournalPowerMerits = value; }
        }

        JournalStatistics Pipeline.ICopilotState.JournalStatistics
        {
            get { return JournalStatistics; }
            set { JournalStatistics = value; }
        }

        Dictionary<string, JournalMissionAccepted> Pipeline.ICopilotState.MissionAccepted
        {
            get { return MissionAccepted; }
        }

        void Pipeline.ICopilotState.AddMissionAccepted(string key, JournalMissionAccepted mission)
        {
            MissionAccepted = _dictionaryStore.Add<JournalMissionAccepted>("MissionAccepted", key, mission);
        }

        void Pipeline.ICopilotState.RemoveMissionAccepted(string key)
        {
            if (MissionAccepted.ContainsKey(key))
            {
                _dictionaryStore.Remove<JournalMissionAccepted>("MissionAccepted", key);
            }
        }

        void Pipeline.ICopilotOutput.DisplayPage()
        {
            DisplayPage();
        }

        void Pipeline.ICopilotOutput.EjecutarComando(string command, bool voice)
        {
            EjecutarComando(command, voice);
        }

        string Pipeline.ICopilotOutput.Nato(string text)
        {
            return NATO(text);
        }

        void Pipeline.IJournalReaderHost.Acknowledge(string text)
        {
            Acknowledge(text);
        }

        Int64 Pipeline.ICopilotState.OldSystemAddress
        {
            get { return oldSystemAdress; }
            set { oldSystemAdress = value; }
        }

        List<JournalFSSBodySignals> Pipeline.ICopilotState.BodySignals
        {
            get { return BodySignals; }
        }

        JournalShipTargeted Pipeline.ICopilotState.EventScannedShip
        {
            get { return EventScannedShip; }
            set { EventScannedShip = value; }
        }

        JournalShipTargeted Pipeline.ICopilotState.EventMarked
        {
            get { return EventMarked; }
            set { EventMarked = value; }
        }

        string Pipeline.ICopilotState.Promptmfd
        {
            get { return promptmfd; }
            set { promptmfd = value; }
        }

        string Pipeline.ICopilotState.Bountyprompt
        {
            get { return bountyprompt; }
            set { bountyprompt = value; }
        }

        DateTime Pipeline.ICopilotState.LastKill
        {
            get { return LastKill; }
            set { LastKill = value; }
        }

        Dictionary<string, int> Pipeline.ICopilotState.FactionVictims
        {
            get { return FactionVictims; }
        }

        string Pipeline.ICopilotState.FaccionObjetivo
        {
            get { return FaccionObjetivo; }
            set { FaccionObjetivo = value; }
        }

        bool Pipeline.ICopilotState.SpeakNpc
        {
            get { return cbNPC.Checked; }
        }

        bool Pipeline.ICopilotState.SpeakSystem
        {
            get { return cbsystemmessages.Checked; }
        }

        bool Pipeline.ICopilotState.FetchingSubsystem
        {
            get { return Fetchingsubsystem; }
            set { Fetchingsubsystem = value; }
        }

        string Pipeline.ICopilotState.Subsystem
        {
            get { return subsystem; }
            set { subsystem = value; }
        }

        int Pipeline.ICopilotState.ShipId
        {
            get { return ShipId; }
            set { ShipId = value; }
        }

        void Pipeline.ICopilotState.AddScanned(string key, bool value)
        {
            Scanned = _dictionaryStore.Add<bool>("Scanned", key, value);
        }

        void Pipeline.ICopilotState.AddDictionaryScanned(string systemAddress, string body, string speciesLocalised, bool analysed)
        {
            _dictionaryStore.AddScanned2(Commander, systemAddress, body, speciesLocalised, analysed);
        }

        // Handle the CommandRecognized event.
        void VoiceRecognition_CommandRecognized(Comandos comando)
        {
            EjecutarComando(comando, true);
        }
        /*
        void recognizerCommodities_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            Console.WriteLine(e.Result.Semantics.Value);

        }
        */
        public void EjecutarComandoWeb(String text)
        {
            EjecutarComando(text, false);
        }


        public void EjecutarComando(String text, bool voice = true)
        {
            Comandos comando = (from Comandos c in _voice.Commands where c.command == text select c).DefaultIfEmpty(null).FirstOrDefault();
            if (comando != null)
            {
                EjecutarComando(comando, voice);
            }
            else
            {
                comando = (from Comandos c in _voice.Commands where c.code == text select c).DefaultIfEmpty(null).FirstOrDefault();
                if (comando != null)
                {
                    EjecutarComando(comando, voice);
                }
            }
        }
        public async void EjecutarComando(Comandos comando, bool voice = true)
        {
            if (voice && !cbCommands.Checked) return;

            bool prompt = true;

            switch (comando.command)
            {
                case "Información Recompensa": { Speak(bountyprompt != null ? bountyprompt : "", false); break; }
                case "Mostrar Eventos": { _prompter.WhatTo = PromptType.Event; break; }
                case "Mostrar Mensajes": { _prompter.WhatTo = PromptType.Message; break; }
                case "Mostrar Comandos": { _prompter.WhatTo = PromptType.Command; break; }
                case "Mostrar Inventario": { _prompter.WhatTo = PromptType.Inventory; break; }
                case "Mostrar Navegación": { _prompter.WhatTo = PromptType.Navigation; break; }
                case "Mostrar Combate": { _prompter.WhatTo = PromptType.Combat; break; }
                case "Mostrar Excepciones": { _prompter.WhatTo = PromptType.Exceptions; break; }
                case "Mostrar Tipos": { _prompter.WhatTo = PromptType.Types; break; }
                case "Mostrar Méritos": { _prompter.WhatTo = PromptType.Merits; break; }
                case "Empezar Nuevo Combate":
                    {
                        LastCombatTime = CombatTime;
                        CombatTime = DateTime.Now;
                        TimeSpan ts = CombatTime - LastCombatTime;
                        String m1 = $"Nave: {ShipName} Resultado:  {ts.ToString()}, {counters.Combat} derribos";
                        _prompter.AddPrompt(m1, PromptType.Combat);
                        counters.Combat = 0;
                        _prompter.AddPrompt("--- Nuevo Combate ---", PromptType.Combat);
                        break;
                    }
                case "Resetear Contadores": { _prompter.AddPrompt("--- Resetear Contadores ---", PromptType.Combat); counters.Total = 0; counters.Merits = 0;  break; }
                case "Mostrar Misiones": { _prompter.WhatTo = PromptType.MissionAccepted; break; }
                case "Mostrar Misiones Completadas": { _prompter.WhatTo = PromptType.MissionCompleted; break; }
                case "Mostrar Misiones Fallidas": { _prompter.WhatTo = PromptType.MissionFailed; break; }

                case "Mostrar Factor Interestelar":
                    {
                        FactoresInterestelar = await _inara.FactorInterestelar(StarSystem);
                        _prompter.WhatTo = PromptType.InterestellarFactor;
                        break;
                    }
                case "Mostrar Comerciante materiales":
                    {
                        Comerciantes = await _inara.MaterialTrader(StarSystem);
                        _prompter.WhatTo = PromptType.MaterialTrader;
                        break;
                    }
                case "Mostrar Conflictos":
                    {
                        ConflictosUUCC = await _inara.Conflictos();
                        _prompter.WhatTo = PromptType.Conflictos;
                        break;

                    }

                case "Mostrar Materiales Minerales": { _prompter.WhatTo = PromptType.InventoryRaw; break; }
                case "Mostrar Materiales Datos": { _prompter.WhatTo = PromptType.InventoryEncoded; break; }
                case "Mostrar Materiales Fabricados": { _prompter.WhatTo = PromptType.InventoryManufactured; break; }
                case "Mostrar Progreso de Colonización": { _prompter.WhatTo = PromptType.ColonisationProgress; break; }
                case "Mostrar Colonización": { _prompter.WhatTo = PromptType.ColonisationProgress; break; }

                case "Mostrar Señales de Planetas": { _prompter.WhatTo = PromptType.BodySignals; break; }

                case "Mostar Ruta Exobiología":
                    {
                        _prompter.WhatTo = PromptType.ExoMastery;
                        LoadExoMastery();
                        break;
                    }

                case "Mostrar Ayuda": { _prompter.WhatTo = PromptType.Help; break; }
                case "Mostrar estadísticas": { _prompter.WhatTo = PromptType.Statistics; break; }
                case "Ocultar Información": { _prompter.WhatTo = PromptType.None; break; }
                case "Marcar Contacto": { EventMarked = EventScannedShip; break; }
                case "Marcar facción objetivo": {

                        FaccionObjetivo = EventScannedShip.Faction;
                        txtFaccion.Text = FaccionObjetivo;

                        Speak($"Nueva facción objetivo {FaccionObjetivo}");
                        break;
                    }
                /*
                case "Apuntar núcleo de energía":
                    {
                        Fetchingsubsystem = true;
                        subsystem = comando.subsystem;

                        EjecutarComando("Anterior Subsistema", voice);

                        break;
                    }
                case "Apuntar a motores":
                    {
                        Fetchingsubsystem = true;
                        subsystem = comando.subsystem;

                        EjecutarComando("Anterior Subsistema", voice);

                        break;
                    }
                */

                default:
                    {
                        if (comando.method != null) Invoke(comando.method, comando.subsystem);
                        prompt = false; break;
                    }
            }

            if (prompt)
            {
                //SetDisplay();
                return;
            }

            _prompter.AddPrompt(comando.command, PromptType.Command);

            if (comando.conditionsource != null)
            {
                if (this[comando.conditionsource].ToLower() != comando.conditionvalue.ToLower()) return;
            }

            if (!cbConfiguracion.Checked && comando.precommands != null)
            {
                foreach (String s in comando.precommands)
                {
                    EjecutarComando(s, voice);
                }
            }


            if (comando.control != null)
            {
                _arduino.SendCommand(comando.control.ToArray());
            }

            if (!cbConfiguracion.Checked && comando.postcommands != null)
            {
                foreach (String s in comando.postcommands)
                {
                    EjecutarComando(s, voice);
                }
            }


        }
        private async void MostrarOrdenes()
        {
            OrdenesUUCC = await _inara.Ordenes();
            _prompter.WhatTo = PromptType.Ordenes;
        }
        private void Apuntar(String sistema)
        {
            Fetchingsubsystem = true;
            subsystem = sistema;

            EjecutarComando("Anterior Subsistema", false);
        }

        private void MostrarOferta(string mercancia)
        {
            Speak($"Buscando oferta de {mercancia} desde {StarSystem}");
            _inara.MostrarMercado("Sol", true, "5");
        }


        private void MostrarDemanda(string mercancia)
        {
            Speak($"Buscando demanda de {mercancia} desde {StarSystem}");
        }


        private void FindPowerPlant()
        {
            do
            {
                EjecutarComando("Anterior Subsistema", false);
                System.Threading.Thread.Sleep(1000);
            } while (Fetchingsubsystem);
        }

        private void cbArduinoCOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenPort();

        }

        private void cbEnabled_CheckedChanged(object sender, EventArgs e)
        {
            OpenPort();
        }

        void OpenPort()
        {
            try
            {
                _arduino.Close();

                if (cbEnabled.Checked && cbArduinoCOM.Text != "")
                {
                    _arduino.Open(cbArduinoCOM.Text);
                }

            }
            catch (Exception ex)
            {

            }
        }



        private void cbWS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbWS.Checked)
            {
                httpServer.Start();
            }
            else
            {
                httpServer.Stop();
            }
        }

        private void cbCommands_CheckedChanged(object sender, EventArgs e)
        {
        }

        public string defaultbody
        {
            get
            {
                return "";
            }
        }

        public string mensajesbody
        {
            get
            {

                StringBuilder sb = new StringBuilder($"<h1 class='go-text'>Mensajes</h1>");


                sb.Append("<ul class='go-text'>");

                foreach (String s in _prompter.GetLog(PromptType.Message))
                {
                    string ss = PrompterService.RemoveBadChars(s);
                    sb.Append($"<li>{ss}</li>");

                }
                sb.Append("</ul>");

                return sb.ToString();
            }
        }

        public string combatebody
        {
            get
            {

                StringBuilder sb = new StringBuilder($"<h1 class='go-almond'>Diario de Combate</h1>");


                sb.Append("<ul class='go-almond'>");

                foreach (String s in _prompter.GetLog(PromptType.Combat))
                {
                    string ss = PrompterService.RemoveBadChars(s);
                    sb.Append($"<li>{ss}</li>");


                }
                sb.Append("</ul>");

                return sb.ToString();
            }
        }

        public string factorinterestelarbody
        {
            get
            {

                StringBuilder sb = new StringBuilder($"<h1 class='go-orange'>Factor interestelar - {StarSystem}</h1>");
                if (FactoresInterestelar != null)
                {


                    sb.Append("<table>");
                    sb.Append("<tr class='go-orange'>");
                    sb.Append($"<td>Sistema</td><td>Distancia</td><td>Estaci&oacute;n</td><td>Distancia</td>");
                    sb.Append("</tr>");
                    int j = 0;
                    foreach (StationListItem c in FactoresInterestelar.Take(FactoresInterestelar.Count() > 38 ? 38 : FactoresInterestelar.Count()))
                    {

                        if (j == _prompter.GetCursor(PromptType.InterestellarFactor))
                        {
                            sb.Append("<tr class='go-orange'>");
                        }
                        else
                        {
                            sb.Append("<tr class='go-text'>");
                        }
                        sb.Append($"<td>{c.Sistema}</td><td>{c.DistanciaSistema}</td><td>{c.Estacion}</td><td>{c.DistanciaEstrella}</td>");
                        sb.Append("</tr>");
                        j++;
                    }
                    sb.Append("</table>");
                }
                return sb.ToString();
            }
        }


        public string inventariobody
        {
            get
            {

                StringBuilder sb = new StringBuilder($"<h1 class='go-violet'>Inventario</h1>");



                sb.Append("<table class='go-violet'>");



                int it = 0;
                String level = "";
                foreach (List<List<String>> tipo in this.CategoriasInventario.Categorias)
                {
                    String cabecera = "";
                    level = "";
                    switch (it)
                    {
                        case 0:
                            { cabecera = "Materia Prima"; break; }
                        case 1:
                            { cabecera = "Manufacturados"; break; }
                        case 2:
                            { cabecera = "Codificados"; break; }

                    }
                    sb.Append($"<tr><td colspan='5'>{cabecera}</td></tr>");
                    //sb.Append("<tr><td>Material</td><td>Cantidad</td></tr>");


                    foreach (List<String> categoria in tipo)
                    {

                        sb.Append("<tr>");
                        foreach (String elemento in categoria)
                        {

                            if (elemento != String.Empty)
                            {

                                sb.Append($"<td>{elemento}<br />{this.CategoriasInventario.Cantidad(elemento)}/{this.CategoriasInventario.Maximo(elemento)}</td>");

                            }
                        }
                        sb.Append("</tr>");
                    }

                    it++;

                }

                sb.Append("</table>");

                return sb.ToString();
            }
        }

        public string comerciantesbody
        {
            get
            {

                StringBuilder sb = new StringBuilder($"<h1 class='go-violet'>Inventario - {StarSystem}</h1>");
                if (Comerciantes != null)
                {


                    sb.Append("<table class='go-violet'>");
                    sb.Append("<tr>");
                    sb.Append($"<td>Tipo</td><td>Sistema</td><td>Distancia</td><td>Estaci&oacute;n</td><td>Distancia</td>");
                    sb.Append("</tr>");
                    int i = 0;
                    foreach (StationListItem c in Comerciantes.Take(Comerciantes.Count() > 38 ? 38 : Comerciantes.Count()))
                    {
                        sb.Append("<tr>");
                        sb.Append($"<td>{c.Tipo.Substring(0, 3)}</td><td><a href='docommand?command=irasistemacomerciantes&argument={i}'>{c.Sistema}</a></td><td>{c.DistanciaSistema}</td><td><a href='docommand?command=irabasecomerciantes&argument={i}'>{c.Estacion}</a></td><td>{c.DistanciaEstrella}</td>");
                        sb.Append("</tr>");
                        i++;
                    }
                    sb.Append("</table>");
                }
                return sb.ToString();
            }
        }

        public string GetWebString(string value)
        {


            StringBuilder sb = new StringBuilder(value);

            foreach (String s in GetSubStrings(value, "${", "}"))
            {

                sb.Replace("${" + s + "}", this[s]);
            }

            return (sb.ToString());
        }


        private System.IntPtr device;
        private Guid deviceguid;
        private Guid devicetypeguid;
        DirectOutputCSharpWrapper.DirectOutput directoutput;

        PageTypeMFD infopage = PageTypeMFD.None;
        public void DisplayPage()
        {
            if (cbMFDx52.Checked)
            {
                /*DeInitializeDisplay();
                InitializeDisplay();*/

                ControlSaitek.Info info = new ControlSaitek.Info()
                {
                    ClutchColor = "Orange",
                    FireAColor = "Orange",
                    FireBColor = "Orange",
                    FireButtonIllumination = false,
                    FireDColor = "Orange",
                    FireEColor = "Orange",
                    Lines = new List<List<string>>(),
                    POV2Color = "Orange",
                    ThrottleAxisIllumination = true,
                    Toggle12Color = "Orange",
                    Toggle34Color = "Orange",
                    Toggle56Color = "Orange"
                };



                int first = 0;
                int last = 0;
                int count = 0;

                //Distintas páginas

                info.Lines.Add(new List<string>());
                info.Lines[info.Lines.Count - 1].Add("  Logitech x52  ");
                info.Lines[info.Lines.Count - 1].Add("  ------------  ");
                info.Lines[info.Lines.Count - 1].Add(" EliteDangerous ");


                //0 Status

                info.Lines.Add(new List<string>());

                info.Lines[info.Lines.Count - 1].Add($"CMDT {this.Commander.ToSafeString()} {this.ShipIdent.ToSafeString()} {this.ShipName.ToSafeString()}".ToUpper());
                //info.Lines[info.Lines.Count - 1].Add($"{this.JournalStatistics.Bank_Account.Current_Wealth}");
                info.Lines[info.Lines.Count - 1].Add($"{MFDLocation.ToSafeString()}".ToUpper());

                //1 Pips
                info.Lines.Add(new List<string>());

                if (Status != null)
                {


                    if (Status.Pips != null)
                    {
                        String sDisplay = "";

                        switch (Status.PipsSIS)
                        {
                            case 0: { sDisplay = "[    ]"; break; }
                            case 1: { sDisplay = "[-   ]"; break; }
                            case 2: { sDisplay = "[=   ]"; break; }
                            case 3: { sDisplay = "[=-  ]"; break; }
                            case 4: { sDisplay = "[==  ]"; break; }
                            case 5: { sDisplay = "[==- ]"; break; }
                            case 6: { sDisplay = "[=== ]"; break; }
                            case 7: { sDisplay = "[===-]"; break; }
                            case 8: { sDisplay = "[====]"; break; }

                        }


                        info.Lines[info.Lines.Count - 1].Add($"SIS: {sDisplay}");

                        
                        switch (Status.PipsENG)
                        {
                            case 0: { sDisplay = "[    ]"; break; }
                            case 1: { sDisplay = "[-   ]"; break; }
                            case 2: { sDisplay = "[=   ]"; break; }
                            case 3: { sDisplay = "[=-  ]"; break; }
                            case 4: { sDisplay = "[==  ]"; break; }
                            case 5: { sDisplay = "[==- ]"; break; }
                            case 6: { sDisplay = "[=== ]"; break; }
                            case 7: { sDisplay = "[===-]"; break; }
                            case 8: { sDisplay = "[====]"; break; }

                        }

                        

                        info.Lines[info.Lines.Count - 1].Add($"MOT: {sDisplay}");

                        
                        switch (Status.PipsWEP)
                        {
                            case 0: { sDisplay = "[    ]"; break; }
                            case 1: { sDisplay = "[-   ]"; break; }
                            case 2: { sDisplay = "[=   ]"; break; }
                            case 3: { sDisplay = "[=-  ]"; break; }
                            case 4: { sDisplay = "[==  ]"; break; }
                            case 5: { sDisplay = "[==- ]"; break; }
                            case 6: { sDisplay = "[=== ]"; break; }
                            case 7: { sDisplay = "[===-]"; break; }
                            case 8: { sDisplay = "[====]"; break; }

                        }
                        
                        info.Lines[info.Lines.Count - 1].Add($"ARM: {sDisplay.ToSafeString()}");
                    }
                    else
                    {
                        info.Lines[info.Lines.Count - 1].Add("SIS: ");
                        info.Lines[info.Lines.Count - 1].Add("MOT: ");
                        info.Lines[info.Lines.Count - 1].Add("ARM: ");
                    }










                }
                else
                {

                    info.Lines[info.Lines.Count - 1].Add("SIS: ");
                    info.Lines[info.Lines.Count - 1].Add("MOT: ");
                    info.Lines[info.Lines.Count - 1].Add("ARM: ");

                    info.FireButtonIllumination = false;
                }

                //Bloqueos

                info.Lines.Add(new List<string>());

                if (Status != null)
                {
                    string sDisplay = "";

                    sDisplay = " ";

                    sDisplay = Status.FSDMassLocked ? "=" : " ";

                    info.Lines[info.Lines.Count - 1].Add($"BLOQUEO MASA [{sDisplay}]");

                    sDisplay = " ";
                    sDisplay = Status.LandingGearDown ? "=" : " ";


                    info.Lines[info.Lines.Count - 1].Add($"TREN ATERRIZ [{sDisplay}]");

                    sDisplay = " ";
                    
                    sDisplay = Status.CargoScoopDeployed ? "=" : " ";
                    

                    info.Lines[info.Lines.Count - 1].Add($"COLECT CARGA [{sDisplay}]");
                }
                else
                {
                    info.Lines.Add(new List<string>());

                    info.Lines[info.Lines.Count - 1].Add("BLOQUEO MASA [-]");
                    info.Lines[info.Lines.Count - 1].Add("TREN ATERRIZ [-]");
                    info.Lines[info.Lines.Count - 1].Add("COLECT CARGA [-]");


                }

                //Combate - Contadores
                info.Lines.Add(new List<string>());

                info.Lines[info.Lines.Count - 1].Add($"CONT: {counters.Combat} {counters.Faction} {counters.Total}".ToUpper());
                info.Lines[info.Lines.Count - 1].Add($"FACC: {FaccionObjetivo}".ToUpper());
                info.Lines[info.Lines.Count - 1].Add($"{promptmfd}".ToUpper());

                //Combate - Facciones
                info.Lines.Add(new List<string>());

                int nlineas = 0;

                foreach (String NombreFaccion in FactionVictims.Keys.OrderByDescending(x => FactionVictims[x]))
                {
                    nlineas++;
                    //if (nlineas <= 3)
                    info.Lines[info.Lines.Count - 1].Add($"{NombreFaccion}: {FactionVictims[NombreFaccion]}".ToUpper());
                }
                for (int i = nlineas + 1; i <= 3; i++)
                {
                    info.Lines[info.Lines.Count - 1].Add("");
                }

                info.Lines.Add(new List<string>());

                info.Lines[info.Lines.Count - 1].Add(EventScannedShip != null ? (EventScannedShip.PilotName_Localised != null ? EventScannedShip.PilotName_Localised.ToUpper() : EventScannedShip.PilotName.Replace(";", "").Replace("$npc_name_decorate:#name=", "").ToUpper()) : "");
                info.Lines[info.Lines.Count - 1].Add(EventScannedShip != null ? EventScannedShip.LegalStatus.ToUpper() : "  SIN CONTACTO  ");
                info.Lines[info.Lines.Count - 1].Add(EventScannedShip != null ? EventScannedShip.PilotRank.ToUpper() + " " + EventScannedShip.Bounty : "");

                //Inventario
                info.Lines.Add(new List<string>());

                int it = 0;
                String level = "";
                foreach (List<List<String>> tipo in this.CategoriasInventario.Categorias)
                {
                    String cabecera = "";
                    level = "";
                    switch (it)
                    {
                        case 0:
                            { cabecera = "Materia Prima"; break; }
                        case 1:
                            { cabecera = "Manufacturados"; break; }
                        case 2:
                            { cabecera = "Codificados"; break; }

                    }

                    info.Lines[info.Lines.Count - 1].Add($"Inventario: {cabecera}".ToUpper());

                    foreach (List<String> categoria in tipo)
                    {

                        foreach (String elemento in categoria)
                        {
                            if (elemento != String.Empty)
                            {
                                info.Lines[info.Lines.Count - 1].Add($"{elemento}: {this.CategoriasInventario.Cantidad(elemento)}/{this.CategoriasInventario.Maximo(elemento)}".ToUpper());                                
                            }
                        }
                    }
                    it++;
                }

                //Combate - Naves
                /*
                info.Lines.Add(new List<string>());

                nlineas = 0;

                foreach (String NombreNave in ShipVictims.Keys.OrderBy(x => x))
                {
                    nlineas++;
                    if (nlineas <= 3)
                        info.Lines[info.Lines.Count - 1].Add($"{NombreNave}: {ShipVictims[NombreNave]}".ToUpper());
                }
                for (int i = nlineas + 1; i <= 3; i++)
                {
                    info.Lines[info.Lines.Count - 1].Add("");
                }
                */
                //Leds

                if (Status != null)
                {
                    if (!Status.Landed && !Status.Docked)
                    {
                        info.FireAColor = Status.FSDMassLocked || Status.FSDCoolDown ? "Red" : "Green";
                        info.ClutchColor = Status.SuperCruise ? "Green" : "Red";
                        info.ThrottleAxisIllumination = true;
                        info.FireEColor = Status.ScoopingFuel ? "Red" : "Green";
                        info.FireDColor = "Green";
                        info.POV2Color = Status.HardPointsDeployed ? "Red" : "Orange";
                    }



                    info.FireButtonIllumination = Status.HardPointsDeployed;
                    info.Toggle56Color = Status.IsLegal ? "Green" : "Red";
                    info.FireBColor = Status.LightsOn ? "Green" : "Black";
                }

                if (StatusScanned)
                {
                    info.Toggle12Color = EventScannedShip != null && EventScannedShip.Bounty > 0 ? "Red" : "Orange";
                    info.Toggle34Color = EventScannedShip != null && EventScannedShip.Faction == FaccionObjetivo ? "Red" :
                                         EventScannedShip != null && EventScannedShip.Faction == Squadron.SquadronName ? "Green" : "Orange";
                }

                // X56 RGB: naranja en modo combate, cyan en modo análisis (escaneo)
                if (Status != null && Status.HUDInAnalisysMode)
                {
                    info.JoystickColor = new ControlSaitek.Info.RGBColor(0, 255, 255);
                    info.ThrottleColor = new ControlSaitek.Info.RGBColor(0, 255, 255);
                }
                else
                {
                    info.JoystickColor = new ControlSaitek.Info.RGBColor(255, 165, 0);
                    info.ThrottleColor = new ControlSaitek.Info.RGBColor(255, 165, 0);
                }

                String filename = "i:\\elitedangerousstatus.json";

                //System.IO.File.WriteAllText(filename, Newtonsoft.Json.JsonConvert.SerializeObject(info, Formatting.Indented));


                ControlSaitek.Info oldinfo = null;

                if (System.IO.File.Exists(filename))
                {
                    oldinfo = Newtonsoft.Json.JsonConvert.DeserializeObject<ControlSaitek.Info>(System.IO.File.ReadAllText(filename));
                }

                if (!info.Equals(oldinfo))
                {

                    try
                    {

                        System.IO.File.WriteAllText(filename, Newtonsoft.Json.JsonConvert.SerializeObject(info, Formatting.Indented));

                        if (Process.GetProcessesByName("ControlSaitek").Count() == 0)
                        {

                            Process p = new Process();
                            p.StartInfo = new ProcessStartInfo()
                            {
                                Arguments = filename,
                                FileName = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Saitek\\ControlSaitek.exe",
                                UseShellExecute = true,
                                CreateNoWindow = false,

                            };
                            p.Start();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }

        }

        //private List<System.Threading.Timer> tdisplay;
        //private List<int> marqueepos;

        /*
                private void DisplayPage(int pageno)
                {
                    int pagecapacity = 3;
                    //tdisplay = new List<System.Threading.Timer>();

                    if (pages != null && pages.Count >= pageno)
                    {
                        int i = 0;
                        directoutput.AddPage(device, pageno, 1);
                        foreach (String s in pages[pageno])
                        {
                            //tdisplay.Add(null);

                            if (i < pages[pageno].Count && i < pagecapacity)
                            {
                                string toshow = RemoveBadChars(s);

                                //var autoEvent = new AutoResetEvent(false);

                                //MarqueeChecker marqueechecker = new MarqueeChecker(16, s, pageno, i, directoutput, device);

                                //tdisplay[i] = new System.Threading.Timer(marqueechecker.Display, autoEvent, 1000, 250);
                                directoutput.SetString(device, pageno, i, toshow);
                                // directoutput.SetLed(device, pageno, 17, 1);
                                // directoutput.SetLed(device, pageno, 18, 0);
                                // directoutput.SetLed(device, pageno, 7, 1);
                                // directoutput.SetLed(device, pageno, 8, 0);
                            }
                            i++;
                        }
                    }
                }
        */


        private void button1_Click(object sender, EventArgs e)
        {
            /*
            String json = System.IO.File.ReadAllText("c:\\temp\\evento.json");

            object o = EDCrew.Reader.ReadJson(json);
            */


            /*
            OAuth2 auth = OAuth2.Load();

            if (auth == null || !auth.Refresh())
            {
                var req = OAuth2.Authorize();
                Console.WriteLine(req.AuthURL);
                auth = req.GetAuth();
            }

            auth.Save();
            var capi = new CAPI(auth);
            var profile = capi.GetProfile();
            System.Diagnostics.Trace.WriteLine(profile.ToString(Newtonsoft.Json.Formatting.Indented));
            */
            starSystem = "Sol";
            MostrarOferta("5");
            return;
            /*
            Speak("Mensaje muy largo para poder hacer pruebas", true);
            Speak("Otro mensaje", false);
            Speak("Otro 1 mensaje", false);
            Speak("Otro 2 mensaje", false);
            */


            //cmbDevices.SelectedIndex = 2

            //i.Open()

            return;

            /*
            foreach(Comandos c in comandos)
            {
                c.code = String.Join("", (from string s in c.command.Split(' ') select Form1.RemoveBadChars(s.Substring(0, s.Length > 4 ? 4 : s.Length))));
            }

            System.IO.File.WriteAllText(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Gramatica.json", JsonConvert.SerializeObject(comandos));
            */
            /*
            this.Comerciantes = await MaterialTrader("JAROUA");

            return;
            */

            Scanned = _dictionaryStore.Load<bool>("Scanned");

            Dictionary<String, Dictionary<String, bool>> Scanned2 = new Dictionary<String, Dictionary<string, bool>>();

            foreach (String key in Scanned.Keys)
            {
                String[] arraykey = key.Split('_');

                //String scankey = $"{journal.SystemAddress}_{journal.Body}_{journal.Species_Localised}";

                String systemaddress = arraykey[0];
                String body = arraykey[1];
                String specieslocalized = arraykey[2];

                if (!Scanned2.ContainsKey(systemaddress))
                {
                    Scanned2.Add(systemaddress, new Dictionary<string, bool>());
                }

                String skey2 = $"{body}_{specieslocalized}";
                Scanned2[systemaddress].Add(skey2, Scanned[key]);



            }

            String filename = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"\\DictionaryScanned.{Commander}.json";
            System.IO.File.WriteAllText(filename, JsonConvert.SerializeObject(Scanned2));



        }

        public bool StatusScanned { get; set; }
        public string promptmfd { get; set; }
        public JournalSquadronStartup Squadron { get; set; }
        public bool SaveEvents { get; set; }
        public int ContadorCombate { get => counters.Combat; set { counters.Combat = value; nContadorCombate.Value = counters.Combat; } }

        private JournalShipTargeted EventScannedShip;
        private JournalShipTargeted EventMarked;
        private bool TargetFound;
        private bool Fetchingsubsystem;
        private string subsystem;
        private JournalStatistics JournalStatistics;
        private string commander;
        private string ship;
        private string shipName;
        private string shipIdent;
        private string starSystem;
        private string stationName;

        public void Invoke(String method)
        {
            Invoke(method, null);
        }

        public void Invoke(String method, string argument)
        {
            string[] p = null;

            if (argument != null) p = new string[] { argument };


            GetType().GetMethod(method, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Invoke(this, p);
        }


        public string this[string propertyName]
        {
            get
            {
                try
                {

                    String[] path = propertyName.Split(new String[] { "." }, StringSplitOptions.RemoveEmptyEntries);

                    Type myType = typeof(Form1);
                    PropertyInfo myPropInfo = myType.GetProperty(path[0]);

                    if (path.Length > 1)
                    {
                        Type myType2 = myPropInfo.PropertyType;
                        PropertyInfo myPropInfo2 = myType2.GetProperty(path[1]);

                        return myPropInfo2.GetValue(myPropInfo.GetValue(this, null), null).ToString();

                    }
                    else
                    {
                        return myPropInfo.GetValue(this, null).ToString();
                    }

                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        private IEnumerable<string> GetSubStrings(string input, string start, string end)
        {
            Regex r = new Regex(Regex.Escape(start) + "(.*?)" + Regex.Escape(end));
            MatchCollection matches = r.Matches(input);
            foreach (Match match in matches)
                yield return match.Groups[1].Value;
        }

        //https://json2csharp.com/api/Default
        public async Task<String> EventCSharp(String ClassName, String Event)
        {
            return await _eventCSharpService.EventCSharp(ClassName, Event);
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            
            timer1.Enabled = true;
        }

        private void cbVoice_CheckedChanged(object sender, EventArgs e)
        {

        }

        void Speak(string phrase, bool npc = false)
        {

            if (!cbVoice.Checked) return;

            _tts.Speak(phrase, npc);

        }

        void Acknowledge(string phrase)
        {

            _tts.Acknowledge(phrase);

        }

        string NATO(string n)
        {
            List<String> codes = n.ToUpper().Select(x => x > 64 ? x + "lfa,ravo,harlie,elta,cho,oxtrot,olf,otel,ndia,uliett,ilo,ima,ike,ovember,scar,apa,uebec,omeo,ierra,ango,niform,ictor,hiskey,ray,ankee,ulu".Split(',')[x % 65] : x + "").ToList();
            return (String.Join(" ", codes.ToArray()));
        }

        private void nContador_ValueChanged(object sender, EventArgs e)
        {
            counters.Total = (int)nContador.Value;
        }

        private void nContadorCombate_ValueChanged(object sender, EventArgs e)
        {
            counters.Combat = (int)nContadorCombate.Value;
        }

        private void MensajesNPC()
        {
            cbNPC.Checked = !cbNPC.Checked;
        }

        private void MensajesSistema()
        {
            cbsystemmessages.Checked = !cbsystemmessages.Checked;
        }

        private void AvisosVoz()
        {
            cbVoice.Checked = !cbVoice.Checked;
        }
        private void InformacionPantalla()
        {
            cbOverlays.Checked = !cbOverlays.Checked;
        }

        private void BorrarMisiones()
        {
            MissionAccepted = _dictionaryStore.Clear<JournalMissionAccepted>("MissionAccepted");
        }

        private void SiguienteOpcion()
        {
            _prompter.SiguienteOpcion();
        }

        private void AnteriorOpcion()
        {
            _prompter.AnteriorOpcion();
        }

        public void IrASistema(PromptType t, int opcion)
        {
            IraOpcion(t, opcion, true);
        }

        public void IrABase(PromptType t, int opcion)
        {
            IraOpcion(t, opcion, false);
        }

        public void IraOpcion(int opcion, bool sistema)
        {
            IraOpcion(_prompter.WhatTo, opcion, sistema);
        }

        public void IraOpcion(PromptType t, int opcion, bool sistema)
        {
            _prompter.SetCursor(t, opcion);
            SeleccionarOpcion(t, sistema);
        }

        private void SeleccionarSistema()
        {
            SeleccionarOpcion(true);
        }
        private void SeleccionarBase()
        {
            SeleccionarOpcion(false);
        }

        private void SeleccionarOpcion(PromptType t, bool sistema)
        {

            String tipo = sistema ? "Sistema" : "Facilidad";
            String text = "";
            String tospeak = "";
            try
            {
                switch (t)
                {
                    case PromptType.InterestellarFactor:
                        {
                            text = sistema ? FactoresInterestelar[_prompter.GetCursor(PromptType.InterestellarFactor)].Sistema : FactoresInterestelar[_prompter.GetCursor(PromptType.InterestellarFactor)].Estacion;
                            tospeak = $"Preparando destino Factor Interestelar: {tipo} {text} cargado en la computadora de navegación";

                            break;
                        }
                    case PromptType.MaterialTrader:
                        {
                            text = sistema ? Comerciantes[_prompter.GetCursor(PromptType.MaterialTrader)].Sistema : Comerciantes[_prompter.GetCursor(PromptType.MaterialTrader)].Estacion;
                            tospeak = $"Preparando destino Comerciante de materiales: {tipo} {text} cargado en la computadora de navegación";
                            break;
                        }
                    case PromptType.ExoMastery:
                        {
                            text = sistema ? ExoMasteryRoute.Where(x => !x.Completado).ToList()[_prompter.GetCursor(PromptType.ExoMastery)].Nombredelsistema : ExoMasteryRoute.Where(x => !x.Completado).ToList()[_prompter.GetCursor(PromptType.ExoMastery)].Nombredelcuerpo;
                            tospeak = $"Preparando destino {text}";
                            break;

                        }
                    case PromptType.Conflictos:
                        {
                            text = ConflictosUUCC[_prompter.GetCursor(PromptType.Conflictos)].Sistema;
                            tospeak = $"Preparando destino {text} en {ConflictosUUCC[_prompter.GetCursor(PromptType.Conflictos)].Tipo} entre {ConflictosUUCC[_prompter.GetCursor(PromptType.Conflictos)].DistanciaSistema} y {ConflictosUUCC[_prompter.GetCursor(PromptType.Conflictos)].DistanciaEstrella}";
                            break;

                        }
                    case PromptType.Ordenes:
                        {
                            text = OrdenesUUCC[_prompter.GetCursor(PromptType.Ordenes)].System;
                            tospeak = $"Preparando destino {text} en {OrdenesUUCC[_prompter.GetCursor(PromptType.Ordenes)].System} {OrdenesUUCC[_prompter.GetCursor(PromptType.Ordenes)].Orders}";
                            break;

                        }
                    case PromptType.ColonisationList:
                        {
                            break;
                        }
                    default: break;
                }

                if (text != "")
                {
                    Clipboard.SetText(text);
                    Speak(tospeak);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void SeleccionarOpcion(bool sistema)
        {
            SeleccionarOpcion(_prompter.WhatTo, sistema);

        }

        private void Contadores()
        {
            String messagespeak = $"Contador Total: {counters.Total}, Contador Facción {counters.Faction}, Contador Combate {counters.Combat}";

            Speak(messagespeak);
        }

        private void Meritos()
        {
            int t = JournalPowerMerits != null ? JournalPowerMerits.TotalMerits : 0;
            String messagespeak = $"Méritos parfciales: {counters.Merits} Total {t}";
            
            Speak(messagespeak);
        }


        private void MarcarCompletado()
        {
            if (ExoMasteryRoute != null && ExoMasteryRoute.Where(x => !x.Completado).Count() != 0)
            {
                ExoMasteryRoute.Where(x => !x.Completado).First().Completado = true;

                String foldername = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"\\Data";

                System.IO.Directory.CreateDirectory(foldername);

                String filename = $"{foldername}\\exobiology.{Commander}.json";

                System.IO.File.WriteAllText(filename, JsonConvert.SerializeObject(ExoMasteryRoute));

                _prompter.Refresh();


            }

        }

        private void LoadExoMastery()
        {


            ExoMasteryRoute = null;



            String foldername = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"\\Data";

            System.IO.Directory.CreateDirectory(foldername);

            String filename = $"{foldername}\\exobiology.{Commander}.json";

            if (System.IO.File.Exists(filename))
            {
                ExoMasteryRoute = JsonConvert.DeserializeObject<List<ExoMastery>>(System.IO.File.ReadAllText(filename));

            }

        }

        private void nContadorFaccion_ValueChanged(object sender, EventArgs e)
        {
            counters.Faction = (int)nContadorFaccion.Value;
        }

        private void cbMFDx52_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMFDx52.Checked)
            {
                DisplayPage();

                /*
                var autoEvent = new AutoResetEvent(false);

                MFDRefresh marqueechecker = new MFDRefresh(this);

                System.Threading.Timer t = new System.Threading.Timer(marqueechecker.Display, autoEvent, 10000, 10000);
                */

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FaccionObjetivo = txtFaccion.Text;
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _tts.Initialize(SpeechChannel.Npc, comboBox1.SelectedItem.ToString());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _tts.Initialize(SpeechChannel.Speak, comboBox2.SelectedItem.ToString());
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            _tts.Initialize(SpeechChannel.Acknowledge, comboBox3.SelectedItem.ToString());
        }
        
        private void cbCsharp_CheckedChanged(object sender, EventArgs e)
        {
            SaveEvents = cbCsharp.Checked;
        }

        private void cbLED_CheckedChanged(object sender, EventArgs e)
        {
            _ledWriter.Enabled = cbLED.Checked;
        }

    }


}

