using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2025-01-01T01:24:27Z", "event":"LeaveBody", "StarSystem":"Ossito", "SystemAddress":3657533690578, "Body":"Ossito B 4", "BodyID":19 }
        public class JournalLeaveBody : JournalBase
    {
        public string StarSystem { get; set; }
        public long SystemAddress { get; set; }
        public string Body { get; set; }
        public int BodyID { get; set; }
    }

}