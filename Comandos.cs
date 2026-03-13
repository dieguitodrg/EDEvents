using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{
    public class Comandos : ICloneable
    {
        public string command { get; set; }
        public List<byte> control { get; set; }

        public List<string> precommands { get; set; }
        public List<string> postcommands { get; set; }
        public string conditionsource { get; set; }
        public string conditionvalue { get; set; }
        public string category { get; set; }
        public string subsystem { get; set; }
        public string method { get; set; }

        public List<SubComando> subcommands { get; set; }

        public string code { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class SubComando
    {
        public string Item { get; set; }
        public string Argument { get; set; }
    }

}
