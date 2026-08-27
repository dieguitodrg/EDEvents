using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "ColonisationConstructionDepot").
    /// </summary>
    public class ColonisationConstructionDepotHandler : JournalHandler<JournalColonisationConstructionDepot>
    {
        private readonly ICopilotState _state;

        public ColonisationConstructionDepotHandler(ICopilotState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "ColonisationConstructionDepot";

        public override Task HandleAsync(JournalColonisationConstructionDepot journal, CancellationToken cancellationToken)
        {
            _state.ColonisationProgress[journal.MarketID] = journal;

            if (journal.ConstructionProgress >= 1.0)
            {
                _state.ColonisationProgress.Remove(journal.MarketID);
            }

            return Task.CompletedTask;
        }
    }
}
