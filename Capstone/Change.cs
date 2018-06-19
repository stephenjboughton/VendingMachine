using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public class Change
    {
        public int Quarters { get; }
        public int Dimes { get; }
        public int Nickels { get; }

        public Change(int quarters, int dimes, int nickels)
        {
            this.Quarters = quarters;
            this.Dimes = dimes;
            this.Nickels = nickels;
        }
    }
}
