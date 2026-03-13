using EDCrew;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EDCrew
{


    public class Reader
    {
        public static JournalBase ReadJson(String json)
        {
            //JournalBase journal = new JournalBase();

            JournalBase journal = JsonConvert.DeserializeObject<JournalBase>(json);

            try
            {
                object journalevent = Activator.CreateInstance(Type.GetType("EDCrew.Journal" + journal.@event));
                journalevent = JsonConvert.DeserializeObject(json, journalevent.GetType());
                return (JournalBase)journalevent;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return journal;
            }

            return (journal);

        }
    }

    public class JournalBase
    {

        public DateTime timestamp { get; set; }

        public string @event { get; set; }        

    }

    public class Localizer
    {
        public string Show(string value, string localisedvalue)
        {
            try
            {
                return localisedvalue != null ? localisedvalue : value;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }


}