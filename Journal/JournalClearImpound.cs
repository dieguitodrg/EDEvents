using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"ClearImpound","ShipType":"asp","ShipType_Localised":"Asp Explorer","ShipID":10,"ShipMarketID":128833431,"MarketID":3229696256}
        public class JournalClearImpound : JournalBase
    {
        public string ShipType { get; set; }
        public string ShipType_Localised { get; set; }
        public int ShipID { get; set; }
        public int ShipMarketID { get; set; }
        public long MarketID { get; set; }
    }

}