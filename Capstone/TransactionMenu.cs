using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
	public class TransactionMenu
	{
		public void PurchaseMenu(VendingMachine vendingMachine)
		{
			while (true)
			{
				Console.WriteLine("> To Feed Money, press 1: ");
				Console.WriteLine("> To Select Product, press 2: ");
				Console.WriteLine("> To Finish Transaction, press 3: ");
				Console.WriteLine();
				Console.WriteLine($"> Current Money Provided {vendingMachine.Balance:C}");
				Console.WriteLine();
				string input = Console.ReadLine().ToUpper();

				if (input == "1")
				{
					Console.Write("> How much money would you like to insert, $1, $2, $5, or $10? ");
					decimal moneyFed = decimal.Parse(Console.ReadLine());
					vendingMachine.FeedMoney(moneyFed);
					Console.Clear();
				}
				else if (input == "2")
				{
					Console.Write("> What product would you like to purchase? ");
					string productSelection = Console.ReadLine();

					while (true)
					{
						if (!vendingMachine.Stock.ContainsKey(productSelection))
						{
							Console.WriteLine("This is not a valid product choice. Please try again.");
							Console.WriteLine();
							break;
						}
						else if (!vendingMachine.Stock[productSelection].hasStock)
						{
							Console.WriteLine("This product is currently out of stock.  Please select a different product.");
							Console.WriteLine();
							break;
						}
						else if (vendingMachine.Stock[productSelection].Item.Price > vendingMachine.Balance)
						{
							Console.WriteLine("You have not inserted enough money to buy this product.  Please insert more money or select a different item!");
							Console.WriteLine();
							break;
						}
						else
						{
							Console.WriteLine("Your product is now being dispensed. Thank you!");
							vendingMachine.DispenseItem(productSelection);
							vendingMachine.Balance -= vendingMachine.Stock[productSelection].Item.Price;
							break;
						}
					}
				}
			}

		}


	}
}
