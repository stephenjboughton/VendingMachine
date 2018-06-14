using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Capstone.ItemsToVend;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
			string path = Path.Combine(Environment.CurrentDirectory, "vendingmachine.txt");
			Stocker stocker = new Stocker();
			
        }
    }
}
