using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{
    public class JournalFSSDiscoveryScan : JournalBase
    {
        public double Progress { get; set; }
        public int BodyCount { get; set; }
        public int NonBodyCount { get; set; }
        public string SystemName { get; set; }
        public Int64 SystemAddress { get; set; }
}
}
