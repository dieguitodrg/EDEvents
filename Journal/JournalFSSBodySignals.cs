using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-08-06T12:00:00Z", "event":"FSSBodySignals", "BodyName":"Synuefe GT-H b43-1 1", "BodyID":1, "SystemAddress":223245345, "Signals":[ { "Type":"$SAA_SignalType_Biological;", "Type_Localised":"Biológico", "Count":3 } ] }
        public class JournalFSSBodySignals : JournalBase
    {
        public string BodyName { get; set; }
        public int BodyID { get; set; }
        public Int64 SystemAddress { get; set; }
        public List<JournalFSSBodySignalsSignal> Signals { get; set; }
    }

    public class JournalFSSBodySignalsSignal
    {
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public int Count { get; set; }
    }

}