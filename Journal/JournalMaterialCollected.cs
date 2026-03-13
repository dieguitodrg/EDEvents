using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T23:39:52Z", "event":"MaterialCollected", "Category":"Encoded", "Name":"shieldsoakanalysis", "Name_Localised":"Análisis de absorción de escudos inconsistente", "Count":3 }
public class JournalMaterialCollected : JournalBase
    {
        
        
        public string Category { get; set; }
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Count { get; set; }
    }


}