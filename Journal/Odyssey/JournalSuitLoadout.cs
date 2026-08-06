using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-10-26T11:40:07Z", "event":"SuitLoadout", "SuitID":1765237294370370, "SuitName":"utilitysuit_class3", "SuitName_Localised":"$UtilitySuit_Class1_Name;", "SuitMods":[ "suit_quieterfootsteps" ], "LoadoutID":4293000003, "LoadoutName":"Equipamiento 1", "Modules":[ { "SlotName":"PrimaryWeapon1", "SuitModuleID":1762654462503999, "ModuleName":"wpn_m_assaultrifle_kinetic_fauto", "ModuleName_Localised":"Karma AR-50", "Class":1, "WeaponMods":[  ] }, { "SlotName":"SecondaryWeapon", "SuitModuleID":1762654451208029, "ModuleName":"wpn_s_pistol_laser_sauto", "ModuleName_Localised":"TK Zenith", "Class":1, "WeaponMods":[  ] } ] }
        public class JournalSuitLoadoutModule
    {
        public string SlotName { get; set; }
        public object SuitModuleID { get; set; }
        public string ModuleName { get; set; }
        public string ModuleName_Localised { get; set; }
        public int Class { get; set; }
        public List<object> WeaponMods { get; set; }
    }

    public class JournalSuitLoadout : JournalBase
    {
        public long SuitID { get; set; }
        public string SuitName { get; set; }
        public string SuitName_Localised { get; set; }
        public List<string> SuitMods { get; set; }
        public long LoadoutID { get; set; }
        public string LoadoutName { get; set; }
        public List<JournalSuitLoadoutModule> Modules { get; set; }
    }

}