using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.ItemsToVend;

namespace Capstone
{
	public class VendingMachine
	{
		public Dictionary<string, Slot> Stock { get; }
		public Queue<PurchasableItem> PurchasedStock { get; private set; } = new Queue<PurchasableItem>();
		public decimal Balance { get; set; }
		private Dictionary<string, decimal> SalesReport
		{
			get
			{
				foreach (var item in Stock)
				{
					this.SalesReport[item.Value.Item.Name] = 0.00M;
				}
				return SalesReport;
			}
		}

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
			this.PurchasedStock.Enqueue(this.Stock[item].slotStock.Pop());
			this.Balance -= this.Stock[item].Item.Price;
		//	this.SalesReport[item] += Stock[item].Item.Price;
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
