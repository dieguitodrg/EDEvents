using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"Touchdown", "PlayerControlled":true, "Latitude":10.503607, "Longitude":102.78981, "StarSystem":"Luhman 16", "SystemAddress":22960358574928, "Body":"Luhman 16 A 2", "BodyID":11, "OnStation":false, "OnPlanet":true, "NearestDestination":"Surface signal: Geological (9)" }
        public class JournalTouchdown : JournalBase
    {
        public bool PlayerControlled { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string StarSystem { get; set; }
        public long SystemAddress { get; set; }
        public string Body { get; set; }
        public int BodyID { get; set; }
        public bool OnStation { get; set; }
        public bool OnPlanet { get; set; }
        public string NearestDestination { get; set; }
    }

}