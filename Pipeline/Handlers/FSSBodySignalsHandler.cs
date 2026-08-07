using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "FSSBodySignals").
    /// </summary>
    public class FSSBodySignalsHandler : JournalHandler<JournalFSSBodySignals>
    {
        private readonly ICopilotState _state;

        public FSSBodySignalsHandler(ICopilotState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "FSSBodySignals";

        public override Task HandleAsync(JournalFSSBodySignals journal, CancellationToken cancellationToken)
        {
            if (_state.OldSystemAddress != journal.SystemAddress)
            {
                _state.BodySignals.Clear();
            }

            _state.OldSystemAddress = journal.SystemAddress;
            _state.SystemAddress = journal.SystemAddress;
            _state.BodySignals.Add(journal);

            return Task.CompletedTask;
        }
    }
}
