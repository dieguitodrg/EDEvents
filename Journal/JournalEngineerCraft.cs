using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-07T21:55:55Z", "event":"EngineerCraft", "Slot":"MainEngines", "Module":"int_engine_size3_class5", "Ingredients":[ { "Name":"consumerfirmware", "Name_Localised":"Firmware de consumo modificado", "Count":1 }, { "Name":"selenium", "Name_Localised":"Selenio", "Count":1 }, { "Name":"configurablecomponents", "Name_Localised":"Componentes configurables", "Count":1 } ], "Engineer":"Professor Palin", "EngineerID":300220, "BlueprintID":128673658, "BlueprintName":"Engine_Dirty", "Level":4, "Quality":0.911400, "Modifiers":[ { "Label":"Integrity", "Value":61.599998, "OriginalValue":70.000000, "LessIsGood":0 }, { "Label":"PowerDraw", "Value":4.092000, "OriginalValue":3.720000, "LessIsGood":1 }, { "Label":"EngineOptimalMass", "Value":108.000000, "OriginalValue":120.000000, "LessIsGood":0 }, { "Label":"EngineOptPerformance", "Value":132.379990, "OriginalValue":100.000000, "LessIsGood":0 }, { "Label":"EngineHeatRate", "Value":1.950000, "OriginalValue":1.300000, "LessIsGood":1 } ] }
public class IngredientType
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Count { get; set; }
    }

    public class ModifierType
    {
        public string Label { get; set; }
        public double Value { get; set; }
        public double OriginalValue { get; set; }
        public int LessIsGood { get; set; }
    }

    public class JournalEngineerCraft : JournalBase
    {
        
        
        public string Slot { get; set; }
        public string Module { get; set; }
        public List<IngredientType> Ingredients { get; set; }
        public string Engineer { get; set; }
        public int EngineerID { get; set; }
        public int BlueprintID { get; set; }
        public string BlueprintName { get; set; }
        public int Level { get; set; }
        public double Quality { get; set; }
        public List<ModifierType> Modifiers { get; set; }
    }


}