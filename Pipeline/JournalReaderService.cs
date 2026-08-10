using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EDCrew.Pipeline
{
    /// <summary>
    /// Abstracción de las salidas y estado que el lector de journals necesita
    /// del copiloto. Form1 lo implementa; los tests podrán usar dobles.
    /// </summary>
    public interface IJournalReaderHost : ICopilotOutput
    {
        Status Status { get; set; }

        Status OldStatus { get; set; }

        string Destination { get; set; }

        bool SaveEvents { get; }

        void Acknowledge(string text);

        Task<string> EventCSharp(string className, string eventJson);
    }

    /// <summary>
    /// Vigila la carpeta de journals de Elite Dangerous (FileSystemWatcher),
    /// lee `Journal*.log` y `Status.json`, deserializa los eventos y los
    /// despacha al pipeline tipado. Reemplaza ProcessFile/ProcessFile2 de Form1.
    /// </summary>
    public class JournalReaderService
    {
        private readonly IJournalReaderHost _host;
        private readonly JournalEventDispatcher _dispatcher;
        private readonly string _path;

        private FileSystemWatcher _fs;
        private Boolean _processing;
        private int _lastEventLine = -1;
        private string _oldDestination = "";

        public JournalReaderService(IJournalReaderHost host, JournalEventDispatcher dispatcher, string journalDirectory)
        {
            _host = host;
            _dispatcher = dispatcher;
            _path = journalDirectory;
        }

        public void Start()
        {
            ProcessLatestJournal();

            _fs = new FileSystemWatcher(_path);
            _fs.Created += Fs_Created;
            _fs.Changed += Fs_Changed;
            _fs.Deleted += Fs_Deleted;
            _fs.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            if (_fs != null)
            {
                _fs.EnableRaisingEvents = false;
                _fs.Dispose();
                _fs = null;
            }
        }

        private void ProcessLatestJournal()
        {
            string pattern = "*Journal*.log";
            var dirInfo = new DirectoryInfo(_path);
            var file = (from f in dirInfo.GetFiles(pattern) orderby f.LastWriteTime descending select f.FullName).First();

            ProcessFile(file);
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

            _fs.EnableRaisingEvents = true;

        }

        void Fs_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                if (e.FullPath.Contains("ournal"))
                    _lastEventLine = -1;
                ProcessFile(e.FullPath);
            }
            catch (Exception ex)
            {

            }

            _fs.EnableRaisingEvents = true;



        }

        void Fs_Deleted(object sender, FileSystemEventArgs e)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.FullPath);
            Console.ForegroundColor = old;


        }

        async void ProcessFile(string filepath)
        {
            if (_processing) return;
            _processing = true;
            if (filepath.Contains("Status.json"))
            {
                try
                {
                    List<String> Lines = readAllLines(filepath);

                    _host.OldStatus = _host.Status;

                    try
                    {
                        _host.Status = JsonConvert.DeserializeObject<Status>(Lines.Last());
                    }
                    catch (Exception exj)
                    {
                        _host.Status = System.Text.Json.JsonSerializer.Deserialize<Status>(Lines.Last());
                    }

                    if (_host.Status.Destination != null)
                    {
                        String _destination = _host.Status.Destination.Name_Localised != null ? _host.Status.Destination.Name_Localised.Replace("$EXT_PANEL_ColonisationShip;", "Nave de Colonización del Sistema") : _host.Status.Destination.Name.Replace("$EXT_PANEL_ColonisationShip;", "Nave de Colonización del Sistema");
                        if (_oldDestination != _destination)
                        {
                            _host.Destination = _destination;
                            String message = "Destino: " + _destination;
                            _host.AddPrompt(message, PromptType.Navigation);
                            _host.Acknowledge(message);
                        }

                        _oldDestination = _destination;
                    }
                    else
                    {
                        if (_oldDestination != "")
                        {
                            String message = "La nave ha llegado al destino " + _oldDestination;
                            _host.AddPrompt(message, PromptType.Navigation);
                            _host.Speak(message);

                            _oldDestination = "";
                            _host.Destination = "";
                        }
                    }

                    try
                    {
                        if (_host.OldStatus != null && _host.Status != null && !_host.OldStatus.Landed && _host.Status.Landed)
                        {
                            _host.Speak("La nave ha aterrizado");
                        }
                    }
                    catch (Exception ccex)
                    {

                    }

                    try
                    {
                        if (_host.OldStatus != null && _host.Status != null && !_host.OldStatus.Docked && _host.Status.Docked)
                        {
                            _host.Speak("Nave asegurada en la plataforma");
                        }
                    }
                    catch (Exception ccex)
                    {

                    }

                    _host.DisplayPage();

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

                    for (int i = _lastEventLine + 1; i < Lines.Count(); i++)
                    {
                        if (i > _lastEventLine)
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
                                if (_dispatcher.HasHandler(journal.@event))
                                {
                                    try
                                    {
                                        JournalBase journalbase = Reader.ReadJson(s);
                                        await _dispatcher.DispatchAsync(journalbase);
                                    }
                                    catch (Exception exn)
                                    {
                                        Console.WriteLine($"Error despachando {journal.@event}: {exn.Message}");
                                    }
                                }
                                if (_host.SaveEvents)
                                {
                                    _host.EventCSharp(journal.@event, s);
                                }

                                _host.AddPrompt($"{i}/{_lastEventLine} Nuevo Evento {journal.@event} {journal.timestamp}", PromptType.Event);
                                _lastEventLine = i;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine(s);
                                Console.WriteLine(ex.StackTrace);
                                _host.AddPrompt(ex.Message, PromptType.Exceptions);

                            }
                            finally
                            {

                            }

                        }


                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.ToString());
                }

            }
            _processing = false;
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
    }
}
