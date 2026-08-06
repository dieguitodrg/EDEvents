using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Primer handler migrado del switch de Form1 (case "LoadGame").
    /// </summary>
    public class LoadGameHandler : JournalHandler<JournalLoadGame>
    {
        private readonly ICopilotOutput _output;

        public LoadGameHandler(ICopilotOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public override string EventName => "LoadGame";

        public override Task HandleAsync(JournalLoadGame journal, CancellationToken cancellationToken)
        {
            string header = $"{DateTime.Now} ------- Juego Nuevo -------";

            _output.AddPrompt(header, PromptType.Message);
            _output.AddPrompt(header, PromptType.Combat);
            _output.AddPrompt(header, PromptType.Inventory);

            return Task.CompletedTask;
        }
    }
}
