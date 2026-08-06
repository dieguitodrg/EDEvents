using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"CarrierTradeOrder", "CarrierID":3700005632, "BlackMarket":false, "Commodity":"mineraloil", "Commodity_Localised":"Mineral Oil", "PurchaseOrder":70, "Price":228 }
        public class JournalCarrierTradeOrder : JournalBase
    {
        public long CarrierID { get; set; }
        public bool BlackMarket { get; set; }
        public string Commodity { get; set; }
        public string Commodity_Localised { get; set; }
        public int PurchaseOrder { get; set; }
        public int Price { get; set; }
    }

}