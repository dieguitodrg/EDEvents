using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "Docked").
    /// </summary>
    public class DockedHandler : JournalHandler<JournalDocked>
    {
        private readonly ICopilotState _state;

        public DockedHandler(ICopilotState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "Docked";

        public override Task HandleAsync(JournalDocked journal, CancellationToken cancellationToken)
        {
            _state.StationName = journal.StationName;
            _state.StarSystem = journal.StarSystem;
            return Task.CompletedTask;
        }
    }
}
