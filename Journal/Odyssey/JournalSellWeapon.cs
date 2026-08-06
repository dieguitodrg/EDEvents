using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"SellWeapon", "Name":"wpn_s_pistol_kinetic_sauto", "Name_Localised":"Karma P-15", "Price":1211, "SuitModuleID":1680931394104342, "Class":1, "WeaponMods":[ { "Name":"MagazineSize", "Value":1.0 } ] }
        public class JournalSellWeapon : JournalBase
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Price { get; set; }
        public long SuitModuleID { get; set; }
        public int Class { get; set; }
        public List<JournalSellWeaponWeaponMod> WeaponMods { get; set; }
    }

    public class JournalSellWeaponWeaponMod
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }

}