using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-10-26T11:42:18Z", "event":"Embark", "SRV":false, "Taxi":false, "Multicrew":false, "ID":9, "StarSystem":"Cartoi", "SystemAddress":4207289471706, "Body":"Cartoi ABC 3 a", "BodyID":22, "OnStation":false, "OnPlanet":true }
        public class JournalEmbark : JournalBase
    {
        public bool SRV { get; set; }
        public bool Taxi { get; set; }
        public bool Multicrew { get; set; }
        public int ID { get; set; }
        public string StarSystem { get; set; }
        public long SystemAddress { get; set; }
        public string Body { get; set; }
        public int BodyID { get; set; }
        public bool OnStation { get; set; }
        public bool OnPlanet { get; set; }
    }

}