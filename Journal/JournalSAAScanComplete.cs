using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"SAAScanComplete", "SystemAddress":1144348739947, "BodyName":"Eranin 5", "BodyID":5, "ProbesUsed":6, "EfficiencyTarget":9 }
        public class JournalSAAScanComplete : JournalBase
    {
        public long SystemAddress { get; set; }
        public string BodyName { get; set; }
        public int BodyID { get; set; }
        public int ProbesUsed { get; set; }
        public int EfficiencyTarget { get; set; }
    }

}