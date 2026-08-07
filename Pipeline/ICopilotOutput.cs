using System;

namespace EDCrew.Pipeline
{
    /// <summary>
    /// Abstracción de las salidas del copiloto (pantalla de log y voz).
    /// Reemplaza el acceso directo a Form1 desde los handlers del journal.
    /// </summary>
    public interface ICopilotOutput
    {
        void AddPrompt(string text, PromptType promptType);

        void Speak(string text, bool npc = false);

        void DisplayPage();

        void EjecutarComando(string command, bool voice = false);

        string Nato(string text);
    }
}
