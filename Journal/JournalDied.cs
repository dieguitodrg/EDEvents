using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"Died","Killers":[{"Name":"Cmdr HRC1","Ship":"Vulture","Rank":"Competent"},{"Name":"Cmdr HRC2","Ship":"Python","Rank":"Master"}]}
        public class JournalDiedKiller
    {
        public string Name { get; set; }
        public string Ship { get; set; }
        public string Rank { get; set; }
    }

    public class JournalDied : JournalBase
    {
        public List<JournalDiedKiller> Killers { get; set; }
    }

}