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
        public class RGBColor
        {
            public byte Red { get; set; }
            public byte Green { get; set; }
            public byte Blue { get; set; }

            public RGBColor()
            {
            }

            public RGBColor(byte red, byte green, byte blue)
            {
                Red = red;
                Green = green;
                Blue = blue;
            }

            public RGBColor(string hexColor)
            {
                hexColor = hexColor.TrimStart('#');
                Red = Convert.ToByte(hexColor.Substring(0, 2), 16);
                Green = Convert.ToByte(hexColor.Substring(2, 2), 16);
                Blue = Convert.ToByte(hexColor.Substring(4, 2), 16);
            }

            public int Value { get { return RGB_to_Int32(); } }

            private int RGB_to_Int32()
            {
                checked
                {
                    return 65536 * Blue + 256 * Green + Red;
                }
            }
        }

        public bool FireButtonIllumination { get; set; }
        public bool[] FireButtonIlluminations { get; set; }

        public string FireAColor { get; set; }
        public string[] FireAColors { get; set; }

        public string FireBColor { get; set; }
        public string[] FireBColors { get; set; }

        public string FireDColor { get; set; }
        public string[] FireDColors { get; set; }

        public string FireEColor { get; set; }
        public string[] FireEColors { get; set; }

        public string Toggle12Color { get; set; }
        public string[] Toggle12Colors { get; set; }

        public string Toggle34Color { get; set; }
        public string[] Toggle34Colors { get; set; }

        public string Toggle56Color { get; set; }
        public string[] Toggle56Colors { get; set; }

        public string POV2Color { get; set; }
        public string[] POV2Colors { get; set; }

        public string ClutchColor { get; set; }
        public string[] ClutchColors { get; set; }

        public bool ThrottleAxisIllumination { get; set; }
        public bool[] ThrottleAxisIlluminations { get; set; }

        public RGBColor JoystickColor { get; set; }
        public RGBColor[] JoystickColors { get; set; }

        public RGBColor ThrottleColor { get; set; }
        public RGBColor[] ThrottleColors { get; set; }

        public int DurationMs { get; set; }

        public List<List<String>> Lines { get; set; }

        //TODO Quitar y poner OldInfo
        
        public bool Equals(Info info)
        {

            if (info == null) return false;

            if (Lines == null && info.Lines != null) return false;

            if (Lines.Count != info.Lines.Count) return false;

            for (int i = 0; i < Lines.Count; i++)
            {
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
                FireEColor == info.FireEColor &&
                ThrottleAxisIllumination == info.ThrottleAxisIllumination &&
                FireButtonIllumination == info.FireButtonIllumination &&
                JoystickColor?.Red == info.JoystickColor?.Red &&
                JoystickColor?.Green == info.JoystickColor?.Green &&
                JoystickColor?.Blue == info.JoystickColor?.Blue &&
                ThrottleColor?.Red == info.ThrottleColor?.Red &&
                ThrottleColor?.Green == info.ThrottleColor?.Green &&
                ThrottleColor?.Blue == info.ThrottleColor?.Blue);
        }
        
    }

}
