using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T23:23:06Z", "event":"StartJump", "JumpType":"Hyperspace", "StarSystem":"Sol", "StarClass":"G", "Taxi":false }
public class JournalStartJump : JournalBase
    {
        public string JumpType { get; set; }
        public string StarSystem { get; set; }
        public string StarClass { get; set; }
        public bool Taxi { get; set; }
    }


}