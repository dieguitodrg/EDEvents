using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T22:42:10Z", "event":"Market", "MarketID":3224427008, "StationName":"Struve Prospect", "StationType":"Outpost", "StarSystem":"HIP 16114" }
public class JournalMarket : JournalBase
    {
        
        
        public Int64 MarketID { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
        public string StarSystem { get; set; }
    }


}