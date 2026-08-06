using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"BackpackChange", "Added":[ { "Name":"healthpack", "Name_Localised":"Medkit", "OwnerID":0, "MissionID":382319128, "Count":2, "Type":"Consumable" }, { "Name":"graphene", "OwnerID":0, "Count":3, "Type":"Component" } ] }
        public class JournalBackpackChangeAdded
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int OwnerID { get; set; }
        public Int64 MissionID { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
    }

    public class JournalBackpackChange : JournalBase
    {
        public List<JournalBackpackChangeAdded> Added { get; set; }
    }

}