using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-12-06T19:08:30Z", "event":"CrewMemberQuits", "Crew":"KOSKERG", "Telepresence":true }
        public class JournalCrewMemberQuits : JournalBase
    {
        public string Crew { get; set; }
        public bool Telepresence { get; set; }
    }

}