using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"CreateSuitLoadout","SuitID":4293000001,"SuitName":"Maverick","SuitMods":["suit_extra_ammo"],"LoadoutID":4293000001,"LoadoutName":"exp001","Modules":[{"SlotName":"PrimaryWeapon1","ModuleName":"manticore_tormentor","SuitModuleID":4293000001,"Class":5,"WeaponMods":["weapon_advanced_scope"]}]}
        public class JournalCreateSuitLoadoutModule
    {
        public string SlotName { get; set; }
        public string ModuleName { get; set; }
        public long SuitModuleID { get; set; }
        public int Class { get; set; }
        public List<string> WeaponMods { get; set; }
    }

    public class JournalCreateSuitLoadout : JournalBase
    {
        public long SuitID { get; set; }
        public string SuitName { get; set; }
        public List<string> SuitMods { get; set; }
        public long LoadoutID { get; set; }
        public string LoadoutName { get; set; }
        public List<JournalCreateSuitLoadoutModule> Modules { get; set; }
    }

}