using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"ShipyardBuy", "MarketID":3229696256, "ShipType":"anaconda", "ShipPrice":146969451, "StoreOldShip":"krait_mkii", "StoreShipID":9, "SellOldShip":"type-6", "SellShipID":4, "SellPrice":4483000 }
        public class JournalShipyardBuy : JournalBase
    {
        public long MarketID { get; set; }
        public string ShipType { get; set; }
        public int ShipPrice { get; set; }
        public string StoreOldShip { get; set; }
        public int StoreShipID { get; set; }
        public string SellOldShip { get; set; }
        public int SellShipID { get; set; }
        public int SellPrice { get; set; }
    }

}