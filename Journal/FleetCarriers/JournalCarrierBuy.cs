using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"CarrierBuy", "CarrierID":3700029440, "BoughtAtMarket":3221301504, "Location":"Kakmbutan", "SystemAddress":3549513615723, "Price":4875000000, "Variant":"CarrierDockB", "Callsign":"P07-V3L" }
        public class JournalCarrierBuy : JournalBase
    {
        public long CarrierID { get; set; }
        public long BoughtAtMarket { get; set; }
        public string Location { get; set; }
        public long SystemAddress { get; set; }
        public long Price { get; set; }
        public string Variant { get; set; }
        public string Callsign { get; set; }
    }

}