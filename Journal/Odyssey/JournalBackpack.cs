using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-10-26T11:40:07Z", "event":"Backpack", "Items":[  ], "Components":[  ], "Consumables":[  ], "Data":[  ] }
        public class JournalBackpack : JournalBase
    {
        public List<object> Items { get; set; }
        public List<object> Components { get; set; }
        public List<object> Consumables { get; set; }
        public List<object> Data { get; set; }
    }

}