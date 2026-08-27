using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "ShipTargeted").
    /// </summary>
    public class ShipTargetedHandler : JournalHandler<JournalShipTargeted>
    {
        private readonly ICopilotOutput _output;
        private readonly ICopilotState _state;

        public ShipTargetedHandler(ICopilotOutput output, ICopilotState state)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "ShipTargeted";

        public override Task HandleAsync(JournalShipTargeted journal, CancellationToken cancellationToken)
        {
            if (journal.ScanStage < 3) _state.EventScannedShip = null;
            if (journal.ScanStage == 3)
            {
                //if (_state.EventScannedShip == null && journal.Bounty != 0)
                //{
                    _state.Bountyprompt = $"Recompensa de {journal.Bounty} créditos";
                //}

                _state.StatusScanned = true;

                _state.EventScannedShip = journal;

                //if (_state.FetchingSubsystem)
                //{
                //    if (journal.Subsystem_Localised != null)
                //    {
                //        System.IO.File.AppendAllText("c:\\temp\\subsystems.txt", journal.Subsystem_Localised + "\r\n");
                //    }
                //}

                if (_state.FetchingSubsystem && journal.Subsystem_Localised == _state.Subsystem)
                {
                    _state.FetchingSubsystem = false;
                }
                else
                {
                    if (_state.FetchingSubsystem)
                    {
                        _output.EjecutarComando("Anterior Subsistema", false);
                    }
                }

                _output.DisplayPage();
            }
            else
            {
                _state.StatusScanned = false;
                _state.FetchingSubsystem = false;
            }

            return Task.CompletedTask;
        }
    }
}
