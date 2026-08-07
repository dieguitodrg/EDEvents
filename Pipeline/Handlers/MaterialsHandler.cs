using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "Materials").
    /// </summary>
    public class MaterialsHandler : JournalHandler<JournalMaterials>
    {
        private readonly ICopilotState _state;

        public MaterialsHandler(ICopilotState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "Materials";

        public override Task HandleAsync(JournalMaterials journal, CancellationToken cancellationToken)
        {
            _state.CategoriasInventario.Inventario.Raw = journal.Raw;
            _state.CategoriasInventario.Inventario.Encoded = journal.Encoded;
            _state.CategoriasInventario.Inventario.Manufactured = journal.Manufactured;
            return Task.CompletedTask;
        }
    }
}
