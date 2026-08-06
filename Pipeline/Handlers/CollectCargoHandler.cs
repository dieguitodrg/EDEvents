using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "CollectCargo").
    /// </summary>
    public class CollectCargoHandler : JournalHandler<JournalCollectCargo>
    {
        private readonly ICopilotOutput _output;

        public CollectCargoHandler(ICopilotOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public override string EventName => "CollectCargo";

        public override Task HandleAsync(JournalCollectCargo journal, CancellationToken cancellationToken)
        {
            String message = "Mercancía " + (journal.Type_Localised == null ? journal.Type : journal.Type_Localised) + " " + (journal.Stolen ? "robada" : "recuperada");
            _output.AddPrompt(message, PromptType.Inventory);
            _output.Speak(message, false);
            return Task.CompletedTask;
        }
    }
}
