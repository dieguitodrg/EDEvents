using System;
//using System.Speech.Synthesis;
//using LuminaController;

//using Windows.Web.Http;

namespace EDCrew
{
    /*
    class MFDRefresh
    {
        private Form1 _form;

        public MFDRefresh(Form1 form)
        {
            _form = form;
        }

        public void Display(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;

            _form.DisplayPage();
        }
    }
*/
    /*
    class MarqueeChecker
    {
        private int invokeCount;
        private string line;
        private int maxlength;
        private int pageno;

        private System.IntPtr device;
        private int lineno;
        private DirectOutputCSharpWrapper.DirectOutput directoutput;

        public MarqueeChecker(int _maxlength, string _line, int _pageno, int _lineno, DirectOutput _directouput, System.IntPtr _device)
        {
            invokeCount = 0;
            this.line = _line;
            this.maxlength = _maxlength;
            this.pageno = _pageno;
            this.directoutput = _directouput;
            this.device = _device;
            this.lineno = _lineno;
         }

        // This method is called by the timer delegate.
        public void Display(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;

            string toshow = line;

            if (invokeCount == 0)
            {
                this.directoutput.SetString(device, pageno, lineno, toshow);
                invokeCount++;
                return;
            }

            if (line.Length > maxlength)
            {
                int startpos = invokeCount;

                if (line.Length >= startpos + maxlength)
                {
                    toshow = line.Substring(invokeCount, maxlength);
                } else
                {
                    if (invokeCount < line.Length)
                        toshow = line.Substring(invokeCount);
                    
                }

                Console.WriteLine($"{line} {startpos} {line.Length} {invokeCount} {toshow}");


            }
            try
            {
                this.directoutput.SetString(device, pageno, lineno, toshow);
            }
            catch(Exception ex)
            {

            }
            

            invokeCount++;
            if (invokeCount == line.Length) invokeCount = 0;

            
        }
    }*/


    public class Commodity
    {
        public String name { get; set; }
        public String value { get; set; }
    }


}

