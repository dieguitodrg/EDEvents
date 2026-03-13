using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-07T23:22:04Z", "event":"ShipyardTransfer", "ShipType":"Independant_Trader", "ShipType_Localised":"Keelback", "ShipID":3, "System":"Pini", "ShipMarketID":3709160704, "Distance":23.857754, "TransferPrice":24846, "TransferTime":538, "MarketID":3224748032 }
public class JournalShipyardTransfer : JournalBase
    {
        
        
        public string ShipType { get; set; }
        public string ShipType_Localised { get; set; }
        public int ShipID { get; set; }
        public string System { get; set; }
        public Int64 ShipMarketID { get; set; }
        public double Distance { get; set; }
        public int TransferPrice { get; set; }
        public int TransferTime { get; set; }
        public Int64 MarketID { get; set; }
    }


}