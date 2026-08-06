using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"DockingTimeout","StationName":"Jameson Memorial","StationType":"Orbis","MarketID":3229696256}
        public class JournalDockingTimeout : JournalBase
    {
        public string StationName { get; set; }
        public string StationType { get; set; }
        public long MarketID { get; set; }
    }

}