using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "PowerplayMerits").
    /// </summary>
    public class PowerplayMeritsHandler : JournalHandler<JournalPowerplayMerits>
    {
        private readonly ICopilotState _state;

        public PowerplayMeritsHandler(ICopilotState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "PowerplayMerits";

        public override Task HandleAsync(JournalPowerplayMerits journal, CancellationToken cancellationToken)
        {
            _state.JournalPowerMerits = journal;
            _state.Counters.Merits += journal.MeritsGained;
            return Task.CompletedTask;
        }
    }
}
