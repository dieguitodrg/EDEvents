using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"SAASignalsFound", "SystemAddress":5363877956440, "BodyName":"Hermitage 4 b", "BodyID":13, "Signals":[ { "Type":"Geological", "Type_Localised":"Geological", "Count":14 }, { "Type":"Biological", "Type_Localised":"Biological", "Count":5 } ], "Genuses":[ { "Genus":"Bacterium", "Genus_Localised":"Bacterium" }, { "Genus":"Stratum", "Genus_Localised":"Stratum" } ] }
        public class JournalSAASignalsFoundGenuse
    {
        public string Genus { get; set; }
        public string Genus_Localised { get; set; }
    }

    public class JournalSAASignalsFound : JournalBase
    {
        public long SystemAddress { get; set; }
        public string BodyName { get; set; }
        public int BodyID { get; set; }
        public List<JournalSAASignalsFoundSignal> Signals { get; set; }
        public List<JournalSAASignalsFoundGenuse> Genuses { get; set; }
    }

    public class JournalSAASignalsFoundSignal
    {
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public int Count { get; set; }
    }

}