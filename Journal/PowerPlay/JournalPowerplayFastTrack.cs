using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"PowerplayFastTrack", "Power":"Aisling Duval", "Cost":100000 }
        public class JournalPowerplayFastTrack : JournalBase
    {
        public string Power { get; set; }
        public int Cost { get; set; }
    }

}