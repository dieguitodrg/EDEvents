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

        public FSDJumpHandler(ICopilotState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "FSDJump";

        public override Task HandleAsync(JournalFSDJump journal, CancellationToken cancellationToken)
        {
            _state.StarSystem = journal.StarSystem;
            return Task.CompletedTask;
        }
    }
}
