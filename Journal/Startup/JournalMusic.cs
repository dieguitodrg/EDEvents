using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T21:14:34Z", "event":"Music", "MusicTrack":"DockingComputer" }
public class JournalMusic : JournalBase
    {
        public string MusicTrack { get; set; }
    }


}