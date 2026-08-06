using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"LoadoutEquipModule", "SuitID":1702914472756487, "SuitName":"Dominator Suit", "SlotName":"Suit_ModSlot1", "LoadoutID":4293000001, "LoadoutName":"Combat 01", "ModuleName":"wpn_s_pistol_kinetic_sauto", "ModuleName_Localised":"Karma P-15", "SuitModuleID":1681611765701131, "Class":3, "WeaponMods":[ "Stability", "Reload Speed" ] }
        public class JournalLoadoutEquipModule : JournalBase
    {
        public long SuitID { get; set; }
        public string SuitName { get; set; }
        public string SlotName { get; set; }
        public long LoadoutID { get; set; }
        public string LoadoutName { get; set; }
        public string ModuleName { get; set; }
        public string ModuleName_Localised { get; set; }
        public long SuitModuleID { get; set; }
        public int Class { get; set; }
        public List<string> WeaponMods { get; set; }
    }

}