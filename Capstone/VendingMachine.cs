using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
	public class VendingMachine
	{
		public Dictionary<string, Slot> Stock { get; }

		public VendingMachine(Dictionary<string, Slot> fullStock)
		{
			this.Stock = fullStock;
		}


	}
}
