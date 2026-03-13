using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T22:23:36Z", "event":"SupercruiseExit", "Taxi":false, "Multicrew":false, "StarSystem":"Matire", "SystemAddress":672833021345, "Body":"Henderson's Inheritance", "BodyID":8, "BodyType":"Station" }
public class JournalSupercruiseExit : JournalBase
    {
        
        
        public bool Taxi { get; set; }
        public bool Multicrew { get; set; }
        public string StarSystem { get; set; }
        public Int64 SystemAddress { get; set; }
        public string Body { get; set; }
        public int BodyID { get; set; }
        public string BodyType { get; set; }
    }


}