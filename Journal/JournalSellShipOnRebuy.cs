using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"SellShipOnRebuy", "ShipType":"Dolphin", "ShipType_Localised":"Dolphin", "System":"Shinrarta Dezhra", "SellShipId":4, "ShipPrice":4110183 }
        public class JournalSellShipOnRebuy : JournalBase
    {
        public string ShipType { get; set; }
        public string ShipType_Localised { get; set; }
        public string System { get; set; }
        public int SellShipId { get; set; }
        public int ShipPrice { get; set; }
    }

}