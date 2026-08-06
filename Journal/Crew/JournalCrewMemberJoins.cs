using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"CrewMemberJoins","Crew":"Cmdr Kestrel","Telepresence":true}
        public class JournalCrewMemberJoins : JournalBase
    {
        public string Crew { get; set; }
        public bool Telepresence { get; set; }
    }

}