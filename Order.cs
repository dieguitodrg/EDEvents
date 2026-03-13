using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{
    public class Order
    {
        public String System { get; set; }
        public String Orders { get; set; }

        public String ToString()
        {
            return $"{System} - {Orders}";
        }

    }
}
