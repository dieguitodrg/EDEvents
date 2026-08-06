using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "PowerplayCollect").
    /// </summary>
    public class PowerplayCollectHandler : JournalHandler<JournalPowerplayCollect>
    {
        private readonly ICopilotOutput _output;

        public PowerplayCollectHandler(ICopilotOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public override string EventName => "PowerplayCollect";

        public override Task HandleAsync(JournalPowerplayCollect journal, CancellationToken cancellationToken)
        {
            _output.AddPrompt($"{journal.timestamp}: Recogidos {journal.Count} {journal.Type_Localised} para {journal.Power}", PromptType.Merits);
            return Task.CompletedTask;
        }
    }
}
