using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-10-26T11:38:41Z", "event":"EngineerProgress", "Engineers":[ { "Engineer":"Hera Tani", "EngineerID":300090, "Progress":"Unlocked", "RankProgress":0, "Rank":5 }, { "Engineer":"Professor Palin", "EngineerID":300220, "Progress":"Unlocked", "RankProgress":0, "Rank":5 }, { "Engineer":"Felicity Farseer", "EngineerID":300100, "Progress":"Unlocked", "RankProgress":0, "Rank":5 }, { "Engineer":"Eleanor Bresa", "EngineerID":400011, "Progress":"Known" }, { "Engineer":"Hero Ferrari", "EngineerID":400003, "Progress":"Known" }, { "Engineer":"Tiana Fortune", "EngineerID":300270, "Progress":"Unlocked", "RankProgress":0, "Rank":5 }, { "Engineer":"Jude Navarro", "EngineerID":400001, "Progress":"Known" }, { "Engineer":"Broo Tarquin", "EngineerID":300030, "Progress":"Unlocked", "RankProgress":0, "Rank":5 }, { "Engineer":"Etienne Dorn", "EngineerID":300290, "Progress":"Invited" }, { "Engineer":"Lori Jameson", "EngineerID":300230, "Progress":"Unlocked", "RankProgress":0, "Rank":5 }, { "Engineer":"Bill Turner", "EngineerID":300010, "Progress":"Invited" }, { "Engineer":"Liz Ryder", "EngineerID":300080, "Progress":"Unlocked", "RankProgress":0, "Rank":4 }, { "Engineer":"Rosa Dayette", "EngineerID":400012, "Progress":"Known" }, { "Engineer":"Juri Ishmaak", "EngineerID":300250, "Progress":"Invited" }, { "Engineer":"Zacariah Nemo", "EngineerID":300050, "Progress":"Known" }, { "Engineer":"Mel Brandon", "EngineerID":300280, "Progress":"Known" }, { "Engineer":"Selene Jean", "EngineerID":300210, "Progress":"Unlocked", "RankProgress":0, "Rank":5 }, { "Engineer":"Marco Qwent", "EngineerID":300200, "Progress":"Unlocked", "RankProgress":0, "Rank":5 }, { "Engineer":"Chloe Sedesi", "EngineerID":300300, "Progress":"Invited" }, { "Engineer":"Baltanos", "EngineerID":400010, "Progress":"Known" }, { "Engineer":"Petra Olmanova", "EngineerID":300130, "Progress":"Invited" }, { "Engineer":"Ram Tah", "EngineerID":300110, "Progress":"Unlocked", "RankProgress":36, "Rank":3 }, { "Engineer":"The Dweller", "EngineerID":300180, "Progress":"Unlocked", "RankProgress":0, "Rank":5 }, { "Engineer":"Elvira Martuuk", "EngineerID":300160, "Progress":"Unlocked", "RankProgress":0, "Rank":5 }, { "Engineer":"Lei Cheung", "EngineerID":300120, "Progress":"Unlocked", "RankProgress":0, "Rank":5 }, { "Engineer":"Didi Vatermann", "EngineerID":300000, "Progress":"Unlocked", "RankProgress":0, "Rank":5 }, { "Engineer":"Tod 'The Blaster' McQuinn", "EngineerID":300260, "Progress":"Unlocked", "RankProgress":0, "Rank":5 }, { "Engineer":"Domino Green", "EngineerID":400002, "Progress":"Known" }, { "Engineer":"Marsha Hicks", "EngineerID":300150, "Progress":"Invited" } ] }
        public class JournalEngineerProgressEngineer
    {
        public string Engineer { get; set; }
        public int EngineerID { get; set; }
        public string Progress { get; set; }
        public int RankProgress { get; set; }
        public int Rank { get; set; }
    }

    public class JournalEngineerProgress : JournalBase
    {
        public List<JournalEngineerProgressEngineer> Engineers { get; set; }
    }

}