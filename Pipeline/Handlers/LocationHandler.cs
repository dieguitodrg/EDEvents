using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "Location").
    /// </summary>
    public class LocationHandler : JournalHandler<JournalLocation>
    {
        private readonly ICopilotState _state;

        public LocationHandler(ICopilotState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "Location";

        public override Task HandleAsync(JournalLocation journal, CancellationToken cancellationToken)
        {
            _state.StarSystem = journal.StarSystem;
            _state.SystemAddress = journal.SystemAddress;
            return Task.CompletedTask;
        }
    }
}
