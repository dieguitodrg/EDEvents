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
        private readonly ICopilotState _state;

        public LoadGameHandler(ICopilotOutput output, ICopilotState state)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "LoadGame";

        public override Task HandleAsync(JournalLoadGame journal, CancellationToken cancellationToken)
        {
            _state.Commander = journal.Commander;
            _state.ShipIdent = journal.ShipIdent;

            string header = $"{DateTime.Now} ------- Juego Nuevo -------";

            _output.AddPrompt(header, PromptType.Message);
            _output.AddPrompt(header, PromptType.Combat);
            _output.AddPrompt(header, PromptType.Inventory);

            return Task.CompletedTask;
        }
    }
}
