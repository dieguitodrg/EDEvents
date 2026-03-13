using Microsoft.CognitiveServices.Speech;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;

using Windows.Media.SpeechSynthesis;


namespace EDCrew.Speech
{
    public interface ISpeechEngine
    {
        // Inicializa el motor con una voz y volumen.
        void Initialize(string voiceName, int volume);

        // Pronuncia texto simple.
        void Speak(string text);

        string[] GetAvailableVoices();
    }

    public class SystemSpeechEngine : ISpeechEngine
    {
        private System.Speech.Synthesis.SpeechSynthesizer synthesizer;

        public void Initialize(string voiceName, int volume)
        {
            if (synthesizer == null)
                synthesizer = new System.Speech.Synthesis.SpeechSynthesizer();

            synthesizer.SelectVoice(voiceName);
            synthesizer.Volume = volume;
            synthesizer.SetOutputToDefaultAudioDevice();

        }

        public void Speak(string text)
        {
            synthesizer?.Speak(text);
        }

        public string[] GetAvailableVoices()
        {
            if (synthesizer == null)
                synthesizer = new System.Speech.Synthesis.SpeechSynthesizer();

            return synthesizer.GetInstalledVoices()
                              .Select(v => v.VoiceInfo.Name)
                              .ToArray();
        }
    }

    public class NeuralSpeechEngine : ISpeechEngine
    {
        private Microsoft.CognitiveServices.Speech.SpeechSynthesizer synthesizer;
        private string subscriptionKey;
        private string serviceRegion;

        public NeuralSpeechEngine(string key, string region)
        {
            subscriptionKey = key;
            serviceRegion = region;
        }
        public void Initialize(string voiceName, int volume)
        {
            // Configuración con tu clave y región de Azure
            var config = SpeechConfig.FromSubscription(subscriptionKey, serviceRegion);

            // Selección de voz neural
            config.SpeechSynthesisVoiceName = voiceName;

            // El volumen se controla vía SSML, aquí lo dejamos fijo
            // pero podrías encapsularlo en Speak si lo necesitas

            synthesizer = new Microsoft.CognitiveServices.Speech.SpeechSynthesizer(config);

        }

        public void Speak(string text)
        {
            if (synthesizer == null)
                throw new InvalidOperationException("NeuralSpeechEngine no inicializado.");

            // Llamada asíncrona al motor neural
            var result = synthesizer.SpeakTextAsync(text).Result;

            if (result.Reason != ResultReason.SynthesizingAudioCompleted)
            {
                Console.WriteLine($"Error en síntesis: {result.Reason}");
            }
        }

        public string[] GetAvailableVoices()
        {
            // Consulta al endpoint REST de Azure Speech
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                var url = $"https://{serviceRegion}.tts.speech.microsoft.com/cognitiveservices/voices/list";

                var response = client.GetAsync(url).Result;
                var json = response.Content.ReadAsStringAsync().Result;

                var voices = JArray.Parse(json);
                return voices.Select(v => v["Name"].ToString()).ToArray();
            }
        }
    }


public class ModernSpeechEngine : ISpeechEngine
    {
        private Windows.Media.SpeechSynthesis.SpeechSynthesizer synthesizer;
        private MediaPlayer player;

        public void Initialize(string voiceName, int volume)
        {
            synthesizer = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            player = new MediaPlayer();

            // Selección de voz (si está instalada en el sistema)
            var voice = Windows.Media.SpeechSynthesis.SpeechSynthesizer.AllVoices
                .FirstOrDefault(v => v.DisplayName == voiceName);

            if (voice != null)
                synthesizer.Voice = voice;

            player.Volume = volume / 100.0;

        }

        public async void Speak(string text)
        {
            var stream = await synthesizer.SynthesizeTextToStreamAsync(text);
            player.Source = MediaSource.CreateFromStream(stream, stream.ContentType);
            player.Play();
        }

        public string[] GetAvailableVoices()
        {
            return Windows.Media.SpeechSynthesis.SpeechSynthesizer.AllVoices
                                    .Select(v => v.DisplayName)
                                    .ToArray();
        }
    }

    public static class SpeechEngineFactory
    {
        public static ISpeechEngine Create()
        {
            try
            {
                // Intentar ModernSpeechEngine (Windows.Media)
                var modernEngine = new ModernSpeechEngine();
                var voices = modernEngine.GetAvailableVoices();

                if (voices != null && voices.Length > 0)
                {
                    return modernEngine;
                }
            }
            catch
            {
                // Si falla, seguimos al siguiente
            }

            try
            {
                // Intentar SystemSpeechEngine (legacy)
                var systemEngine = new SystemSpeechEngine();
                var voices = systemEngine.GetAvailableVoices();

                if (voices != null && voices.Length > 0)
                {
                    return systemEngine;
                }
            }
            catch
            {
                // Si también falla, devolvemos null
            }

            return null; // No se encontró motor disponible
        }
    }

}
