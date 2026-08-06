using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"PowerplayLeave", "Power":"Li Yong-Rui" }
        public class JournalPowerplayLeave : JournalBase
    {
        public string Power { get; set; }
    }

}