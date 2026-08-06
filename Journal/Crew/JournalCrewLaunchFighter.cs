using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"CrewLaunchFighter","Crew":"Cmdr Kestrel","ID":13,"Telepresence":true}
        public class JournalCrewLaunchFighter : JournalBase
    {
        public string Crew { get; set; }
        public int ID { get; set; }
        public bool Telepresence { get; set; }
    }

}