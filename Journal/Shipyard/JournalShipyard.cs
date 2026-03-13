using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T21:27:37Z", "event":"Shipyard", "MarketID":3709160704, "StationName":"T9Q-35M", "StarSystem":"Matire" }
public class JournalShipyard : JournalBase
    {
        
        
        public Int64 MarketID { get; set; }
        public string StationName { get; set; }
        public string StarSystem { get; set; }
    }


}