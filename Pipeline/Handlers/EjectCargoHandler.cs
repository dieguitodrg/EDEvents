using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "EjectCargo").
    /// </summary>
    public class EjectCargoHandler : JournalHandler<JournalEjectCargo>
    {
        private readonly ICopilotOutput _output;

        public EjectCargoHandler(ICopilotOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public override string EventName => "EjectCargo";

        public override Task HandleAsync(JournalEjectCargo journal, CancellationToken cancellationToken)
        {
            String message = "Mercancía " + journal.Count + " " + (journal.Type_Localised == null ? journal.Type : journal.Type_Localised) + " " + (journal.Abandoned ? "abandonada" : "eyectada");
            _output.AddPrompt(message, PromptType.Inventory);
            _output.Speak(message, false);
            return Task.CompletedTask;
        }
    }
}
