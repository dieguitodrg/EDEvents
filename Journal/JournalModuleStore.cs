using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-08T23:09:20Z", "event":"ModuleStore", "MarketID":3709160704, "Slot":"LargeHardpoint3", "StoredItem":"$hpt_multicannon_gimbal_medium_name;", "StoredItem_Localised":"Multicañón", "Ship":"anaconda", "ShipID":26, "Hot":false, "EngineerModifications":"Weapon_Overcharged", "Level":5, "Quality":1.000000 }
public class JournalModuleStore : JournalBase
    {
        
        
        public Int64 MarketID { get; set; }
        public string Slot { get; set; }
        public string StoredItem { get; set; }
        public string StoredItem_Localised { get; set; }
        public string Ship { get; set; }
        public int ShipID { get; set; }
        public bool Hot { get; set; }
        public string EngineerModifications { get; set; }
        public int Level { get; set; }
        public double Quality { get; set; }
    }


}