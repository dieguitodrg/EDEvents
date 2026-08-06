using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"RenameSuitLoadout", "SuitID":1702914472756487, "SuitName":"TacticalSuit_Class3", "SuitName_Localised":"Dominator Suit", "LoadoutID":4293480479, "LoadoutName":"Assault Kit" }
        public class JournalRenameSuitLoadout : JournalBase
    {
        public long SuitID { get; set; }
        public string SuitName { get; set; }
        public string SuitName_Localised { get; set; }
        public long LoadoutID { get; set; }
        public string LoadoutName { get; set; }
    }

}