using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"CarrierDecommission", "CarrierID":3700005632, "ScrapRefund":2437500000, "ScrapTime":1767225600 }
        public class JournalCarrierDecommission : JournalBase
    {
        public long CarrierID { get; set; }
        public long ScrapRefund { get; set; }
        public int ScrapTime { get; set; }
    }

}