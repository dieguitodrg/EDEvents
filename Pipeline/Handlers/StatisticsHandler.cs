using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "Statistics").
    /// </summary>
    public class StatisticsHandler : JournalHandler<JournalStatistics>
    {
        private readonly ICopilotState _state;

        public StatisticsHandler(ICopilotState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "Statistics";

        public override Task HandleAsync(JournalStatistics journal, CancellationToken cancellationToken)
        {
            _state.JournalStatistics = journal;
            return Task.CompletedTask;
        }
    }
}
