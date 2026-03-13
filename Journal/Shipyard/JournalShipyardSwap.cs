using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T21:27:49Z", "event":"ShipyardSwap", "ShipType":"python", "ShipID":14, "StoreOldShip":"Type6", "StoreShipID":20, "MarketID":3709160704 }
    public class JournalShipyardSwap : JournalBase
    {
        
        
        public string ShipType { get; set; }
        public int ShipID { get; set; }
        public string StoreOldShip { get; set; }
        public int StoreShipID { get; set; }
        public Int64 MarketID { get; set; }
    }


}