using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-10-26T23:03:45Z", "event":"ChangeCrewRole", "Role":"Idle", "Telepresence":true }
        public class JournalChangeCrewRole : JournalBase
    {
        public string Role { get; set; }
        public bool Telepresence { get; set; }
    }

}