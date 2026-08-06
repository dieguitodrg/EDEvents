using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"CrewAssign","Name":"Dannie Koller","CrewID":1282544907413002138,"Role":"Active"}
        public class JournalCrewAssign : JournalBase
    {
        public string Name { get; set; }
        public long CrewID { get; set; }
        public string Role { get; set; }
    }

}