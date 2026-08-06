using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"EngineerLegacyConvert", "Slot":"Slot03_Size3", "Module":"int_dronecontrol_collection_size3_class5", "Module_Localised":"Collector Limpet Controller", "Engineer":"Ram Tah", "EngineerID":300110, "BlueprintID":128731526, "BlueprintName":"Misc_LightWeight", "Level":1, "Quality":0.955, "IsPreview":false, "Modifiers":[ { "Label":"Mass", "Value":4.436, "OriginalValue":8, "LessIsGood":true } ] }
        public class JournalEngineerLegacyConvertModifier
    {
        public string Label { get; set; }
        public double Value { get; set; }
        public int OriginalValue { get; set; }
        public bool LessIsGood { get; set; }
    }

    public class JournalEngineerLegacyConvert : JournalBase
    {
        public string Slot { get; set; }
        public string Module { get; set; }
        public string Module_Localised { get; set; }
        public string Engineer { get; set; }
        public int EngineerID { get; set; }
        public int BlueprintID { get; set; }
        public string BlueprintName { get; set; }
        public int Level { get; set; }
        public double Quality { get; set; }
        public bool IsPreview { get; set; }
        public List<JournalEngineerLegacyConvertModifier> Modifiers { get; set; }
    }

}