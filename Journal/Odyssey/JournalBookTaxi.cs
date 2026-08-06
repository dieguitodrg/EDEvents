using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"BookTaxi", "Cost":23200, "DestinationSystem":"Opala", "DestinationLocation":"Onizuka's Hold", "Retreat":false }
        public class JournalBookTaxi : JournalBase
    {
        public int Cost { get; set; }
        public string DestinationSystem { get; set; }
        public string DestinationLocation { get; set; }
        public bool Retreat { get; set; }
    }

}