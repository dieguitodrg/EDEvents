using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Speech.Recognition;

namespace EDCrew.Speech
{
    public class VoiceRecognitionService : IVoiceRecognition
    {
        private SpeechRecognitionEngine _engine;
        private readonly List<Comandos> _commands;
        private readonly List<string> _choices;
        private bool _started;

        public event Action<Comandos> CommandRecognized;

        public IReadOnlyList<Comandos> Commands
        {
            get { return _commands; }
        }

        public IReadOnlyList<string> Choices
        {
            get { return _choices; }
        }

        public VoiceRecognitionService()
            : this(Path.Combine(Path.GetDirectoryName(typeof(VoiceRecognitionService).Assembly.Location), "Gramatica.json"))
        {
        }

        public VoiceRecognitionService(string grammarFilePath)
        {
            List<Comandos> comandos = ComandosLoader.Load(grammarFilePath);
            _commands = ComandosLoader.Expand(comandos);
            _choices = ComandosLoader.BuildChoices(_commands);
        }

        public void Start()
        {
            if (_started) return;

            _engine = new SpeechRecognitionEngine(new CultureInfo("es-ES"));
            _engine.RequestRecognizerUpdate();

            Choices exChoices = new Choices();
            exChoices.Add(_choices.ToArray());

            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(exChoices);

            Grammar g = new Grammar(grammarBuilder);
            _engine.LoadGrammar(g);
            _engine.RequestRecognizerUpdate();
            _engine.SetInputToDefaultAudioDevice();
            _engine.RecognizeAsync(RecognizeMode.Multiple);

            _engine.SpeechRecognized +=
                      new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

            _started = true;
        }

        public void Stop()
        {
            if (_engine != null)
            {
                _engine.RecognizeAsyncStop();
            }
        }

        public void Dispose()
        {
            if (_engine != null)
            {
                _engine.SpeechRecognized -=
                          new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
                _engine.Dispose();
                _engine = null;
            }
            _started = false;
        }

        // Handle the SpeechRecognized event.
        void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine(e.Result.Text);
            Comandos comando = (from Comandos c in _commands where c.command == e.Result.Text select c).First();
            CommandRecognized?.Invoke(comando);
        }
    }
}
