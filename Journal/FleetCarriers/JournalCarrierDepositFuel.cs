using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"CarrierDepositFuel", "CarrierID":3700005632, "Amount":45, "Total":112 }
        public class JournalCarrierDepositFuel : JournalBase
    {
        public long CarrierID { get; set; }
        public int Amount { get; set; }
        public int Total { get; set; }
    }

}