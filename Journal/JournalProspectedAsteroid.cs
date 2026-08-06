using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"ProspectedAsteroid", "Materials":[ { "Name":"Platinum", "Proportion":1.0 }, { "Name":"Palladium", "Proportion":0.8 }, { "Name":"Silver", "Proportion":0.7 } ], "Content":"High", "MotherlodeMaterial":"Platinum", "Remaining":100 }
        public class JournalProspectedAsteroidMaterial
    {
        public string Name { get; set; }
        public double Proportion { get; set; }
    }

    public class JournalProspectedAsteroid : JournalBase
    {
        public List<JournalProspectedAsteroidMaterial> Materials { get; set; }
        public string Content { get; set; }
        public string MotherlodeMaterial { get; set; }
        public int Remaining { get; set; }
    }

}