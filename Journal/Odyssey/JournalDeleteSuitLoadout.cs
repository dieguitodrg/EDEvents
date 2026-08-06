using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"DeleteSuitLoadout","SuitID":4293000001,"SuitName":"Maverick","LoadoutID":4293000001,"LoadoutName":"exp001"}
        public class JournalDeleteSuitLoadout : JournalBase
    {
        public long SuitID { get; set; }
        public string SuitName { get; set; }
        public long LoadoutID { get; set; }
        public string LoadoutName { get; set; }
    }

}