using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "PowerplayRank").
    /// </summary>
    public class PowerplayRankHandler : JournalHandler<JournalPowerplayRank>
    {
        private readonly ICopilotState _state;

        public PowerplayRankHandler(ICopilotState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "PowerplayRank";

        public override Task HandleAsync(JournalPowerplayRank journal, CancellationToken cancellationToken)
        {
            _state.JournalPowerRank = journal;
            return Task.CompletedTask;
        }
    }
}
