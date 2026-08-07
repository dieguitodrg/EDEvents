using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "EngineerCraft").
    /// </summary>
    public class EngineerCraftHandler : JournalHandler<JournalEngineerCraft>
    {
        private readonly ICopilotOutput _output;
        private readonly ICopilotState _state;

        public EngineerCraftHandler(ICopilotOutput output, ICopilotState state)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "EngineerCraft";

        public override Task HandleAsync(JournalEngineerCraft journal, CancellationToken cancellationToken)
        {
            String message = "Material consumido ";
            foreach (IngredientType ingredient in journal.Ingredients)
            {
                String material = ingredient.Name_Localised != null ? ingredient.Name_Localised : ingredient.Name;
                int inventario = _state.CategoriasInventario.Suma(material, ingredient.Count * (-1));
                int maximo = _state.CategoriasInventario.Maximo(material);
                int delta = _state.CategoriasInventario.Deltas[material];
                message += $"{material} ({ingredient.Count}) {inventario}/{maximo} ";
            }
            _output.AddPrompt(message.TrimEnd(), PromptType.Inventory);
            return Task.CompletedTask;
        }
    }
}
