using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "MaterialCollected").
    /// </summary>
    public class MaterialCollectedHandler : JournalHandler<JournalMaterialCollected>
    {
        private readonly ICopilotOutput _output;
        private readonly ICopilotState _state;

        public MaterialCollectedHandler(ICopilotOutput output, ICopilotState state)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "MaterialCollected";

        public override Task HandleAsync(JournalMaterialCollected journal, CancellationToken cancellationToken)
        {
            String material = journal.Name_Localised != null ? journal.Name_Localised : journal.Name;
            int inventario = _state.CategoriasInventario.Suma(material, journal.Count);
            int maximo = _state.CategoriasInventario.Maximo(material);
            int delta = _state.CategoriasInventario.Deltas[material];
            string message = $"Material recogido {material} ({journal.Count}) {inventario}/{maximo}";
            _output.AddPrompt(message, PromptType.Inventory);
            _output.Speak(message);
            return Task.CompletedTask;
        }
    }
}
