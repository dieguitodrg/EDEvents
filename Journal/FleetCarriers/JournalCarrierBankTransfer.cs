using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"CarrierBankTransfer", "CarrierID":3700005632, "Deposit":80000, "PlayerBalance":717339604128, "CarrierBalance":3020010 }
        public class JournalCarrierBankTransfer : JournalBase
    {
        public long CarrierID { get; set; }
        public int Deposit { get; set; }
        public long PlayerBalance { get; set; }
        public int CarrierBalance { get; set; }
    }

}