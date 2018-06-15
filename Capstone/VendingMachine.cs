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
			int changeQ = (int)(this.Balance / .25M);
			this.Balance = this.Balance % .25M;
			int changeD = (int)(this.Balance / .10M);
			this.Balance = this.Balance % .10M;
			int changeN = (int)(this.Balance / .05M);

			int[] change =  new int[] { changeQ, changeD, changeN };

			return change;
		}
	}
}
