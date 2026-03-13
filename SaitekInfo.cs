using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ControlSaitek
{
    public partial class Info
    {
        public bool FireButtonIllumination { get; set; }
        public string FireAColor { get; set; }
        public string FireBColor { get; set; }
        public string FireDColor { get; set; }
        public string FireEColor { get; set; }
        public string Toggle12Color { get; set; }
        public string Toggle34Color { get; set; }
        public string Toggle56Color { get; set; }
        public string POV2Color { get; set; }
        public string ClutchColor { get; set; }
        public bool ThrottleAxisIllumination { get; set; }
        public List<List<String>> Lines { get; set; }

        //TODO Quitar y poner OldInfo
        
        public bool Equals(Info info)
        {

            if (info == null) return false;

            if (Lines == null && info.Lines != null) return false;

            if (Lines.Count != info.Lines.Count) return false;

            for (int i = 0; i < Lines.Count; i++)
            {
                /*                if (Lines[i].Count() >= 1) if (Lines[i][0] != info.Lines[i][0]) return false;
                                if (Lines[i].Count() >= 2) if (Lines[i][1] != info.Lines[i][1]) return false;
                                if (Lines[i].Count() >= 3) if (Lines[i][2] != info.Lines[i][2]) return false;*/

                if (Lines[i].Count() != info.Lines[i].Count()) return false;

                for (int j = 0; j < Lines[i].Count(); j++)
                {
                    if (Lines[i][j] != info.Lines[i][j]) return false;
                }

            }


            return (
                ClutchColor == info.ClutchColor &&
                Toggle12Color == info.Toggle12Color &&
                Toggle34Color == info.Toggle34Color &&
                Toggle56Color == info.Toggle56Color &&
                POV2Color == info.POV2Color &&
                FireAColor == info.FireAColor &&
                FireBColor == info.FireBColor &&
                FireDColor == info.FireDColor &&
                ThrottleAxisIllumination == info.ThrottleAxisIllumination &&
                FireButtonIllumination == info.FireButtonIllumination);
        }
        
    }

}