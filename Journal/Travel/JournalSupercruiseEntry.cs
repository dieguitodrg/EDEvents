using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T23:12:06Z", "event":"SupercruiseEntry", "Taxi":false, "Multicrew":false, "StarSystem":"HIP 18713", "SystemAddress":1659778337131 }
public class JournalSupercruiseEntry : JournalBase
    {
        
        
        public bool Taxi { get; set; }
        public bool Multicrew { get; set; }
        public string StarSystem { get; set; }
        public Int64 SystemAddress { get; set; }
    }


}