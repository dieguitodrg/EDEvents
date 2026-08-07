using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "MissionAbandoned").
    /// </summary>
    public class MissionAbandonedHandler : JournalHandler<JournalMissionAbandoned>
    {
        private readonly ICopilotState _state;

        public MissionAbandonedHandler(ICopilotState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "MissionAbandoned";

        public override Task HandleAsync(JournalMissionAbandoned journal, CancellationToken cancellationToken)
        {
            long mid = journal.MissionID;

            if (_state.MissionAccepted.ContainsKey(mid.ToString()))
            {
                _state.RemoveMissionAccepted(mid.ToString());
            }
            return Task.CompletedTask;
        }
    }
}
