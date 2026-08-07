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
            if (!_state.ColonisationProgress.ContainsKey(journal.MarketID))
            {
                _state.ColonisationProgress.Add(journal.MarketID, journal);
            }
            else
            {
                _state.ColonisationProgress[journal.MarketID] = journal;
            }
            return Task.CompletedTask;
        }
    }
}
