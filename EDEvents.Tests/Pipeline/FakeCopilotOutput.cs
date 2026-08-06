using System;
using System.Collections.Generic;
using EDCrew;
using EDCrew.Pipeline;

namespace EDCrew.Tests.Pipeline
{
    /// <summary>
    /// Doble de prueba de ICopilotOutput que registra las llamadas.
    /// </summary>
    public class FakeCopilotOutput : ICopilotOutput
    {
        public List<string> Prompts { get; } = new List<string>();
        public List<(string Text, bool Npc)> Spoken { get; } = new List<(string, bool)>();

        public void AddPrompt(string text, PromptType promptType)
        {
            Prompts.Add($"{promptType}|{text}");
        }

        public void Speak(string text, bool npc = false)
        {
            Spoken.Add((text, npc));
        }
    }
}
