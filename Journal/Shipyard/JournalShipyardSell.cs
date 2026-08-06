using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"ShipyardSell", "MarketID":3229696256, "ShipType":"asp", "SellShipID":8, "ShipPrice":6194500, "System":"Shinrarta Dezhra" }
        public class JournalShipyardSell : JournalBase
    {
        public long MarketID { get; set; }
        public string ShipType { get; set; }
        public int SellShipID { get; set; }
        public int ShipPrice { get; set; }
        public string System { get; set; }
    }

}