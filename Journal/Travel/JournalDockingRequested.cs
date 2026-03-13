using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T22:25:23Z", "event":"DockingRequested", "MarketID":3224440576, "StationName":"Henderson's Inheritance", "StationType":"Outpost", "LandingPads":{ "Small":2, "Medium":1, "Large":0 } }
public class LandingPads
    {
        public int Small { get; set; }
        public int Medium { get; set; }
        public int Large { get; set; }
    }

    public class JournalDockingRequested : JournalBase
    {
        
        
        public Int64 MarketID { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
        public LandingPads LandingPads { get; set; }
    }


}