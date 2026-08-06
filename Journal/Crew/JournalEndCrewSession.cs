using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"EndCrewSession", "OnCrime":false, "Telepresence":true }
        public class JournalEndCrewSession : JournalBase
    {
        public bool OnCrime { get; set; }
        public bool Telepresence { get; set; }
    }

}