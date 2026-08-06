using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"EngineerApply", "Engineer":"Liz Ryder", "EngineerID":300080, "Blueprint":"Engine_Rapid", "BlueprintID":128673657, "Level":1, "Module":"int_engine_size2_class3", "Module_Localised":"Thrusters", "Ingredients":[ { "Name":"consumerelectronics", "Name_Localised":"Consumer Electronics", "Count":1 } ], "ApplyExperimentalEffect":"Drive_Distributors" }
        public class JournalEngineerApplyIngredient
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Count { get; set; }
    }

    public class JournalEngineerApply : JournalBase
    {
        public string Engineer { get; set; }
        public int EngineerID { get; set; }
        public string Blueprint { get; set; }
        public int BlueprintID { get; set; }
        public int Level { get; set; }
        public string Module { get; set; }
        public string Module_Localised { get; set; }
        public List<JournalEngineerApplyIngredient> Ingredients { get; set; }
        public string ApplyExperimentalEffect { get; set; }
    }

}