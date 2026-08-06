using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"CrewHire","Name":"Margaret Parrish","CrewID":1282544907413002138,"Faction":"The Dark Wheel","Cost":15000,"CombatRank":1}
        public class JournalCrewHire : JournalBase
    {
        public string Name { get; set; }
        public long CrewID { get; set; }
        public string Faction { get; set; }
        public int Cost { get; set; }
        public int CombatRank { get; set; }
    }

}