using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"ModuleSwap", "MarketID":3229696256, "FromSlot":"MediumHardpoint1", "ToSlot":"MediumHardpoint2", "FromItem":"hpt_pulselaser_fixed_medium", "FromItem_Localised":"Pulse Laser", "ToItem":"hpt_multicannon_gimbal_medium", "ToItem_Localised":"Multi-Cannon", "Ship":"cobramkiii", "Ship_Localised":"Cobra Mk III", "ShipID":1 }
        public class JournalModuleSwap : JournalBase
    {
        public long MarketID { get; set; }
        public string FromSlot { get; set; }
        public string ToSlot { get; set; }
        public string FromItem { get; set; }
        public string FromItem_Localised { get; set; }
        public string ToItem { get; set; }
        public string ToItem_Localised { get; set; }
        public string Ship { get; set; }
        public string Ship_Localised { get; set; }
        public int ShipID { get; set; }
    }

}