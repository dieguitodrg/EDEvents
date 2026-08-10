using System;
//using System.Speech.Synthesis;
//using LuminaController;

//using Windows.Web.Http;

namespace EDCrew
{
    public static class ObjectHelpers {
public static String ToSafeString(this object o)
    {
        return o == null ? "" : o.ToString();
    }

        }


}

