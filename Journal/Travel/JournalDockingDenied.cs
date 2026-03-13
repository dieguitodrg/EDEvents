using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T22:25:03Z", "event":"DockingDenied", "Reason":"NoSpace", "MarketID":3224440576, "StationName":"Henderson's Inheritance", "StationType":"Outpost" }
public class JournalDockingDenied : JournalBase
    {
        
        
        public string Reason { get; set; }
        public Int64 MarketID { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
    }


}