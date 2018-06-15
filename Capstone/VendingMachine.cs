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

		public decimal Balance { get; set; }

		public VendingMachine(Dictionary<string, Slot> fullStock)
		{
			this.Stock = fullStock;
		}

		public void FeedMoney(decimal moneyFed)
		{
			this.Balance += moneyFed;
		}

		public void DispenseItem(string item)
		{
			this.Stock[item].slotStock.Pop();
		}

		public int[] MakeChange(decimal Balance)
		{
			int[] change = new int[3];

			// determine number of each of quarter, dimes nickels to give back in change, 
			// populate array with those numbers

			return change;
		}
	}
}
