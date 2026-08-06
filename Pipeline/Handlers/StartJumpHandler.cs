using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "StartJump").
    /// </summary>
    public class StartJumpHandler : JournalHandler<JournalStartJump>
    {
        private readonly ICopilotOutput _output;

        public StartJumpHandler(ICopilotOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public override string EventName => "StartJump";

        public override Task HandleAsync(JournalStartJump journal, CancellationToken cancellationToken)
        {
            if (journal.JumpType == "Hyperspace")
            {
                string message = $"Saltando a {journal.StarSystem} clase espectral {journal.StarClass}";
                _output.AddPrompt(message, PromptType.Navigation);
                _output.Speak(message);
            }

            return Task.CompletedTask;
        }
    }
}
