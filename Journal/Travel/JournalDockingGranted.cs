using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T22:25:23Z", "event":"DockingGranted", "LandingPad":3, "MarketID":3224440576, "StationName":"Henderson's Inheritance", "StationType":"Outpost" }
public class JournalDockingGranted : JournalBase
    {
        
        
        public int LandingPad { get; set; }
        public Int64 MarketID { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
    }


}