using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"BuyWeapon", "Name":"Wpn_S_Pistol_Kinetic_SAuto", "Name_Localised":"KA15", "Price":1000, "SuitModuleID":1681611765701131, "Class":1, "WeaponMods":[ "weapon_mod_stability" ] }
        public class JournalBuyWeapon : JournalBase
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Price { get; set; }
        public long SuitModuleID { get; set; }
        public int Class { get; set; }
        public List<string> WeaponMods { get; set; }
    }

}