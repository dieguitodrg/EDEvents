using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "MaterialTrade").
    /// </summary>
    public class MaterialTradeHandler : JournalHandler<JournalMaterialTrade>
    {
        private readonly ICopilotOutput _output;
        private readonly ICopilotState _state;

        public MaterialTradeHandler(ICopilotOutput output, ICopilotState state)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "MaterialTrade";

        public override Task HandleAsync(JournalMaterialTrade journal, CancellationToken cancellationToken)
        {
            String material_paid = journal.Paid.Material_Localised != null ? journal.Paid.Material_Localised : journal.Paid.Material;
            String material_received = journal.Received.Material_Localised != null ? journal.Received.Material_Localised : journal.Received.Material;

            int inventario_paid = _state.CategoriasInventario.Suma(material_paid, journal.Paid.Quantity * -1);
            int inventario_received = _state.CategoriasInventario.Suma(material_paid, journal.Received.Quantity);

            int delta_paid = _state.CategoriasInventario.Deltas[material_paid];
            int delta_received = _state.CategoriasInventario.Deltas[material_received];

            int maximo_paid = _state.CategoriasInventario.Maximo(material_paid);
            int maximo_received = _state.CategoriasInventario.Maximo(material_received);

            _output.AddPrompt($"Cambio {journal.Paid.Quantity} {material_paid} ({inventario_paid}/{maximo_paid}) por {journal.Received.Quantity} {material_received} ({inventario_received}/{maximo_received})", PromptType.Inventory);
            return Task.CompletedTask;
        }
    }
}
