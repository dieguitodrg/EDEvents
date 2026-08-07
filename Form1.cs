using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using static System.Windows.Forms.LinkLabel;

using System.Linq;

using System.IO.Ports;
using Capture;
using Capture.Hook;
using Capture.Interface;
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
using Windows.Devices.Bluetooth;
using Windows.Devices.Enumeration;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Storage.Streams;
using CsQuery.Implementation;
using System.Net.Http;
//using System.Speech.Synthesis;
using System.Net.NetworkInformation;
using Capture.Hook.Common;
using CsQuery.StringScanner;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using System.Security.Cryptography;
using System.Security.Policy;
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
using Windows.Security.Cryptography;
//using LuminaController;

//using Windows.Web.Http;

namespace EDCrew
{


    public partial class Form1 : Form, StringReplacer, Pipeline.ICopilotOutput, Pipeline.ICopilotState
    {

        readonly Pipeline.JournalEventDispatcher _journalDispatcher = new Pipeline.JournalEventDispatcher();

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

        Dictionary<PromptType, List<String>> Log = new Dictionary<PromptType, List<String>>();
        Dictionary<PromptType, int> Cursores = new Dictionary<PromptType, int>();

        //        Dictionary<PageTypeMFD, List<String>> LogMFD = new Dictionary<PageTypeMFD, List<string>>();
        //        Dictionary<PageTypeMFD, String> TitlesMFD = new Dictionary<PageTypeMFD, string>();
        Bitmap Bmp;

        System.Timers.Timer tDisplay = new System.Timers.Timer(2000);

        DateTime LastEvent;
        int LastEventLine = -1;

        HttpServer httpServer;

        PromptType WhatTo = PromptType.Command;

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

        public StarTypesType startypes = new StarTypesType();

        public StarTypeColor currentstarcolor = null;
        public StarTypeColor nextstarcolor = null;
        public int ShipId { get; private set; }
        public CategoriasInventario CategoriasInventario { get; set; }

        public List<StationListItem> Comerciantes;
        public List<StationListItem> FactoresInterestelar;
        public List<StationListItem> ConflictosUUCC;
        public List<Order> OrdenesUUCC;

        int altofuente = 20;
        Font font;
        //Font font = new System.Drawing.Font("Courier New", 18, FontStyle.Regular);

        SerialPort _serialPort;
        List<Comandos> comandos;
        ManualResetEvent _completed = null;
        SpeechRecognitionEngine _listen, _listencommodities;
        List<Comandos> comandosfinales = new List<Comandos>();

        int processId = 0;
        Process _process;
        CaptureProcess _captureProcess;

        int lastcommandpos = 0;
        List<String> choices;

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

        string oldDestination = "";
        bool oldSupercruise = false;
        bool oldLanded = false;
        bool oldDocked = false;
        bool oldFSDMasslocked = false;
        bool oldFSDCooldown = false;
        bool oldLandingGearDown = false;

        FileSystemWatcher fs;

        string FaccionObjetivo = "";

        Int64 SystemAddress;
        Int64 oldSystemAdress = 0;

        List<JournalFSSBodySignals> BodySignals;

        List<ExoMastery> ExoMasteryRoute;

        Dictionary<String, bool> Scanned;

        Thread _threadNPC;
        Thread _threadSpeak;
        Thread _threadAcknowledge;

