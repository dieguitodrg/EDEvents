using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"MassModuleStore", "MarketID":3229696256, "Ship":"krait_mkii", "Ship_Localised":"Krait Mk II", "ShipId":7, "Items":[ { "Slot":"MediumHardpoint1", "Name":"hpt_multicannon_gimbal_medium", "Name_Localised":"Multi-Cannon", "Hot":false, "EngineerModifications":"Multicannon_HighCapacity", "Level":3, "Quality":0.8 } ] }
        public class JournalMassModuleStoreItem
    {
        public string Slot { get; set; }
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public bool Hot { get; set; }
        public string EngineerModifications { get; set; }
        public int Level { get; set; }
        public double Quality { get; set; }
    }

    public class JournalMassModuleStore : JournalBase
    {
        public long MarketID { get; set; }
        public string Ship { get; set; }
        public string Ship_Localised { get; set; }
        public int ShipId { get; set; }
        public List<JournalMassModuleStoreItem> Items { get; set; }
    }

}