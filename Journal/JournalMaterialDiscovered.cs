using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"MaterialDiscovered", "Category":"Manufactured", "Name":"focuscrystals", "Name_Localised":"Focus Crystals", "DiscoveryNumber":3 }
        public class JournalMaterialDiscovered : JournalBase
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int DiscoveryNumber { get; set; }
    }

}