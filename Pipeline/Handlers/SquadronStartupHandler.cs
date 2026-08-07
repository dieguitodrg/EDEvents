using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "SquadronStartup").
    /// </summary>
    public class SquadronStartupHandler : JournalHandler<JournalSquadronStartup>
    {
        private readonly ICopilotState _state;

        public SquadronStartupHandler(ICopilotState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "SquadronStartup";

        public override Task HandleAsync(JournalSquadronStartup journal, CancellationToken cancellationToken)
        {
            _state.Squadron = journal;
            return Task.CompletedTask;
        }
    }
}
