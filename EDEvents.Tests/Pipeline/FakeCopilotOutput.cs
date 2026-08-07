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
        public List<(string Command, bool Voice)> Commands { get; } = new List<(string, bool)>();
        public int DisplayPageCalls { get; set; }

        public void AddPrompt(string text, PromptType promptType)
        {
            Prompts.Add($"{promptType}|{text}");
        }

        public void Speak(string text, bool npc = false)
        {
            Spoken.Add((text, npc));
        }

        public void DisplayPage()
        {
            DisplayPageCalls++;
        }

        public void EjecutarComando(string command, bool voice = false)
        {
            Commands.Add((command, voice));
        }

        public string Nato(string text)
        {
            return "NATO-" + text;
        }
    }
}
