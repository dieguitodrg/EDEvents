using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"CarrierNameChanged", "CarrierID":3700005632, "Callsign":"L14-X1J", "Name":"Spirula" }
        public class JournalCarrierNameChanged : JournalBase
    {
        public long CarrierID { get; set; }
        public string Callsign { get; set; }
        public string Name { get; set; }
    }

}