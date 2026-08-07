using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "Loadout").
    /// </summary>
    public class LoadoutHandler : JournalHandler<JournalLoadout>
    {
        private readonly ICopilotOutput _output;
        private readonly ICopilotState _state;

        public LoadoutHandler(ICopilotOutput output, ICopilotState state)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "Loadout";

        public override Task HandleAsync(JournalLoadout journal, CancellationToken cancellationToken)
        {
            if (_state.ShipName == journal.ShipName) return Task.CompletedTask;

            _state.ShipName = journal.ShipName;
            _state.ShipIdent = journal.ShipIdent;
            _state.ShipId = journal.ShipID;
            _state.Ship = journal.Ship;

            if (journal.StarSystem != null)
            {
                _state.StarSystem = journal.StarSystem;
            }

            String messagelog = $"Bienvenido a {_state.ShipIdent} {_state.ShipName}";
            String messagespeak = $"Bienvenido a {_output.Nato(_state.ShipIdent)} {_state.ShipName} Comandante";
            _output.Speak(messagespeak);
            _output.AddPrompt(messagelog, PromptType.Navigation);

            return Task.CompletedTask;
        }
    }
}