        public Form1()
        {
            InitializeComponent();
            _journalDispatcher.Register(new Pipeline.Handlers.LoadGameHandler(this, this));
            _journalDispatcher.Register(new Pipeline.Handlers.PowerplayCollectHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.CollectCargoHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.EjectCargoHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.DockingGrantedHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.StartJumpHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.PowerplayRankHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.PowerplayMeritsHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.SquadronStartupHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.StatisticsHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.LocationHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.DockedHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.UndockedHandler(this));
            _journalDispatcher.Register(new Pipeline.Handlers.FSDJumpHandler(this));
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
            tDisplay.Elapsed += TDisplay_Elapsed;
            tDisplay.Enabled = true;


            try
            {

                SpeechEngine = SpeechEngineFactory.Create();


                List<String> voices = SpeechEngine.GetAvailableVoices().ToList();
                
                foreach (var voice in voices)
                {

                    comboBox1.Items.Add(voice);
                    comboBox2.Items.Add(voice);
                    comboBox3.Items.Add(voice);
                }

                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;

/*                InitializeSynthesizerNPC(combo);
                InitializeSynthesizerSpeak();
                InitializeSynthesizerAcknowledge();
*/
                _threadNPC = new Thread(NPCThread);
                _threadSpeak = new Thread(SpeakThread);
                _threadAcknowledge = new Thread(AcknowledgeThread);

                _threadNPC.Start();
                _threadSpeak.Start();
                _threadAcknowledge.Start();



            }
            catch (Exception ex)
            {

            }

            font = new System.Drawing.Font("Euro Caps", altofuente, FontStyle.Regular);

            /*
                        Bmp = new Bitmap(100, 100);
                        using (Graphics gfx = Graphics.FromImage(Bmp))
                        using (SolidBrush brush = new SolidBrush(Color.FromArgb(0xff, 0xb0, 0)))
                        {
                            gfx.FillRectangle(brush, 0, 0, 100, 100);
                        }*/

            Log.Add(PromptType.Event, new List<string>());
            Log.Add(PromptType.Message, new List<string>());
            Log.Add(PromptType.Command, new List<string>());
            Log.Add(PromptType.Inventory, new List<string>());
            Log.Add(PromptType.Navigation, new List<string>());
            Log.Add(PromptType.Combat, new List<string>());
            Log.Add(PromptType.MissionAccepted, new List<string>());
            Log.Add(PromptType.MissionCompleted, new List<string>());
            Log.Add(PromptType.MissionFailed, new List<string>());

            Log.Add(PromptType.InterestellarFactor, new List<string>());
            Log.Add(PromptType.MaterialTrader, new List<string>());
            Log.Add(PromptType.InventoryPanel, new List<string>());
            Log.Add(PromptType.Help, new List<string>());
            Log.Add(PromptType.None, new List<string>());
            Log.Add(PromptType.BodySignals, new List<string>());
            Log.Add(PromptType.Exceptions, new List<string>());
            Log.Add(PromptType.ExoMastery, new List<String>());

            Log.Add(PromptType.Statistics, new List<String>());
            Log.Add(PromptType.Types, new List<String>());

            Log.Add(PromptType.Merits, new List<String>());
            Log.Add(PromptType.ColonisationList, new List<string>());
            Log.Add(PromptType.ColonisationProgress, new List<string>());

            /*
                        LogMFD.Add(PageTypeMFD.None, new List<string>());
                        LogMFD[PageTypeMFD.None].Add("");
                        LogMFD[PageTypeMFD.None].Add("");
                        LogMFD.Add(PageTypeMFD.Combat, new List<string>());

                        TitlesMFD.Add(PageTypeMFD.None, "Estado");
                        TitlesMFD.Add(PageTypeMFD.Combat, "Combate");
            */
            Cursores.Add(PromptType.Event, 0);
            Cursores.Add(PromptType.Message, 0);
            Cursores.Add(PromptType.Command, 0);
            Cursores.Add(PromptType.Inventory, 0);
            Cursores.Add(PromptType.Navigation, 0);
            Cursores.Add(PromptType.Combat, 0);
            Cursores.Add(PromptType.MissionAccepted, 0);
            Cursores.Add(PromptType.MissionCompleted, 0);
            Cursores.Add(PromptType.MissionFailed, 0);

            Cursores.Add(PromptType.InterestellarFactor, 0);
            Cursores.Add(PromptType.MaterialTrader, 0);
            Cursores.Add(PromptType.InventoryPanel, 0);
            Cursores.Add(PromptType.Help, 0);
            Cursores.Add(PromptType.None, 0);
            Cursores.Add(PromptType.BodySignals, 0);
            Cursores.Add(PromptType.Exceptions, 0);
            Cursores.Add(PromptType.ExoMastery, 0);
            Cursores.Add(PromptType.Statistics, 0);

            Cursores.Add(PromptType.Conflictos, 0);
            Cursores.Add(PromptType.Ordenes, 0);

            Cursores.Add(PromptType.Types, 0);
            Cursores.Add(PromptType.Merits, 0);

            Cursores.Add(PromptType.ColonisationList, 0);
            Cursores.Add(PromptType.ColonisationProgress, 0);

            BodySignals = new List<JournalFSSBodySignals>();

            //SetDisplay();

            string[] ports = SerialPort.GetPortNames();

            foreach (String s in ports)
            {
                cbArduinoCOM.Items.Add(s);
            }

            _serialPort = new SerialPort(); _serialPort.DataReceived += _serialPort_DataReceived;
            try
            {
                comandos = JsonConvert.DeserializeObject<List<Comandos>>(System.IO.File.ReadAllText(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Gramatica.json"));
            }
            catch (Exception exj)
            {
                comandos = System.Text.Json.JsonSerializer.Deserialize<List<Comandos>>(System.IO.File.ReadAllText(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Gramatica.json"));
            }


            foreach (Comandos c in comandos)
            {
                

                if (c.subcommands != null)
                {
                    foreach (SubComando sc in c.subcommands)
                    {
                        String fc = String.Format(c.command, sc.Item.ToLower());
                        Comandos comandofinal = (Comandos)c.Clone();
                        comandofinal.subcommands = null;
                        comandofinal.command = fc;
                        comandofinal.subsystem = sc.Argument;
                        comandofinal.code += c.code + sc.Argument;
                        comandosfinales.Add(comandofinal);
                    }
                    
                } else
                {
                    comandosfinales.Add(c);
                }

                


            }
            comandos = comandosfinales;
            

            choices = (from Comandos c in comandos select c.command).ToList();
            
            Log[PromptType.Help] = choices;

            var _completed = new ManualResetEvent(false);

            _listen = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("es-ES"));
            List<GrammarBuilder> gb = new List<GrammarBuilder>();

            _listen.RequestRecognizerUpdate();

            Choices exChoices = new Choices();

            exChoices.Add(choices.ToArray());

            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(exChoices);

            Grammar g = new Grammar(grammarBuilder);
            _listen.LoadGrammar(g);
            _listen.RequestRecognizerUpdate();
            _listen.SetInputToDefaultAudioDevice();

            _listen.RecognizeAsync(RecognizeMode.Multiple);

            // Add a handler for the speech recognized event.  
            _listen.SpeechRecognized +=
                      new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

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
            httpServer.replacer = this;
            httpServer.form = this;

            String pathWithEnv = "%USERPROFILE%\\Saved Games\\Frontier Developments\\Elite Dangerous";
            String filePath = Environment.ExpandEnvironmentVariables(pathWithEnv);

            CategoriasInventario = new CategoriasInventario();

            CategoriasInventario.Inventario = new Inventario();

            CategoriasInventario.CargarCategorias();

            string pattern = "*Journal*.log";
            var dirInfo = new DirectoryInfo(filePath);
            var file = (from f in dirInfo.GetFiles(pattern) orderby f.LastWriteTime descending select f.FullName).First();

            //foreach(var f in file)
            //{
                ProcessFile(file);
            //}

            
            /*
            IEnumerable<string> files = (from f in dirInfo.GetFiles(pattern) select f.FullName);

            foreach(string file2 in files)
            { 
                ProcessFile2(file2);
            }
            */

            fs = new FileSystemWatcher(filePath);
            fs.Created += Fs_Created;
            fs.Changed += Fs_Changed;
            fs.Deleted += Fs_Deleted;
            fs.EnableRaisingEvents = true;
        }

        private void TDisplay_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            SetDisplay();
        }

        void Form1_Load(object sender, EventArgs e)
        {
            MissionAccepted = DictionaryAdd<JournalMissionAccepted>("MissionAccepted", "0", new JournalMissionAccepted());
            MissionAccepted = DictionaryRemove<JournalMissionAccepted>("MissionAccepted", "0");


        }

        void FormClosed(object sender, EventArgs e)
        {

            Speak("EndThread", true);
            Speak("EndThread", false);
            Acknowledge("EndThread");

            _threadNPC = null;
            _threadSpeak = null;
            _threadAcknowledge = null;

            if (blec != null) blec.Dispose();


        }
        List<String> readAllLines(String i_FileNameAndPath)
        {
            StringBuilder sbAllText = new StringBuilder();

            File.Open(i_FileNameAndPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

            using (FileStream fileStream = File.Open(i_FileNameAndPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    while (streamReader.Peek() > -1)
                    {
                        String line = streamReader.ReadLine();
                        if (line != "" && line != null) sbAllText.Append(line);
                    }
                }
            }

            sbAllText.Replace("\r", "").Replace("\n", "");
            sbAllText.Replace("}{", "}\r\n{");

            String AllText = sbAllText.ToString();

            List<String> o_Lines = new List<String>();

            foreach (String line in AllText.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (line != "" && line != null) o_Lines.Add(line);
            }

            return o_Lines;
        }

        Boolean processing = false;

        async void ProcessFile(string filepath)
        {
            if (processing) return;
            processing = true;
            if (filepath.Contains("Status.json"))
            {
                try
                {
                    List<String> Lines = readAllLines(filepath);

                    OldStatus = Status;

                    try
                    {
                        this.Status = JsonConvert.DeserializeObject<Status>(Lines.Last());
                    }
                    catch (Exception exj)
                    {
                        this.Status = System.Text.Json.JsonSerializer.Deserialize<Status>(Lines.Last());
                    }

                    if (this.Status.Destination != null)
                    {
                        String _destination = this.Status.Destination.Name_Localised != null ? this.Status.Destination.Name_Localised.Replace("$EXT_PANEL_ColonisationShip;", "Nave de Colonización del Sistema") : this.Status.Destination.Name.Replace("$EXT_PANEL_ColonisationShip;", "Nave de Colonización del Sistema");
                        if (oldDestination != _destination)
                        {
                            Destination = _destination;
                            String message = "Destino: " + _destination;
                            AddPrompt(message, PromptType.Navigation);
                            Acknowledge(message);
                        }

                        oldDestination = _destination;
                    }
                    else
                    {
                        if (oldDestination != "")
                        {
                            String message = "La nave ha llegado al destino " + oldDestination;
                            AddPrompt(message, PromptType.Navigation);
                            Speak(message);

                            oldDestination = "";
                            Destination = "";
                        }
                    }
                    //                    Console.WriteLine(shipstatus.Destination.Name);

                    /*
                    try
                    {
                        if (!OldStatus.SuperCruise && this.Status.SuperCruise)
                        {
                            Speak("La nave ha entrado en supercrucero");
                        }
                    }
                    catch (Exception ccex)
                    {

                    }
                    */
                    try
                    {
                        if (OldStatus != null && this.Status != null && !OldStatus.Landed && this.Status.Landed)
                        {
                            Speak("La nave ha aterrizado");
                        }
                    }
                    catch (Exception ccex)
                    {

                    }

                    try
                    {
                        if (OldStatus != null && this.Status != null && !OldStatus.Docked && this.Status.Docked)
                        {
                            Speak("Nave asegurada en la plataforma");
                        }
                    }
                    catch (Exception ccex)
                    {

                    }
                    /*
                    try
                    {if (OldStatus.FSDMassLocked && !this.Status.FSDMassLocked)
                    {
                        Speak("Fuera del campo gravitatorio");
                    }
                       
                    }
                    catch (Exception ccex)
                    {

                    }
                    */

                    /*
                    try
                    {
                        if (!OldStatus.SuperCruise && this.Status.SuperCruise)
                        {
                            Speak("La nave ha entrado en supercrucero");
                        }
                    }
                    catch (Exception ccex)
                    {

                    }
                    */
                    DisplayPage();

                    /*
                    if (OldStatus.LandingGearDown && !this.Status.LandingGearDown)
                    {
                        Speak("Tren de aterrizaje replegado");
                    }
                    */
                    /*
                    if (!OldStatus.LandingGearDown && this.Status.LandingGearDown)
                    {
                        Speak("Tren de aterrizaje desplegado");
                    }
                    */

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.ToString());
                }

            }
            if (filepath.Contains("Journal"))
            {
                try
                {
                    List<String> Lines = readAllLines(filepath);

                    for (int i = LastEventLine + 1; i < Lines.Count(); i++)
                    //for (int i = 0; i < Lines.Count(); i++)
                    {
                        if (i > LastEventLine)
                        {


                            String s = Lines[i];

                            try
                            {
                                JournalBase journal;
                                try
                                {
                                    journal = JsonConvert.DeserializeObject<JournalBase>(s);

                                }
                                catch (Exception exj)
                                {
                                    journal = System.Text.Json.JsonSerializer.Deserialize<JournalBase>(s);
                                }
                                if (_journalDispatcher.HasHandler(journal.@event))
                                {
                                    try
                                    {
                                        JournalBase journalbase = EDCrew.Reader.ReadJson(s);
                                        await _journalDispatcher.DispatchAsync(journalbase);
                                    }
                                    catch (Exception exn)
                                    {
                                        Console.WriteLine($"Error despachando {journal.@event}: {exn.Message}");
                                    }
                                }
                                if (SaveEvents)
                                {
                                    EventCSharp(journal.@event, s);
                                }

                                //if (LastEvent == null || journal.timestamp > LastEvent)


                                /*
                                if (Filas.ContainsKey(i))
                                {
                                    Filas.Remove(i);
                                }
                                Filas.Add(i, s);
                                */
                                AddPrompt($"{i}/{LastEventLine} Nuevo Evento {journal.@event} {journal.timestamp}", PromptType.Event);
                                //LastEvent = journal.timestamp;
                                LastEventLine = i;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine(s);
                                Console.WriteLine(ex.StackTrace);
                                AddPrompt(ex.Message, PromptType.Exceptions);

                            }
                            finally
                            {

                            }
                            //i++;
                        }


                    }
                    //SetDisplay();


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.ToString());
                }

            }
            processing = false;
        }

        async void ProcessFile2(string filepath)
        {

            if (filepath.Contains("Journal"))
            {
                try
                {
                    List<String> Lines = readAllLines(filepath);

                    for (int i = 0; i < Lines.Count(); i++)
                    //for (int i = 0; i < Lines.Count(); i++)
                    {


                        String s = Lines[i];

                        try
                        {
                            JournalBase journal;
                            try
                            {
                                journal = JsonConvert.DeserializeObject<JournalBase>(s);

                            }
                            catch (Exception exj)
                            {
                                journal = System.Text.Json.JsonSerializer.Deserialize<JournalBase>(s);
                            }

                            if (journal.@event == "ScanOrganic")
                            {
                                JournalScanOrganic scan = JsonConvert.DeserializeObject<JournalScanOrganic>(s);

                                String scankey = $"{scan.SystemAddress}_{scan.Body}_{scan.Species_Localised}";

                                bool sscankey = false;
                                switch (scan.ScanType)
                                {
                                    case "Analyse":
                                        {
                                            sscankey = true;
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }

                                Scanned = DictionaryAdd<bool>("Scanned", scankey, sscankey);
                            }


                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine(s);
                            Console.WriteLine(ex.ToString());

                        }
                        finally
                        {

                        }
                        //i++;



                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.ToString());
                }

            }
            processing = false;
        }

        void Fs_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                ProcessFile(e.FullPath);
            }
            catch (Exception ex)
            {

            }

            fs.EnableRaisingEvents = true;

        }

