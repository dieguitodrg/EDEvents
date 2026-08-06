using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "DockingGranted").
    /// </summary>
    public class DockingGrantedHandler : JournalHandler<JournalDockingGranted>
    {
        private readonly ICopilotOutput _output;

        public DockingGrantedHandler(ICopilotOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public override string EventName => "DockingGranted";

        public override Task HandleAsync(JournalDockingGranted journal, CancellationToken cancellationToken)
        {
            String message = $"Control de vuelo de {journal.StationName.Replace("$EXT_PANEL_ColonisationShip;", "Nave de Colonización del Sistema")} ha otorgado el permiso de atraque. Plataforma {journal.LandingPad}";
            _output.Speak(message, false);
            _output.AddPrompt(message, PromptType.Navigation);
            return Task.CompletedTask;
        }
    }
}
