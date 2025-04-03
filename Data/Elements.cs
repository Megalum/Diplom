using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factors.Data
{
    internal class Elements: Factors
    {
        public Elements() 
        {
            Press = 0;
            Load = 0;
            Spead = 0;
        }

        public Elements(double press, double load, double spead)
        {
            Press = press;
            Load = load;
            Spead = spead;
        }
    }
}
