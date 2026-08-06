using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"BookDropship", "Cost":32500, "DestinationSystem":"LTT 9455", "DestinationLocation":"Gamma High", "Retreat":false }
        public class JournalBookDropship : JournalBase
    {
        public int Cost { get; set; }
        public string DestinationSystem { get; set; }
        public string DestinationLocation { get; set; }
        public bool Retreat { get; set; }
    }

}