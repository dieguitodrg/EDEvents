using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"RebootRepair", "Modules":[ "MainEngines", "TinyHardpoint1" ] }
        public class JournalRebootRepair : JournalBase
    {
        public List<string> Modules { get; set; }
    }

}