using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"JetConeDamage", "Module":"int_hyperdrive_size5_class5", "Module_Localised":"Frame Shift Drive" }
        public class JournalJetConeDamage : JournalBase
    {
        public string Module { get; set; }
        public string Module_Localised { get; set; }
    }

}