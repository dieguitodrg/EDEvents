using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "Undocked").
    /// </summary>
    public class UndockedHandler : JournalHandler<JournalUndocked>
    {
        private readonly ICopilotState _state;

        public UndockedHandler(ICopilotState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "Undocked";

        public override Task HandleAsync(JournalUndocked journal, CancellationToken cancellationToken)
        {
            _state.StationName = "";
            return Task.CompletedTask;
        }
    }
}
