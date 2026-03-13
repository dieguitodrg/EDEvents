using EDCrew;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{


    public class JournalFileHeader : JournalBase
    {
        public int part { get; set; }

        public string language { get; set; }

        public string gameversion { get; set; }

        public string build { get; set; }
    }
}