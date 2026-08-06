using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"DropShipDeploy", "StarSystem":"Indaol", "SystemAddress":3657533690578, "Body":"Indaol A 2", "BodyID":7, "OnStation":false, "OnPlanet":true }
        public class JournalDropShipDeploy : JournalBase
    {
        public string StarSystem { get; set; }
        public long SystemAddress { get; set; }
        public string Body { get; set; }
        public int BodyID { get; set; }
        public bool OnStation { get; set; }
        public bool OnPlanet { get; set; }
    }

}