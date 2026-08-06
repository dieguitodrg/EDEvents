using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"SwitchSuitLoadout", "SuitID":1702914472756487, "SuitName":"utilitysuit_class1", "SuitName_Localised":"Maverick Suit", "SuitMods":[ "suit_quieterfootsteps", "suit_extraammo" ], "LoadoutID":4293000001, "LoadoutName":"Loadout Alpha", "Modules":[ { "SlotName":"PrimaryWeapon1", "SuitModuleID":1681611765701131, "ModuleName":"wpn_m_assaultrifle_laser_fauto", "ModuleName_Localised":"TK Aphelion", "Class":3, "WeaponMods":[ "weapon_audio_masking" ] }, { "SlotName":"SecondaryWeapon", "SuitModuleID":1681611765740017, "ModuleName":"wpn_s_pistol_laser_sauto", "ModuleName_Localised":"TK Zenith", "Class":2, "WeaponMods":[  ] } ] }
        public class JournalSwitchSuitLoadoutModule
    {
        public string SlotName { get; set; }
        public object SuitModuleID { get; set; }
        public string ModuleName { get; set; }
        public string ModuleName_Localised { get; set; }
        public int Class { get; set; }
        public List<string> WeaponMods { get; set; }
    }

    public class JournalSwitchSuitLoadout : JournalBase
    {
        public long SuitID { get; set; }
        public string SuitName { get; set; }
        public string SuitName_Localised { get; set; }
        public List<string> SuitMods { get; set; }
        public long LoadoutID { get; set; }
        public string LoadoutName { get; set; }
        public List<JournalSwitchSuitLoadoutModule> Modules { get; set; }
    }

}