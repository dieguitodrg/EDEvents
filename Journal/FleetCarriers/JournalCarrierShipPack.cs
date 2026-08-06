using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"CarrierShipPack", "CarrierID":3700005632, "Operation":"BuyPack", "PackTheme":"Zorgon Peterson - Cargo", "PackTier":1, "Cost":1668880 }
        public class JournalCarrierShipPack : JournalBase
    {
        public long CarrierID { get; set; }
        public string Operation { get; set; }
        public string PackTheme { get; set; }
        public int PackTier { get; set; }
        public int Cost { get; set; }
    }

}