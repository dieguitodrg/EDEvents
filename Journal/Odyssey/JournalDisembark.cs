using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"Disembark","SRV":false,"Taxi":false,"Multicrew":false,"ID":36,"StarSystem":"Shinrarta Dezhra","SystemAddress":3932277478106,"Body":"Jameson Memorial","BodyID":4,"OnStation":true,"OnPlanet":false,"StationName":"Jameson Memorial","StationType":"Orbis","MarketID":3229696256}
        public class JournalDisembark : JournalBase
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
        public string StationName { get; set; }
        public string StationType { get; set; }
        public long MarketID { get; set; }
    }

}