using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"JetConeBoost", "BoostValue":1.7564 }
        public class JournalJetConeBoost : JournalBase
    {
        public double BoostValue { get; set; }
    }

}