        void Fs_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                if (e.FullPath.Contains("ournal"))
                    LastEventLine = -1;
                ProcessFile(e.FullPath);
            }
            catch (Exception ex)
            {

            }

            fs.EnableRaisingEvents = true;



        }

        void Fs_Deleted(object sender, FileSystemEventArgs e)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.FullPath);
            Console.ForegroundColor = old;


        }


        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }


        void SendCommand(byte[] command)
        {
            if (_serialPort.IsOpen)
                _serialPort.Write(command, 0, 8);
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
        void Pipeline.ICopilotOutput.AddPrompt(string text, PromptType promptType)
        {
            AddPrompt(text, promptType);
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
            MissionAccepted = DictionaryAdd<JournalMissionAccepted>("MissionAccepted", key, mission);
        }

        void Pipeline.ICopilotState.RemoveMissionAccepted(string key)
        {
            if (MissionAccepted.ContainsKey(key))
            {
                DictionaryRemove<JournalMissionAccepted>("MissionAccepted", key);
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
            Scanned = DictionaryAdd<bool>("Scanned", key, value);
        }

        void Pipeline.ICopilotState.AddDictionaryScanned(string systemAddress, string body, string speciesLocalised, bool analysed)
        {
            String filename = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"\\DictionaryScanned.{Commander}.json";

            Dictionary<String, Dictionary<String, bool>> Scanned2 = new Dictionary<string, Dictionary<string, bool>>();

            if (System.IO.File.Exists(filename))
            {
                Scanned2 = JsonConvert.DeserializeObject<Dictionary<String, Dictionary<String, bool>>>(System.IO.File.ReadAllText(filename));
            }

            if (!Scanned2.ContainsKey(systemAddress))
            {
                Scanned2.Add(systemAddress, new Dictionary<string, bool>());
            }

            String skey2 = $"{body}_{speciesLocalised}";

            Scanned2[systemAddress].Add(skey2, analysed);

            System.IO.File.WriteAllText(filename, JsonConvert.SerializeObject(Scanned2));
        }

        void AddPrompt(String s, PromptType prompttype)
        {
            /*
                        if (lastcommandpos == 38)
                        {
                            commandtodisplay.RemoveAt(0);
                        }
            */
            //commandtodisplay.Add(String.Format("{1}:\\>{0}", s, ShipName));
            Log[prompttype].Add(s);

            /*
            lastcommandpos = lastcommandpos == 38 ? 38 : lastcommandpos + 1;
            */
            //SetDisplay();

        }

        // Handle the SpeechRecognized event.  
        void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine(e.Result.Text);
            Comandos comando = (from Comandos c in comandos where c.command == e.Result.Text select c).First();
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
            Comandos comando = (from Comandos c in comandos where c.command == text select c).DefaultIfEmpty(null).FirstOrDefault();
            if (comando != null)
            {
                EjecutarComando(comando, voice);
            }
            else
            {
                comando = (from Comandos c in comandos where c.code == text select c).DefaultIfEmpty(null).FirstOrDefault();
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
                case "Mostrar Eventos": { WhatTo = PromptType.Event; break; }
                case "Mostrar Mensajes": { WhatTo = PromptType.Message; break; }
                case "Mostrar Comandos": { WhatTo = PromptType.Command; break; }
                case "Mostrar Inventario": { WhatTo = PromptType.Inventory; break; }
                case "Mostrar Navegación": { WhatTo = PromptType.Navigation; break; }
                case "Mostrar Combate": { WhatTo = PromptType.Combat; break; }
                case "Mostrar Excepciones": { WhatTo = PromptType.Exceptions; break; }
                case "Mostrar Tipos": { WhatTo = PromptType.Types; break; }
                case "Mostrar Méritos": { WhatTo = PromptType.Merits; break; }
                case "Empezar Nuevo Combate":
                    {
                        LastCombatTime = CombatTime;
                        CombatTime = DateTime.Now;
                        TimeSpan ts = CombatTime - LastCombatTime;
                        String m1 = $"Nave: {ShipName} Resultado:  {ts.ToString()}, {counters.Combat} derribos";
                        AddPrompt(m1, PromptType.Combat);
                        counters.Combat = 0;
                        AddPrompt("--- Nuevo Combate ---", PromptType.Combat);
                        break;
                    }
                case "Resetear Contadores": { AddPrompt("--- Resetear Contadores ---", PromptType.Combat); counters.Total = 0; counters.Merits = 0;  break; }
                case "Mostrar Misiones": { WhatTo = PromptType.MissionAccepted; break; }
                case "Mostrar Misiones Completadas": { WhatTo = PromptType.MissionCompleted; break; }
                case "Mostrar Misiones Fallidas": { WhatTo = PromptType.MissionFailed; break; }

                case "Mostrar Factor Interestelar":
                    {
                        FactoresInterestelar = await FactorInterestelar(StarSystem);
                        WhatTo = PromptType.InterestellarFactor;
                        break;
                    }
                case "Mostrar Comerciante materiales":
                    {
                        Comerciantes = await MaterialTrader(StarSystem);
                        WhatTo = PromptType.MaterialTrader;
                        break;
                    }
                case "Mostrar Conflictos":
                    {
                        ConflictosUUCC = await Conflictos();
                        WhatTo = PromptType.Conflictos;
                        break;

                    }

                case "Mostrar Panel de Inventario": { WhatTo = PromptType.InventoryPanel; break; }

                case "Mostrar Señales de Planetas": { WhatTo = PromptType.BodySignals; break; }

                case "Mostar Ruta Exobiología":
                    {
                        WhatTo = PromptType.ExoMastery;
                        LoadExoMastery();
                        break;
                    }

                case "Mostrar Ayuda": { WhatTo = PromptType.Help; break; }
                case "Mostrar estadísticas": { WhatTo = PromptType.Statistics; break; }
                case "Ocultar Información": { WhatTo = PromptType.None; break; }
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

            AddPrompt(comando.command, PromptType.Command);

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
                SendCommand(comando.control.ToArray());
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
            OrdenesUUCC = await Ordenes();
            WhatTo = PromptType.Ordenes;
        }
        private void Apuntar(String sistema)
        {
            Fetchingsubsystem = true;
            subsystem = sistema;

            EjecutarComando("Anterior Subsistema", false);
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
                if (_serialPort.IsOpen) _serialPort.Close();

                if (cbEnabled.Checked && cbArduinoCOM.Text != "")
                {
                    _serialPort.PortName = cbArduinoCOM.Text;//Set your board COM
                    _serialPort.BaudRate = 9600;
                    _serialPort.Open();

                }

            }
            catch (Exception ex)
            {

            }
        }


        private void AttachProcess()
        {
            string exeName = "EliteDangerous64";

            Process[] processes = Process.GetProcessesByName(exeName);
            foreach (Process process in processes)
            {
                // Simply attach to the first one found.

                // If the process doesn't have a mainwindowhandle yet, skip it (we need to be able to get the hwnd to set foreground etc)
                if (process.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }

                // Skip if the process is already hooked (and we want to hook multiple applications)
                if (HookManager.IsHooked(process.Id))
                {
                    continue;
                }

                Direct3DVersion direct3DVersion = Direct3DVersion.Direct3D11; //Direct3DVersion.Direct3D10;
                                                                              //direct3DVersion = Direct3DVersion.Direct3D11;

                CaptureConfig cc = new CaptureConfig()
                {
                    Direct3DVersion = direct3DVersion,
                    ShowOverlay = true
                };

                processId = process.Id;
                _process = process;

                var captureInterface = new CaptureInterface();
                captureInterface.RemoteMessage += new MessageReceivedEvent(CaptureInterface_RemoteMessage);
                _captureProcess = new CaptureProcess(process, cc, captureInterface);

                break;
            }
            Thread.Sleep(10);

            if (_captureProcess == null)
            {
                //MessageBox.Show("No executable found matching: '" + exeName + "'");
            }

        }

        void CaptureInterface_RemoteMessage(MessageReceivedEventArgs message)
        {

        }

        private List<Capture.Hook.Common.TextElement> CreatePrompt(byte r, byte g, byte b, int posx, int posy, string prompt)
        {
            var elements = new List<Capture.Hook.Common.TextElement>();
            /*
            for(int i = -1; i <= 1; i = i + 2)
            {
                for (int j = -1; j <= 1; j = j + 2)
                {

                    elements.Add(new Capture.Hook.Common.TextElement(font)
                    {
                        Location = new Point(posx + i, posy + j),
                        Color = Color.FromArgb(r / 2, g / 2, b / 2),
                        AntiAliased = true,
                        Text = RemoveBadChars(prompt)
                    });
                }

            }
            */
            elements.Add(new Capture.Hook.Common.TextElement(font)
            {
                Location = new Point(posx, posy),
                Color = Color.FromArgb(r, g, b),
                AntiAliased = true,
                Text = RemoveBadChars(prompt)
            });

            return (elements);

        }


        private void SetDisplay()
        {

            /*if (_captureProcess == null)
            {
                AttachProcess();
            }*/

            if (!cbOverlays.Checked)
            {
                if (_captureProcess != null) _captureProcess.CaptureInterface.DrawOverlayInGame(null);
                return;
            }

            AttachProcess();

            if (_captureProcess == null) return;

            if (WhatTo == PromptType.None)
            {
                _captureProcess.CaptureInterface.DrawOverlayInGame(null);
            }

            else
            {
                var elements = new List<Capture.Hook.Common.IOverlayElement>();

                elements.AddRange(CreatePrompt(0x00, 0x7F, 0, 20, 20, String.Format("{3} BRABEN OS v{1} (C) 1984-{1} LICENSED TO CMDR {2} SN {0} {5} {4} [{6}]", ShipName, System.DateTime.Now.Year + 1286, Commander, Ship, JournalPowerMerits != null ? JournalPowerMerits.TotalMerits.ToString() : "", JournalPowerRank != null ? JournalPowerRank.Power : JournalPowerMerits != null ? JournalPowerMerits.Power : "", JournalPowerRank != null ? JournalPowerRank.Rank.ToString() : "" )));
                elements.AddRange(CreatePrompt(0x00, 0x7F, 0, 20, 20, String.Format("{3} BRABEN OS v{1} (C) 1984-{1} LICENSED TO CMDR {2} SN {0} {5} {4} [{6}]", ShipName, System.DateTime.Now.Year + 1286, Commander, Ship, JournalPowerMerits != null ? JournalPowerMerits.TotalMerits.ToString() : "", JournalPowerRank != null ? JournalPowerRank.Power : JournalPowerMerits != null ? JournalPowerMerits.Power : "", JournalPowerRank != null ? JournalPowerRank.Rank.ToString() : "" )));

                String textoseccion = "";

                switch (WhatTo)
                {
                    case PromptType.Event: { textoseccion = "Eventos"; break; }
                    case PromptType.Message: { textoseccion = "Mensajes"; break; }
                    case PromptType.Command: { textoseccion = "Comandos"; break; }
                    case PromptType.Inventory: { textoseccion = "Inventario"; break; }
                    case PromptType.Navigation: { textoseccion = "Navegación"; break; }
                    case PromptType.Combat: { textoseccion = $"Combate {counters.Combat}/{FaccionObjetivo}: {counters.Faction}/{counters.Total}"; break; }
                    case PromptType.MissionAccepted: { textoseccion = "Misiones"; break; }
                    case PromptType.MissionCompleted: { textoseccion = "Misiones Completadas"; break; }
                    case PromptType.MissionFailed: { textoseccion = "Misiones Fallidas"; break; }

                    case PromptType.InterestellarFactor: { textoseccion = $"Factor interestelar {StarSystem}"; break; }
                    case PromptType.MaterialTrader: { textoseccion = $"Comerciantes de materiales {StarSystem}"; break; }
                    case PromptType.Conflictos: { textoseccion = $"Conflictos"; break; }
                    case PromptType.Ordenes: { textoseccion = $"Ordenes"; break; }
                    case PromptType.InventoryPanel: { textoseccion = "Panel de Inventario"; break; }
                    case PromptType.Help: { textoseccion = "Ayuda"; break; }
                    case PromptType.BodySignals: { textoseccion = "Señales Planetarias"; break; }
                    case PromptType.ExoMastery: { textoseccion = "Ruta Exobiología"; break; }
                    case PromptType.Exceptions: { textoseccion = "Excepciones"; break; }
                    case PromptType.Statistics: { textoseccion = "Estadisticas"; break; }
                    case PromptType.Merits: { textoseccion = "Mercancías Potencia"; break; }

                }


                elements.AddRange(CreatePrompt(0xFF, 0xFF, 0xFF, 20, 40, textoseccion));

                int i = 60;

                switch (WhatTo)
                {
                    case PromptType.MissionAccepted:

                        foreach(string s in MissionAccepted.Keys)
                        {
                            JournalMissionAccepted journall = MissionAccepted[s];
                            String prompt = $"{journall.LocalisedName} {journall.DestinationSystem} {journall.DestinationStation} {journall.Expiry} {journall.Reward}";

                            elements.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, prompt));

                            i += altofuente + 2;

                        }

                        break;
                    case PromptType.Statistics:
                        {
                            if (this.JournalStatistics == null) break;

                            String bank = $"Créditos: {JournalStatistics.Bank_Account.Current_Wealth} Naves: {JournalStatistics.Bank_Account.Owned_Ship_Count} Trajes: {JournalStatistics.Bank_Account.Suits_Owned} Armas: {JournalStatistics.Bank_Account.Weapons_Owned}";


                            elements.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, bank));

                            i += altofuente + 2;

                            String combat = $"Recompensas: {JournalStatistics.Combat.Bounties_Claimed} - {JournalStatistics.Combat.Bounty_Hunting_Profit} créditos";

                            elements.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, combat));

                            i += altofuente + 2;

                            combat = $"Zonas de conflicto: Baja {JournalStatistics.Combat.ConflictZone_Low_Wins}/{JournalStatistics.Combat.ConflictZone_Low} Media: {JournalStatistics.Combat.ConflictZone_Medium_Wins}/{JournalStatistics.Combat.ConflictZone_Medium} Alta: {JournalStatistics.Combat.ConflictZone_High_Wins}/{JournalStatistics.Combat.ConflictZone_High}";

                            elements.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, combat));

                            i += altofuente + 2;

                            combat = $"Bonos: {JournalStatistics.Combat.Combat_Bonds} - {JournalStatistics.Combat.Combat_Bond_Profits} créditos";

                            elements.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, combat));

                            i += altofuente + 2;

                            String trade = $"Comercio: {JournalStatistics.Trading.Goods_Sold} Toneladas {JournalStatistics.Trading.Market_Profits} Créditos en {JournalStatistics.Trading.Markets_Traded_With} mercados";

                            elements.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, trade));

                            i += altofuente + 2;

                            break;
                        }
                    case PromptType.ExoMastery:
                        {
                            if (ExoMasteryRoute != null)
                            {
                                int j = 0;
                                foreach (ExoMastery item in ExoMasteryRoute.Where(x => !x.Completado).Take(ExoMasteryRoute.Count() > 38 ? 38 : ExoMasteryRoute.Count()))
                                {
                                    if (Cursores[WhatTo] != j)
                                    {
                                        elements.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, item.ToString()));
                                    }
                                    else
                                    {
                                        elements.AddRange(CreatePrompt(0xB0, 0xFF, 0x00, 20, i, item.ToString()));
                                    }
                                    j++;
                                    i += altofuente + 2;
                                }

                            }
                            else elements.AddRange(CreatePrompt(0xFF, 0, 0, 20, i, "Sin Ruta Exobiología"));


                            break;
                        }
                    case PromptType.Conflictos:
                        {
                            if (ConflictosUUCC != null)
                            {
                                int j = 0;
                                foreach (StationListItem item in ConflictosUUCC.Take(ConflictosUUCC.Count() > 38 ? 38 : ConflictosUUCC.Count()))
                                {
                                    if (Cursores[WhatTo] != j)
                                    {
                                        elements.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, item.ToString3()));
                                    }
                                    else
                                    {
                                        elements.AddRange(CreatePrompt(0xB0, 0xFF, 0x00, 20, i, item.ToString3()));
                                    }
                                    j++;
                                    i += altofuente + 2;
                                }

                            }
                            else elements.AddRange(CreatePrompt(0xFF, 0, 0, 20, i, "Conflictos sin resultados"));
                            break;
                        }

                    case PromptType.Ordenes:
                        {
                            if (OrdenesUUCC != null)
                            {
                                int j = 0;
                                foreach (Order item in OrdenesUUCC.Take(OrdenesUUCC.Count() > 38 ? 38 : OrdenesUUCC.Count()))
                                {
                                    if (Cursores[WhatTo] != j)
                                    {
                                        elements.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, item.ToString()));
                                    }
                                    else
                                    {
                                        elements.AddRange(CreatePrompt(0xB0, 0xFF, 0x00, 20, i, item.ToString()));
                                    }
                                    j++;
                                    i += altofuente + 2;
                                }

                            }
                            else elements.AddRange(CreatePrompt(0xFF, 0, 0, 20, i, "Sin Órdenes"));
                            break;
                        }


                    case PromptType.InterestellarFactor:
                        {
                            if (FactoresInterestelar != null)
                            {
                                int j = 0;
                                foreach (StationListItem item in FactoresInterestelar.Take(FactoresInterestelar.Count() > 38 ? 38 : FactoresInterestelar.Count()))
                                {
                                    if (Cursores[WhatTo] != j)
                                    {
                                        elements.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, item.ToString2()));
                                    }
                                    else
                                    {
                                        elements.AddRange(CreatePrompt(0xB0, 0xFF, 0x00, 20, i, item.ToString2()));
                                    }
                                    j++;
                                    i += altofuente + 2;
                                }

                            }
                            else elements.AddRange(CreatePrompt(0xFF, 0, 0, 20, i, "Factores interestelar sin resultados"));
                            break;
                        }
                    case PromptType.MaterialTrader:
                        {
                            if (Comerciantes != null)
                            {
                                int j = 0;

                                foreach (StationListItem item in Comerciantes.Take(Comerciantes.Count() > 38 ? 38 : Comerciantes.Count()))
                                {
                                    if (Cursores[WhatTo] != j)
                                    {
                                        elements.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, item.ToString()));
                                    }
                                    else
                                    {
                                        elements.AddRange(CreatePrompt(0xB0, 0xFF, 0x00, 20, i, item.ToString()));
                                    }

                                    i += altofuente + 2;
                                    j++;
                                }

                            }
                            else elements.AddRange(CreatePrompt(0xFF, 0, 0, 20, i, "Comerciantes sin resultados"));
                            break;
                        }
                    case PromptType.BodySignals:
                        {

                            int j = 0;

                            String filename = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"\\DictionaryScanned.{Commander}.json";

                            Dictionary<String, Dictionary<String, bool>> Scanned2 = JsonConvert.DeserializeObject<Dictionary<String, Dictionary<String, bool>>>(System.IO.File.ReadAllText(filename));

                            foreach (JournalFSSBodySignals journal in BodySignals)
                            {

                                String message = journal.BodyName;

                                foreach (JournalFSSBodySignalsSignal s in journal.Signals)
                                {
                                    message += " " + s.Type_Localised + "(" + s.Count + ")";
                                }

                                if (Cursores[WhatTo] != j)
                                {
                                    elements.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, message));
                                }
                                else
                                {
                                    elements.AddRange(CreatePrompt(0xB0, 0xFF, 0x00, 20, i, message));
                                }

                                i += altofuente + 2;
                                j++;

                            }


                            //Dictionary<String, Dictionary<String, bool>> Scanned2 = new Dictionary<String, Dictionary<string, bool>>();
                            String systemaddress = SystemAddress.ToString();

                            if (Scanned2.ContainsKey(systemaddress))
                            {
                                foreach (String skey2 in Scanned2[systemaddress].Keys)
                                {
                                    elements.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, $"{skey2} {Scanned2[systemaddress][skey2]}"));

                                    i += altofuente + 2;

                                }
                            }


                            break;
                        }
                    case PromptType.InventoryPanel:
                        {
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
                                elements.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, RemoveBadChars(level + cabecera)));
                                i += altofuente + 2;

                                level = "    ";

                                foreach (List<String> categoria in tipo)
                                {
                                    String display = "";

                                    foreach (String elemento in categoria)
                                    {
                                        if (elemento != String.Empty)
                                        {
                                            //display += elemento.Length >= 16 ? elemento.Substring(0, 16) : elemento + new string(' ', 16 - elemento.Length);
                                            display += elemento;
                                            display += ": " + this.CategoriasInventario.Cantidad(elemento) + "/" + this.CategoriasInventario.Maximo(elemento) + " ";
                                        }
                                    }

                                    elements.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, RemoveBadChars(level + display)));
                                    i += altofuente + 2;

                                }
                                it++;

                            }
                            break;
                        }
                    default:
                        {
                            i = Display(WhatTo, elements, i);
                            if (WhatTo == PromptType.Combat && EventMarked != null)
                            {
                                String estado = EventMarked.LegalStatus == "Wanted" ? $", buscado con recompensa de {EventMarked.Bounty} créditos" : "";
                                String pilotname = EventMarked.PilotName_Localised != "" ? EventMarked.PilotName_Localised : EventMarked.PilotName;
                                String modelo = EventMarked.Ship_Localised != null ? EventMarked.Ship_Localised : EventMarked.Ship;
                                String prompt = $"Piloto {pilotname}, modelo {modelo}, facción {EventMarked.Faction} {estado}";
                                elements.AddRange(CreatePrompt(0xFF, 0xFF, 0xFF, 20, i, RemoveBadChars(prompt)));
                            }
                            break;
                        }

                }


                                
                         /*       elements.Add(new Capture.Hook.Common.ImageElement(this.Bmp, true) {
                                    Location = new Point(0, 20),
                                });*/
                  

                _captureProcess.CaptureInterface.DrawOverlayInGame(new Capture.Hook.Common.Overlay
                {
                    Elements = elements,
                    Hidden = false //!cbDrawOverlay.Checked
                });

            }

        }

        private void Range(PromptType prompttype, ref int first, ref int last, ref int count)
        {
            int c = Log[prompttype].Count();
            int l = c > 38 ? 38 : c;

            first = c - l;
            last = first + l;
            count = l;

        }
        /*
                private void Range(PageTypeMFD prompttype, ref int first, ref int last, ref int count)
                {
                    int c = LogMFD[prompttype].Count();
                    int l = c > 3 ? 3 : c;

                    first = c - l;
                    last = first + l - 1;
                    count = l;
                }
        */
        private int Display(PromptType prompttype, List<IOverlayElement> elements, int i)
        {
            int first = 0;
            int count = 0;
            int last = 0;
            Range(prompttype, ref first, ref last, ref count);

            foreach (string s in Log[prompttype].GetRange(first, count))
            {
                elements.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, s));
                i += altofuente + 2;
            }

            return i;
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

                foreach (String s in Log[PromptType.Message])
                {
                    string ss = RemoveBadChars(s);
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

                foreach (String s in Log[PromptType.Combat])
                {
                    string ss = RemoveBadChars(s);
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

                        if (j == Cursores[PromptType.InterestellarFactor])
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


        private async void button1_Click(object sender, EventArgs e)
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

            //SendColorAsync(255, 0, 0, 100, 100);
            
            if (blec == null)
            {
                blec = new BleLightController("QHM-F5FE");
            }

            CancellationToken token = blec.StartAnimation();
            


            await blec.RunSequenceLoopAsync(new[]
{
    ((byte)255, (byte)0, (byte)0, (byte)100, 500, 1000),
    ((byte)0, (byte)255, (byte)0, (byte)100, 2000, 1000),
    ((byte)0, (byte)0, (byte)255, (byte)100, 2000, 1000)
}, token);






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
            /*
            string[] requestedProperties = { "System.Devices.Aep.DeviceAddress", "System.Devices.Aep.IsConnected" };

            DeviceWatcher deviceWatcher =
                        DeviceInformation.CreateWatcher(
                                BluetoothLEDevice.GetDeviceSelectorFromPairingState(false),
                                requestedProperties,
                                DeviceInformationKind.AssociationEndpoint);

            // Register event handlers before starting the watcher.
            // Added, Updated and Removed are required to get all nearby devices
            deviceWatcher.Added += DeviceWatcher_Added;
            deviceWatcher.Updated += DeviceWatcher_Updated;
            deviceWatcher.Removed += DeviceWatcher_Removed;

            // EnumerationCompleted and Stopped are optional to implement.
            deviceWatcher.EnumerationCompleted += DeviceWatcher_EnumerationCompleted;
            deviceWatcher.Stopped += DeviceWatcher_Stopped;

            // Start the watcher.
            deviceWatcher.Start();
            */

            Scanned = Dictionary<bool>("Scanned");

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

        private void DeviceWatcher_Stopped(DeviceWatcher sender, object args)
        {
            //throw new NotImplementedException();
        }

        private void DeviceWatcher_EnumerationCompleted(DeviceWatcher sender, object args)
        {
            //throw new NotImplementedException();
        }

        private void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate args)
        {
            //throw new NotImplementedException();
        }

        private void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate args)
        {
            //throw new NotImplementedException();
        }

        private DeviceInformation lights;
        GattCharacteristic ligthscharasteristic;

        public bool StatusScanned { get; set; }
        public string promptmfd { get; set; }
        public JournalSquadronStartup Squadron { get; set; }
        public bool SaveEvents { get; set; }
        public int ContadorCombate { get => counters.Combat; set { counters.Combat = value; nContadorCombate.Value = counters.Combat; } }

        public BleLightController blec { get; private set; }

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

        private void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation args)
        {
            if (args.Name == "QHM-F5FE")
            {
                lights = args;
                ConnectDeviceAsync(lights);
            }
            //throw new NotImplementedException();
        }

        public async Task SendColorAsync(byte r, byte g, byte b, byte warmWhite, int progress)
        {
            DeviceInformation deviceInfo = null;

            var selector = BluetoothLEDevice.GetDeviceSelector();
            var devices = await DeviceInformation.FindAllAsync(selector);

            foreach (var d in devices)
            {
                Console.WriteLine($"{d.Name} - {d.Id}");

                if (d.Name == "QHM-F5FE") deviceInfo = d;

            }

            if (deviceInfo == null) return;

            
            var device = await BluetoothLEDevice.FromIdAsync(deviceInfo.Id);
            if (device == null) throw new Exception("No se pudo abrir el dispositivo BLE.");

            var servicesResult = await device.GetGattServicesAsync();
            if (servicesResult.Status != GattCommunicationStatus.Success) throw new Exception("Servicios GATT no disponibles.");

            foreach(var s in servicesResult.Services)
            {
                Console.WriteLine(s.Uuid);
            }

            // Selecciona el servicio custom (ajusta según lo que veas: FFD0/FFD5)
            var service = servicesResult.Services
                .FirstOrDefault(s => s.Uuid.ToString().ToLower().Contains("ffd5"));
            if (service == null) throw new Exception("Servicio FFD9 no encontrado.");

            var charsResult = await service.GetCharacteristicsAsync();
            if (charsResult.Status != GattCommunicationStatus.Success) throw new Exception("Características no disponibles.");

            // Elige una característica que permita escritura
            var ch = charsResult.Characteristics.FirstOrDefault(c =>
                c.CharacteristicProperties.HasFlag(GattCharacteristicProperties.WriteWithoutResponse) ||
                c.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Write));
            if (ch == null) throw new Exception("No hay característica con permisos de escritura.");

            if (progress < 3) progress = 3;

            byte scaledR = (byte)((r * progress) / 100);
            byte scaledG = (byte)((g * progress) / 100);
            byte scaledB = (byte)((b * progress) / 100);
            byte scaledW = (byte)((warmWhite * progress) / 100);

            byte[] frame = new byte[] { 0x56, scaledR, scaledG, scaledB, scaledW, 0xF0, 0xAA };

            if (warmWhite != 0)
            {
                frame[1] = 0;
                frame[2] = 0;
                frame[3] = 0;
                frame[4] = (byte)((progress * 255) / 100);
                frame[5] = 0x0F;
            }

            var buffer = Windows.Security.Cryptography.CryptographicBuffer.CreateFromByteArray(frame);

            var writeOption = ch.CharacteristicProperties.HasFlag(GattCharacteristicProperties.WriteWithoutResponse)
                ? GattWriteOption.WriteWithoutResponse
                : GattWriteOption.WriteWithResponse;

            var status = await ch.WriteValueWithResultAsync(buffer, writeOption);
            if (status.Status != GattCommunicationStatus.Success)
                throw new Exception($"Fallo al escribir: {status.ProtocolError ?? 0}");
            //device.Dispose();
        }

        async void ConnectDeviceAsync(DeviceInformation deviceInfo)

        {/*List<String> temp = new List<string>();
                foreach(String s in Log[PromptType.Message])
                {
                    temp.Add(RemoveBadChars(s));
                }

                Log[PromptType.Message] = temp;*/
            // Note: BluetoothLEDevice.FromIdAsync must be called from a UI thread because it may prompt for consent.
            using (BluetoothLEDevice bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync(deviceInfo.Id))
            {


                Console.WriteLine(bluetoothLeDevice.Name);

                GattDeviceServicesResult resultServices = await bluetoothLeDevice.GetGattServicesAsync();

                if (resultServices.Status == GattCommunicationStatus.Success)
                {
                    var services = resultServices.Services;
                    foreach (GattDeviceService service in services)
                    {
                        Console.WriteLine($"{service.Uuid}");

                        GattCharacteristicsResult resultCharacteristics = await service.GetCharacteristicsAsync();

                        if (resultCharacteristics.Status == GattCommunicationStatus.Success)
                        {
                            var characteristics = resultCharacteristics.Characteristics;

                            foreach (GattCharacteristic characteristic in characteristics)
                            {
                                Console.WriteLine($"{characteristic.Uuid}");

                                GattCharacteristicProperties properties = characteristic.CharacteristicProperties;

                                if (properties.HasFlag(GattCharacteristicProperties.Write))
                                {
                                    Console.WriteLine($"Write");
                                    ligthscharasteristic = characteristic;

                                    byte[] color = new byte[]
                                    {
                                        0x56, //const
                                        0xff, //r
                                        0x00,
                                        0x00,
                                        0xff, //warm byte
                                        0xf0,
                                        0xaa,0,0,0,0,0,0,0,0,0};
                                    var writer = new DataWriter();

                                    byte[] sKey = new byte[] { unchecked((byte)-48), unchecked((byte)-7), unchecked((byte)-12), unchecked((byte)-116), 89, unchecked((byte)-94), 105, 29, 32, 83, unchecked((byte)-53), unchecked((byte)-38), unchecked((byte)-128), unchecked((byte)-124), 67, unchecked((byte)-109) };

                                    SymmetricAlgorithm crypt = Aes.Create();
                                    crypt.Key = sKey;
                                    crypt.Mode = CipherMode.ECB;
                                    crypt.Padding = PaddingMode.None;


                                    byte[] encrypted;

                                    using (MemoryStream msEncrypt = new MemoryStream())
                                    {
                                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, crypt.CreateEncryptor(), CryptoStreamMode.Write))
                                        {
                                            csEncrypt.Write(color, 0, color.Length);
                                        }
                                        writer.WriteBytes(msEncrypt.ToArray());
                                    }



                                }

                            }
                        }

                    }
                }
            }
            // ...
        }

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

        public async Task<List<StationListItem>> MaterialTrader(string starsystem = "")
        {
            List<StationListItem> result;

            if (starsystem == "") starsystem = this.StarSystem;

            String foldername = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"\\Data";

            System.IO.Directory.CreateDirectory(foldername);

            String filename = $"{foldername}\\MaterialTrader.{starsystem}.json";

            if (System.IO.File.Exists(filename))
            {
                result = JsonConvert.DeserializeObject<List<StationListItem>>(System.IO.File.ReadAllText(filename));
                return result;
            }
            /*
            if (handler == null || proxy == null)
            {
                await InitializeTor();
            }

            HttpClient client = new HttpClient(handler);

            await proxy.ConfigureAndStartAsync();
            */

            HttpClient client = new HttpClient();

            HttpResponseMessage httpresponse = await client.GetAsync($"https://inara.cz/elite/nearest-stations/?formbrief=1&ps1={starsystem}&pi13=&pi14=0&pi15=0&pi16=&pi1=0&pi18=3&pi19=5000&pi17=1&pa1[]=25&ps2=&pi25=0&pi8=&pi9=0&pi26=0&pi3=&pi4=0&pi5=0&pi7=0&pi23=0&pi6=0&ps3=&pi24=0&language=4");

            result = new List<StationListItem>();

            try
            {
                httpresponse.EnsureSuccessStatusCode();

                String response = await httpresponse.Content.ReadAsStringAsync();

                CsQuery.CQ document = response;

                CsQuery.CQ rows = document["tr"];

                for (int i = 1; i < rows.Count(); i++)
                {
                    StationListItem listitem = new StationListItem();
                    DomElement row = (DomElement)rows[i];

                    CsQuery.CQ cqrow = CsQuery.CQ.Create(row);

                    CsQuery.CQ cells = cqrow["td"];

                    DomElement cell = (DomElement)cells[0];

                    listitem.Tipo = cell.InnerHTML.Replace("<span class=\"minor\">", "").Replace("<span class=\"positive\">", "").Replace("</span>", "");

                    cell = (DomElement)cells[1];

                    CsQuery.CQ cqcell = CsQuery.CQ.Create(cell);
                    CsQuery.CQ cqcontent = cqcell["a"];

                    listitem.Estacion = cqcontent.FirstElement().InnerText;

                    cell = (DomElement)cells[2];

                    cqcell = CsQuery.CQ.Create(cell);
                    cqcontent = cqcell["a"];

                    listitem.Sistema = cqcontent.FirstElement().InnerText;

                    cell = (DomElement)cells[6];

                    listitem.DistanciaEstrella = cell.InnerText;

                    cell = (DomElement)cells[7];

                    listitem.DistanciaSistema = cell.InnerText;


                    result.Add(listitem);

                }

            }
            catch (Exception ex)
            {

            }
            if (result != null && result.Count != 0)
                System.IO.File.WriteAllText(filename, JsonConvert.SerializeObject(result));

            return result;

        }

        //https://json2csharp.com/api/Default
        public async Task<String> EventCSharp(String ClassName, String Event)
        {
            /*
            if (handler == null || proxy == null)
            {
                await InitializeTor();
            }

            HttpClient client = new HttpClient(handler);

            await proxy.ConfigureAndStartAsync();
            */

            HttpClient client = new HttpClient();

            JsonToCsharpInput input = new JsonToCsharpInput()
            {
                input = Event,
                operationid = "jsontocsharp",
                settings = new JsonToCsharpSettings()
                {
                    UsePascalCase = "false",
                    UseFields = "false",
                    AlwaysUseNullables = "false",
                    UseJsonAttributes = "false",
                    NullValueHandlingIgnore = "false",
                    UseJsonPropertyName = "false",
                    ImmutableClasses = "false",
                    RecordTypes = "false",
                    NoSettersForCollections = "false"
                }
            };

            var myContent = JsonConvert.SerializeObject(input);

            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage httpresponse = await client.PostAsync($"https://json2csharp.com/api/Default", byteContent);

            String result = "";

            try
            {
                httpresponse.EnsureSuccessStatusCode();

                result = await httpresponse.Content.ReadAsStringAsync();

                result = result.Replace("\"// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);\\r\\n    ", "").Replace("\\r\\n", "\r\n");
                result = result.Replace("public class Root", "public class Journal" + ClassName + " : JournalBase");
                result = result.Remove(result.Length - 1);
                result = result.Replace("public DateTime timestamp { get; set; }", "");
                result = result.Replace("public string @event { get; set; }", "");
                String foldername = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"\\Classes";

                System.IO.Directory.CreateDirectory(foldername);

                String filename = $"{foldername}\\{ClassName}.{Guid.NewGuid().ToString()}.cs";

                System.IO.File.WriteAllText(filename, @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //" + Event + "\r\n" + result + @"
}");

            }
            catch (Exception ex)
            {

            }

            return result;

        }



        public async Task<List<StationListItem>> FactorInterestelar(string starsystem = "")
        {
            List<StationListItem> result = null;

            if (starsystem == "") starsystem = this.StarSystem;

            String foldername = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"\\Data";

            System.IO.Directory.CreateDirectory(foldername);

            String filename = $"{foldername}\\FactorInterestelar.{starsystem}.json";

            if (System.IO.File.Exists(filename))
            {
                result = JsonConvert.DeserializeObject<List<StationListItem>>(System.IO.File.ReadAllText(filename));
                return result;
            }
            /*
            if (handler == null || proxy == null)
            {
                await InitializeTor();
            }

            HttpClient client = new HttpClient(handler);

            await proxy.ConfigureAndStartAsync();
            */

            HttpClient client = new HttpClient();

            HttpResponseMessage httpresponse = await client.GetAsync($"https://inara.cz/elite/nearest-stations/?formbrief=1&ps1={starsystem}&pi13=&pi14=0&pi15=0&pi16=&pi1=0&pi18=0&pi19=0&pi17=0&pa1%5B%5D=18&ps2=&pi25=0&pi8=&pi9=0&pi26=0&pi3=&pi4=0&pi5=0&pi7=0&pi23=0&pi6=0&ps3=&pi24=0");

            httpresponse.EnsureSuccessStatusCode();

            String response = await httpresponse.Content.ReadAsStringAsync();

            CsQuery.CQ document = response;

            CsQuery.CQ rows = document["tr"];

            result = new List<StationListItem>();

            for (int i = 1; i < rows.Count(); i++)
            {
                StationListItem listitem = new StationListItem();
                DomElement row = (DomElement)rows[i];

                CsQuery.CQ cqrow = CsQuery.CQ.Create(row);

                CsQuery.CQ cells = cqrow["td"];

                DomElement cell = (DomElement)cells[0];

                CsQuery.CQ cqcell = CsQuery.CQ.Create(cell);
                CsQuery.CQ cqcontent = cqcell["a"];

                listitem.Estacion = ((DomElement)cqcontent[0]).InnerText;

                cell = (DomElement)cells[1];

                cqcell = CsQuery.CQ.Create(cell);
                cqcontent = cqcell["a"];

                listitem.Sistema = cqcontent.FirstElement().InnerText;

                cell = (DomElement)cells[5];

                listitem.DistanciaEstrella = cell.InnerText;

                cell = (DomElement)cells[6];

                listitem.DistanciaSistema = cell.InnerText;


                result.Add(listitem);

            }
            if (result != null && result.Count != 0)
                System.IO.File.WriteAllText(filename, JsonConvert.SerializeObject(result));

            return result;

        }

        public async Task<List<StationListItem>> Conflictos()
        {
            List<StationListItem> result;
            /*
            if (handler == null || proxy == null)
            {
                await InitializeTor();
            }

            HttpClient client = new HttpClient(handler);

            await proxy.ConfigureAndStartAsync();
            */

            HttpClient client = new HttpClient();

            HttpResponseMessage httpresponse = await client.GetAsync($"https://inara.cz/elite/minorfaction-conflicts/35226");

            result = new List<StationListItem>();

            try
            {
                httpresponse.EnsureSuccessStatusCode();

                String response = await httpresponse.Content.ReadAsStringAsync();

                CsQuery.CQ document = response;

                CsQuery.CQ cells = document["td"];

                for (int i = 0; i < cells.Count(); i = i + 8)
                {

                    DomElement celllocation = (DomElement)cells[i];

                    DomElement cellFaction0 = (DomElement)cells[i + 1];
                    DomElement cellFaction1 = (DomElement)cells[i + 3];
                    DomElement cellTipo = (DomElement)cells[i + 2];
                    DomElement cellResultado = (DomElement)cells[i + 4];

                    DomElement cell = cellFaction0;

                    CsQuery.CQ cqcell = CsQuery.CQ.Create(cell);
                    CsQuery.CQ cqcontent = cqcell["a"];

                    String faction0 = ((DomElement)cqcontent[0]).InnerText;

                    cell = cellFaction1;

                    cqcell = CsQuery.CQ.Create(cell);
                    cqcontent = cqcell["a"];

                    String faction1 = ((DomElement)cqcontent[0]).InnerText;

                    if (faction0.Contains("Union Cosmos") || faction1.Contains("Union Cosmos"))
                    {
                        StationListItem listitem = new StationListItem();

                        cell = celllocation;

                        cqcell = CsQuery.CQ.Create(cell);
                        cqcontent = cqcell["a"];

                        listitem.Sistema = ((DomElement)cqcontent[0]).InnerText;
                        listitem.DistanciaSistema = faction0;
                        listitem.DistanciaEstrella = faction1;
                        listitem.Tipo = cellTipo.InnerText;
                        listitem.Estacion = cellResultado.InnerText;


                        result.Add(listitem);

                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;

        }

        public async Task<List<Order>> Ordenes()
        {
            List<Order> result = null;

            String foldername = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"\\Data\\Ordenes";

            System.IO.Directory.CreateDirectory(foldername);

            String filename = $"{foldername}\\ordenes.json";

            if (System.IO.File.Exists(filename))
            {
                result = JsonConvert.DeserializeObject<List<Order>>(System.IO.File.ReadAllText(filename));
                return result;
            }

            return result;

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
           
            if (npc)
            {
                lock (_lockObjNPC)
                {
                    _lockObjNPC.Statement = phrase;
                    Monitor.Pulse(_lockObjNPC);
                }

            }
            else
            {
                lock (_lockObjSpeak)
                {
                    _lockObjSpeak.Statement = phrase;
                    Monitor.Pulse(_lockObjSpeak);
                }
            }


        }

        void Acknowledge(string phrase)
        {

            lock (_lockObjAcknowledge)
            {
                _lockObjAcknowledge.Statement = phrase;

                Monitor.Pulse(_lockObjAcknowledge);
            }

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

        private Dictionary<String, T> Dictionary<T>(String DictionaryName)
        {
            String filename = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"\\Dictionary{DictionaryName}.json";

            Dictionary<String, T> d = new Dictionary<string, T>();

            if (System.IO.File.Exists(filename)) d = JsonConvert.DeserializeObject<Dictionary<String, T>>(System.IO.File.ReadAllText(filename));

            return (d);

        }

        private Dictionary<String, T> DictionaryAdd<T>(String DictionaryName, String key, T value)
        {

            String filename = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"\\Dictionary{DictionaryName}.json";

            Dictionary<String, T> d = new Dictionary<string, T>();

            if (System.IO.File.Exists(filename)) d = JsonConvert.DeserializeObject<Dictionary<String, T>>(System.IO.File.ReadAllText(filename));

            if (!d.ContainsKey(key))
            {
                d.Add(key, value);
            }

            if (!d[key].Equals(value))
            {
                d[key] = value;
            }

            System.IO.File.WriteAllText(filename, JsonConvert.SerializeObject(d));

            return (d);


        }

        private Dictionary<String, T> DictionaryRemove<T>(String DictionaryName, String key)
        {

            String filename = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"\\Dictionary{DictionaryName}.json";

            Dictionary<String, T> d = new Dictionary<string, T>();

            if (System.IO.File.Exists(filename)) d = JsonConvert.DeserializeObject<Dictionary<String, T>>(System.IO.File.ReadAllText(filename));

            if (d.ContainsKey(key))
            {
                d.Remove(key);
            }

            System.IO.File.WriteAllText(filename, JsonConvert.SerializeObject(d));

            return (d);

        }

        private Dictionary<String, T> DictionaryClear<T>(String DictionaryName)
        {

            String filename = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"\\Dictionary{DictionaryName}.json";

            Dictionary<String, T> d = new Dictionary<string, T>();

            System.IO.File.WriteAllText(filename, JsonConvert.SerializeObject(d));

            return (d);


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
            MissionAccepted = DictionaryClear<JournalMissionAccepted>("MissionAccepted");
        }

        private void SiguienteOpcion()
        {
            int step = 1;

            Cursores[WhatTo] += step;

            if (Cursores[WhatTo] >= 38) Cursores[WhatTo] = 37;

        }

        private void AnteriorOpcion()
        {
            Cursores[WhatTo] -= 1;

            if (Cursores[WhatTo] <= 0) Cursores[WhatTo] = 0;

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
            IraOpcion(WhatTo, opcion, sistema);
        }

        public void IraOpcion(PromptType t, int opcion, bool sistema)
        {
            Cursores[t] = opcion;
            if (Cursores[t] <= 0) Cursores[t] = 0;
            if (Cursores[t] >= 38) Cursores[t] = 37;
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
                            text = sistema ? FactoresInterestelar[Cursores[PromptType.InterestellarFactor]].Sistema : FactoresInterestelar[Cursores[PromptType.InterestellarFactor]].Estacion;
                            tospeak = $"Preparando destino Factor Interestelar: {tipo} {text} cargado en la computadora de navegación";

                            break;
                        }
                    case PromptType.MaterialTrader:
                        {
                            text = sistema ? Comerciantes[Cursores[PromptType.MaterialTrader]].Sistema : Comerciantes[Cursores[PromptType.MaterialTrader]].Estacion;
                            tospeak = $"Preparando destino Comerciante de materiales: {tipo} {text} cargado en la computadora de navegación";
                            break;
                        }
                    case PromptType.ExoMastery:
                        {
                            text = sistema ? ExoMasteryRoute.Where(x => !x.Completado).ToList()[Cursores[PromptType.ExoMastery]].Nombredelsistema : ExoMasteryRoute.Where(x => !x.Completado).ToList()[Cursores[PromptType.ExoMastery]].Nombredelcuerpo;
                            tospeak = $"Preparando destino {text}";
                            break;

                        }
                    case PromptType.Conflictos:
                        {
                            text = ConflictosUUCC[Cursores[PromptType.Conflictos]].Sistema;
                            tospeak = $"Preparando destino {text} en {ConflictosUUCC[Cursores[PromptType.Conflictos]].Tipo} entre {ConflictosUUCC[Cursores[PromptType.Conflictos]].DistanciaSistema} y {ConflictosUUCC[Cursores[PromptType.Conflictos]].DistanciaEstrella}";
                            break;

                        }
                    case PromptType.Ordenes:
                        {
                            text = OrdenesUUCC[Cursores[PromptType.Ordenes]].System;
                            tospeak = $"Preparando destino {text} en {OrdenesUUCC[Cursores[PromptType.Ordenes]].System} {OrdenesUUCC[Cursores[PromptType.Ordenes]].Orders}";
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
            SeleccionarOpcion(WhatTo, sistema);

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

                SetDisplay();


            }

        }

        HttpClientHandler handler;
        //TorSharpProxy proxy;

        /*
        public async Task<int> InitializeTor()
        {
            var settings = new TorSharpSettings
            {
                ZippedToolsDirectory = Path.Combine(Path.GetTempPath(), "TorZipped"),
                ExtractedToolsDirectory = Path.Combine(Path.GetTempPath(), "TorExtracted"),
                PrivoxySettings =
                {
                    Port = 18118,
                },
                TorSettings =
                {
                    SocksPort = 19050,
                    AdditionalSockPorts = { 19052 },
                    ControlPort = 19051,
                    ControlPassword = "foobar",
                },
            };



            HttpClient client0 = new HttpClient();

            var fetcher = new TorSharpToolFetcher(settings, client0);
            var updates = await fetcher.CheckForUpdatesAsync();

            Console.WriteLine($"Current Privoxy: {updates.Privoxy.LocalVersion?.ToString() ?? "(none)"}");
            Console.WriteLine($" Latest Privoxy: {updates.Privoxy.LatestDownload.Version}");
            Console.WriteLine();
            Console.WriteLine($"Current Tor: {updates.Tor.LocalVersion?.ToString() ?? "(none)"}");
            Console.WriteLine($" Latest Tor: {updates.Tor.LatestDownload.Version}");
            Console.WriteLine();
            if (updates.HasUpdate)
            {
                await fetcher.FetchAsync(updates);
            }

            proxy = new TorSharpProxy(settings);

            handler = new HttpClientHandler
            {
                Proxy = new WebProxy(new Uri("http://localhost:" + settings.PrivoxySettings.Port))
            };

            return 0;

        }
        */

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

            /*

            HttpClient client = new HttpClient();
            HttpResponseMessage httpresponse = await client.GetAsync($"https://inara.cz/elite/nearest-stations/?formbrief=1&ps1={starsystem}&pi13=&pi14=0&pi15=0&pi16=&pi1=0&pi18=3&pi19=5000&pi17=1&pa1[]=25&ps2=&pi25=0&pi8=&pi9=0&pi26=0&pi3=&pi4=0&pi5=0&pi7=0&pi23=0&pi6=0&ps3=&pi24=0&language=4");

            result = new List<StationListItem>();

            try
            {
                httpresponse.EnsureSuccessStatusCode();

                String response = await httpresponse.Content.ReadAsStringAsync();

                CsQuery.CQ document = response;

                CsQuery.CQ rows = document["tr"];

                for (int i = 1; i < rows.Count(); i++)
                {
                    StationListItem listitem = new StationListItem();
                    DomElement row = (DomElement)rows[i];

                    CsQuery.CQ cqrow = CsQuery.CQ.Create(row);

                    CsQuery.CQ cells = cqrow["td"];

                    DomElement cell = (DomElement)cells[0];

                    listitem.Tipo = cell.InnerHTML.Replace("<span class=\"minor\">", "").Replace("<span class=\"positive\">", "").Replace("</span>", "");

                    cell = (DomElement)cells[1];

                    CsQuery.CQ cqcell = CsQuery.CQ.Create(cell);
                    CsQuery.CQ cqcontent = cqcell["a"];

                    listitem.Estacion = cqcontent.FirstElement().InnerText;

                    cell = (DomElement)cells[2];

                    cqcell = CsQuery.CQ.Create(cell);
                    cqcontent = cqcell["a"];

                    listitem.Sistema = cqcontent.FirstElement().InnerText;

                    cell = (DomElement)cells[6];

                    listitem.DistanciaEstrella = cell.InnerText;

                    cell = (DomElement)cells[7];

                    listitem.DistanciaSistema = cell.InnerText;


                    result.Add(listitem);

                }

            }
            catch (Exception ex)
            {

            }
            if (result != null && result.Count != 0)
                System.IO.File.WriteAllText(filename, JsonConvert.SerializeObject(result));

            return result;
            */




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

        private readonly SpeakInfo _lockObjNPC = new SpeakInfo();
        private readonly SpeakInfo _lockObjSpeak = new SpeakInfo();
        private readonly SpeakInfo _lockObjAcknowledge = new SpeakInfo();

        private ISpeechEngine SpeechEngine;

        private ISpeechEngine SpeechEngineNPC;
        private ISpeechEngine SpeechEngineSpeak;
        private ISpeechEngine SpeechEngineAcknowledge;

        private bool updateSpeech;

        private void InitializeSynthesizerNPC(String voice)
        {
            
            SpeechEngineNPC = SpeechEngineFactory.Create();
            SpeechEngineNPC.Initialize(voice, 75); //comboBox1.SelectedValue.ToString(), 75);
            

        }

        private void InitializeSynthesizerSpeak(String voice)
        {
                SpeechEngineSpeak = SpeechEngineFactory.Create();
                //SpeechEngineSpeak.Initialize(comboBox2.SelectedValue.ToString(), 75);
                SpeechEngineSpeak.Initialize(voice, 75);

        }

        private void InitializeSynthesizerAcknowledge(String voice)
        {
                SpeechEngineAcknowledge = SpeechEngineFactory.Create();
            //SpeechEngineAcknowledge.Initialize(comboBox3.SelectedValue.ToString(), 75);
               SpeechEngineAcknowledge.Initialize(voice, 75);

        }


        private void NPCThread()
        {
            Boolean continuar = true;
            while (continuar)
            {
                lock (_lockObjNPC)
                {
                    Monitor.Wait(_lockObjNPC);

                    String ToSpeak = _lockObjNPC.Statement;

                    if (ToSpeak == "EndThread")
                    {
                        continuar = false;
                    }
                    else
                    {
                        SpeechEngineNPC.Speak(ToSpeak);
                    }


                }

            }

        }

        private void SpeakThread()
        {
            Boolean continuar = true;
            while (continuar)
            {
                lock (_lockObjSpeak)
                {
                    Monitor.Wait(_lockObjSpeak);

                    String ToSpeak = _lockObjSpeak.Statement;
                    if (ToSpeak == "EndThread")
                    {
                        continuar = false;
                    }
                    else
                    {
                        SpeechEngineSpeak.Speak(ToSpeak);
                    }

                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FaccionObjetivo = txtFaccion.Text;
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeSynthesizerNPC(comboBox1.SelectedItem.ToString());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeSynthesizerSpeak(comboBox2.SelectedItem.ToString());
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeSynthesizerAcknowledge(comboBox3.SelectedItem.ToString());
        }
        
        private void cbCsharp_CheckedChanged(object sender, EventArgs e)
        {
            SaveEvents = cbCsharp.Checked;
        }

        private void AcknowledgeThread()
        {
            Boolean continuar = true;
            while (continuar)
            {
                lock (_lockObjAcknowledge)
                {
                    Monitor.Wait(_lockObjAcknowledge);

                    String ToSpeak = "Recibido comandante, " + _lockObjAcknowledge.Statement;
                    if (ToSpeak == "EndThread")
                    {
                        continuar = false;
                    }
                    else
                    {
                        SpeechEngineAcknowledge.Speak(ToSpeak);
                    }
                }

            }

        }


    }

    class SpeakInfo
    {
        public String Statement { get; set; }

        public bool NPC { get; set; }

        public bool acknowledge { get; set; }
    }

    /*
    class MFDRefresh
    {
        private Form1 _form;

        public MFDRefresh(Form1 form)
        {
            _form = form;
        }

        public void Display(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;

            _form.DisplayPage();
        }
    }
*/
    /*
    class MarqueeChecker
    {
        private int invokeCount;
        private string line;
        private int maxlength;
        private int pageno;

        private System.IntPtr device;
        private int lineno;
        private DirectOutputCSharpWrapper.DirectOutput directoutput;

        public MarqueeChecker(int _maxlength, string _line, int _pageno, int _lineno, DirectOutput _directouput, System.IntPtr _device)
        {
            invokeCount = 0;
            this.line = _line;
            this.maxlength = _maxlength;
            this.pageno = _pageno;
            this.directoutput = _directouput;
            this.device = _device;
            this.lineno = _lineno;
         }

        // This method is called by the timer delegate.
        public void Display(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;

            string toshow = line;

            if (invokeCount == 0)
            {
                this.directoutput.SetString(device, pageno, lineno, toshow);
                invokeCount++;
                return;
            }

            if (line.Length > maxlength)
            {
                int startpos = invokeCount;

                if (line.Length >= startpos + maxlength)
                {
                    toshow = line.Substring(invokeCount, maxlength);
                } else
                {
                    if (invokeCount < line.Length)
                        toshow = line.Substring(invokeCount);
                    
                }

                Console.WriteLine($"{line} {startpos} {line.Length} {invokeCount} {toshow}");


            }
            try
            {
                this.directoutput.SetString(device, pageno, lineno, toshow);
            }
            catch(Exception ex)
            {

            }
            

            invokeCount++;
            if (invokeCount == line.Length) invokeCount = 0;

            
        }
    }*/


    public class Commodity
    {
        public String name { get; set; }
        public String value { get; set; }
    }


    public class JsonToCsharpInput
    {
        public string input { get; set; }
        public string operationid { get; set; }
        public JsonToCsharpSettings settings { get; set; }
    }

    public class JsonToCsharpSettings
    {
        public string UsePascalCase { get; set; }
        public string UseFields { get; set; }
        public string AlwaysUseNullables { get; set; }
        public string UseJsonAttributes { get; set; }
        public string NullValueHandlingIgnore { get; set; }
        public string UseJsonPropertyName { get; set; }
        public string ImmutableClasses { get; set; }
        public string RecordTypes { get; set; }
        public string NoSettersForCollections { get; set; }
    }

    public static class ObjectHelpers {
public static String ToSafeString(this object o)
    {
        return o == null ? "" : o.ToString();
    }

        }


    public class Counters
    {
        public int Combat { get; set; }
        public int Faction { get; set; }
        public int Total { get; set; }
        public int Merits { get; set; }
    }

    public enum PageTypeMFD
    {
        None = 0,
        Combat = 1
    }


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


}

