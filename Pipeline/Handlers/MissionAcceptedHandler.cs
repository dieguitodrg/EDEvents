using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "MissionAccepted").
    /// </summary>
    public class MissionAcceptedHandler : JournalHandler<JournalMissionAccepted>
    {
        private readonly ICopilotState _state;

        public MissionAcceptedHandler(ICopilotState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "MissionAccepted";

        public override Task HandleAsync(JournalMissionAccepted journal, CancellationToken cancellationToken)
        {
            long mid = journal.MissionID;

            if (!_state.MissionAccepted.ContainsKey(mid.ToString()))
            {
                _state.AddMissionAccepted(mid.ToString(), journal);
            }
            return Task.CompletedTask;
        }
    }
}
