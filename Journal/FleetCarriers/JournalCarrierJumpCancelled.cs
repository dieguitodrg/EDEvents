using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"CarrierJumpCancelled", "CarrierID":3700005632 }
        public class JournalCarrierJumpCancelled : JournalBase
    {
        public long CarrierID { get; set; }
    }

}