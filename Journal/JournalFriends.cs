using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-10-26T23:00:26Z", "event":"Friends", "Status":"Online", "Name":"KOSKERG" }
        public class JournalFriends : JournalBase
    {
        public string Status { get; set; }
        public string Name { get; set; }
    }

}