using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"Screenshot", "Filename":"_Screenshots/Screenshot_0042.bmp", "Width":3840, "Height":2160, "System":"Nuenets", "Body":"Nuenets C 2", "Latitude":-60.7999, "Longitude":-74.059799, "Heading":39, "Altitude":27502.876953 }
        public class JournalScreenshot : JournalBase
    {
        public string Filename { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string System { get; set; }
        public string Body { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Heading { get; set; }
        public double Altitude { get; set; }
    }

}