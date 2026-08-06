using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"Liftoff", "Latitude":63.468872, "Longitude":157.59938, "StarSystem":"Asellus Primus", "SystemAddress":3657533690578, "Body":"Asellus Primus 3", "BodyID":5, "OnStation":false, "OnPlanet":true, "NearestDestination":"Odyssey Landing", "PlayerControlled":true }
        public class JournalLiftoff : JournalBase
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string StarSystem { get; set; }
        public long SystemAddress { get; set; }
        public string Body { get; set; }
        public int BodyID { get; set; }
        public bool OnStation { get; set; }
        public bool OnPlanet { get; set; }
        public string NearestDestination { get; set; }
        public bool PlayerControlled { get; set; }
    }

}