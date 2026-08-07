using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "ScanOrganic").
    /// </summary>
    public class ScanOrganicHandler : JournalHandler<JournalScanOrganic>
    {
        private readonly ICopilotState _state;

        public ScanOrganicHandler(ICopilotState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "ScanOrganic";

        public override Task HandleAsync(JournalScanOrganic journal, CancellationToken cancellationToken)
        {
            String systemaddress = journal.SystemAddress.ToString();
            String body = journal.BodyID.ToString();
            String specieslocalised = journal.Species_Localised;

            bool sscankey = false;
            switch (journal.ScanType)
            {
                case "Analyse":
                    sscankey = true;
                    break;
                default:
                    break;
            }

            _state.AddDictionaryScanned(systemaddress, body, specieslocalised, sscankey);

            return Task.CompletedTask;
        }
    }
}
