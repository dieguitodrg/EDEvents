using System;
using System.Collections.Generic;

namespace EDCrew.Speech
{
    public interface IVoiceRecognition : IDisposable
    {
        event Action<Comandos> CommandRecognized;

        IReadOnlyList<Comandos> Commands { get; }

        IReadOnlyList<string> Choices { get; }

        void Start();

        void Stop();
    }
}
