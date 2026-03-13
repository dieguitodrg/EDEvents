using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-08T23:10:55Z", "event":"ModuleRetrieve", "MarketID":3709160704, "Slot":"SmallHardpoint1", "RetrievedItem":"$hpt_multicannon_gimbal_small_name;", "RetrievedItem_Localised":"Multicañón", "Ship":"eagle", "ShipID":1, "Hot":false, "EngineerModifications":"Weapon_Overcharged", "Level":5, "Quality":1.000000 }
public class JournalModuleRetrieve : JournalBase
    {
        
        
        public Int64 MarketID { get; set; }
        public string Slot { get; set; }
        public string RetrievedItem { get; set; }
        public string RetrievedItem_Localised { get; set; }
        public string Ship { get; set; }
        public int ShipID { get; set; }
        public bool Hot { get; set; }
        public string EngineerModifications { get; set; }
        public int Level { get; set; }
        public double Quality { get; set; }
    }


}