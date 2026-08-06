using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"CarrierFinance", "CarrierID":3700005632, "TaxRate":5, "CarrierBalance":3278186, "ReserveBalance":0, "AvailableBalance":475108, "ReservePercent":0 }
        public class JournalCarrierFinance : JournalBase
    {
        public long CarrierID { get; set; }
        public int TaxRate { get; set; }
        public int CarrierBalance { get; set; }
        public int ReserveBalance { get; set; }
        public int AvailableBalance { get; set; }
        public int ReservePercent { get; set; }
    }

}