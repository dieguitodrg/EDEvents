using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "ReceiveText").
    /// </summary>
    public class ReceiveTextHandler : JournalHandler<JournalReceiveText>
    {
        private readonly ICopilotOutput _output;
        private readonly ICopilotState _state;

        public ReceiveTextHandler(ICopilotOutput output, ICopilotState state)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "ReceiveText";

        public override Task HandleAsync(JournalReceiveText journal, CancellationToken cancellationToken)
        {
            if (!journal.Message.Contains("$COMMS_entered"))
            {
                String from = journal.From_Localised != null ? journal.From_Localised : journal.From;
                String _message = journal.Message_Localised != null ? journal.Message_Localised : journal.Message;
                String message = String.Format("Mensaje Recibido de {0}: {1}", from.Replace("$Name_AX_Military;", "Piloto AX").Replace("$EXT_PANEL_ColonisationShip;", "Nave de Colonización del Sistema"), _message);

                bool checkspeak = true;
                checkspeak = (journal.Channel != "npc" || _state.SpeakNpc) && (journal.Channel != "starsystem" || _state.SpeakSystem);

                if (checkspeak)
                {
                    _output.Speak(message, true);
                }

                _output.AddPrompt(message, PromptType.Message);
            }

            return Task.CompletedTask;
        }
    }
}
