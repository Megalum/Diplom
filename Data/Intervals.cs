using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factors.Data
{
    internal class Intervals: Factors
    {
        public Intervals()
        {
            Press = 0;
            Load = 0;
            Spead = 0;
        }

        public Intervals(double press, double load, double spead)
        {
            Press = press;
            Load = load;
            Spead = spead;
        }
    }
}
