﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.ItemsToVend;
using System.IO;

namespace Capstone
{
	public class VendingMachine
	{
		private Dictionary<string, Slot> Stock { get; }
		public Slot[] ItemSlot
		{
			get
			{
				foreach (var item in Stock)
				{
					return Stock.Values.ToArray();
				}
				return ItemSlot;
			}
		}


		public Queue<PurchasableItem> PurchasedStock { get; private set; } = new Queue<PurchasableItem>();
		public decimal Balance { get; set; }

		/*Dictionary<string, int> ReportInventory //= new Dictionary<string, int>();
		{
			get
			{
				foreach (var productType in ItemSlot)
				{
					ReportInventory[productType.Item.Name] = 0;
				}
				return ReportInventory;
			}
		}*/

		public VendingMachine(Dictionary<string, Slot> fullStock)
		{
			this.Stock = fullStock;
		}

		public void FeedMoney(decimal moneyFed)
		{
			this.Balance += moneyFed;
			LogFile logFile = new LogFile();
			string message = logFile.LogFeedMoney(moneyFed, this.Balance);
			logFile.LoggingInfo(message);
		}

		public void DispenseItem(string item)
		{
			PurchasableItem productToDispense = this.Stock[item].Item;
			this.PurchasedStock.Enqueue(this.Stock[item].slotStock.Pop());
			this.Balance -= productToDispense.Price;
			LogFile logFile = new LogFile();
			string message = logFile.LogPurchase(productToDispense.Name, item, productToDispense.Price, this.Balance);
			logFile.LoggingInfo(message);
		}

		public int[] MakeChange(decimal Balance)
		{
			decimal startingBalance = this.Balance;
			int changeQ = (int)(this.Balance / .25M);
			this.Balance = this.Balance % .25M;
			int changeD = (int)(this.Balance / .10M);
			this.Balance = this.Balance % .10M;
			int changeN = (int)(this.Balance / .05M);

			int[] change = new int[] { changeQ, changeD, changeN };

			LogFile logFile = new LogFile();
			string message = logFile.LogGiveChange(startingBalance, this.Balance);
			logFile.LoggingInfo(message);

			return change;
		}

		public bool ValidProductSelection(string productSelection)
		{
			return this.Stock.ContainsKey(productSelection);
		}

		public bool ProductInStock(string productSelection)
		{
			return this.Stock[productSelection].HasStock;
		}

		public bool HasRequiredBalance(string productSelection)
		{
			return (this.Stock[productSelection].Item.Price < this.Balance);
		}

		/*public void SalesReport(PurchasableItem item)
		{
			this.ReportInventory[item.Name]++;

			using (StreamWriter sw = new StreamWriter("Report.txt", true))
			{
				sw.WriteLine($"{item.Name} {ReportInventory[item.Name]}");
			}
		}*/
	}
}
