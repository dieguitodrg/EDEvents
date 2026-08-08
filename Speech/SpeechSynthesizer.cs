using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EDCrew.Speech
{
    public enum SpeechChannel { Npc, Speak, Acknowledge }

    public interface ISpeechSynthesizer : IDisposable
    {
        List<string> GetAvailableVoices();

        void Initialize(SpeechChannel channel, string voiceName);

        void Speak(string phrase, bool npc);

        void Acknowledge(string phrase);

        void Start();

        void Stop();
    }

    public class SpeechSynthesizer : ISpeechSynthesizer
    {
        private readonly ISpeechEngine[] _engines = new ISpeechEngine[3];
        private readonly object[] _locks = new object[] { new object(), new object(), new object() };
        private readonly string[] _statements = new string[3];
        private readonly Thread[] _threads = new Thread[3];
        private bool _started;

        public List<string> GetAvailableVoices()
        {
            ISpeechEngine engine = SpeechEngineFactory.Create();
            if (engine == null) return new List<string>();

            return engine.GetAvailableVoices().ToList();
        }

        public void Initialize(SpeechChannel channel, string voiceName)
        {
            _engines[(int)channel] = SpeechEngineFactory.Create();
            _engines[(int)channel].Initialize(voiceName, 75);
        }

        public void Start()
        {
            if (_started) return;

            _threads[(int)SpeechChannel.Npc] = new Thread(() => Worker(SpeechChannel.Npc));
            _threads[(int)SpeechChannel.Speak] = new Thread(() => Worker(SpeechChannel.Speak));
            _threads[(int)SpeechChannel.Acknowledge] = new Thread(() => Worker(SpeechChannel.Acknowledge));

            _threads[(int)SpeechChannel.Npc].Start();
            _threads[(int)SpeechChannel.Speak].Start();
            _threads[(int)SpeechChannel.Acknowledge].Start();

            _started = true;
        }

        public void Speak(string phrase, bool npc)
        {
            Pulse(npc ? SpeechChannel.Npc : SpeechChannel.Speak, phrase);
        }

        public void Acknowledge(string phrase)
        {
            Pulse(SpeechChannel.Acknowledge, phrase);
        }

        public void Stop()
        {
            foreach (SpeechChannel channel in Enum.GetValues(typeof(SpeechChannel)))
            {
                Pulse(channel, "EndThread");
            }

            foreach (Thread thread in _threads)
            {
                if (thread != null) thread.Join();
            }

            _started = false;
        }

        public void Dispose()
        {
            Stop();
        }

        private void Pulse(SpeechChannel channel, string statement)
        {
            int i = (int)channel;

            lock (_locks[i])
            {
                _statements[i] = statement;
                Monitor.Pulse(_locks[i]);
            }
        }

        private void Worker(SpeechChannel channel)
        {
            int i = (int)channel;
            bool continuar = true;

            while (continuar)
            {
                lock (_locks[i])
                {
                    Monitor.Wait(_locks[i]);

                    string toSpeak = _statements[i];

                    if (toSpeak == "EndThread")
                    {
                        continuar = false;
                    }
                    else
                    {
                        if (channel == SpeechChannel.Acknowledge)
                        {
                            toSpeak = "Recibido comandante, " + toSpeak;
                        }

                        _engines[i]?.Speak(toSpeak);
                    }
                }
            }
        }
    }
}
