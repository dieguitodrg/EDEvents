using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"UpgradeWeapon", "Name":"wpn_m_assaultrifle_laser_fauto", "Name_Localised":"TK Aphelion", "Class":2, "SuitModuleID":1681611765701131, "Cost":0, "Resources":[ { "Name":"weaponschematic", "Name_Localised":"Weapon Schematic", "Count":1 }, { "Name":"ionisedgas", "Name_Localised":"Ionised Gas", "Count":1 } ] }
        public class JournalUpgradeWeaponResource
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Count { get; set; }
    }

    public class JournalUpgradeWeapon : JournalBase
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Class { get; set; }
        public long SuitModuleID { get; set; }
        public int Cost { get; set; }
        public List<JournalUpgradeWeaponResource> Resources { get; set; }
    }

}