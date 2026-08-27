using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "FSDJump").
    /// </summary>
    public class FSDJumpHandler : JournalHandler<JournalFSDJump>
    {
        private readonly ICopilotState _state;
        private readonly ILedWriter _led;

        public FSDJumpHandler(ICopilotState state, ILedWriter led)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _led = led ?? throw new ArgumentNullException(nameof(led));
        }

        public override string EventName => "FSDJump";

        public override Task HandleAsync(JournalFSDJump journal, CancellationToken cancellationToken)
        {
            _state.StarSystem = journal.StarSystem;
            _led.OnArrival();
            return Task.CompletedTask;
        }
    }
}
