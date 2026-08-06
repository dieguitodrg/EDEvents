using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"PowerplayDefect", "FromPower":"Zachary Hudson", "ToPower":"Li Yong-Rui" }
        public class JournalPowerplayDefect : JournalBase
    {
        public string FromPower { get; set; }
        public string ToPower { get; set; }
    }

}