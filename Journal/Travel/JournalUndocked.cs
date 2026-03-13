using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T21:14:34Z", "event":"Undocked", "StationName":"Stackpole Market", "StationType":"Orbis", "MarketID":3224507136, "Taxi":false, "Multicrew":false }
public class JournalUndocked : JournalBase
    {
        public string StationName { get; set; }
        public string StationType { get; set; }
        public Int64 MarketID { get; set; }
        public bool Taxi { get; set; }
        public bool Multicrew { get; set; }
    }


}