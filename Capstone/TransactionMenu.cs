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

					decimal[] validAmount = new decimal[4] { 1M, 2M, 5M, 10M };

					if (validAmount.Contains(moneyFed))
					{
						vendingMachine.FeedMoney(moneyFed);
					}
					else
					{
						Console.WriteLine("That is not a valid amount to deposit. Please try again.");
						Console.WriteLine();
					}
				}
				else if (input == "2")
				{
					DisplayStock(vendingMachine);
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
				else if (input == "3")
				{
					Console.Clear();
					Console.WriteLine();
					Console.WriteLine($"> Your change is... ");
					Console.WriteLine($"{vendingMachine.MakeChange(vendingMachine.Balance)[0]} quarters, " +
						$"{vendingMachine.MakeChange(vendingMachine.Balance)[1]} dimes, " +
						$"and {vendingMachine.MakeChange(vendingMachine.Balance)[2]} nickels.");

					Console.WriteLine("> Press any key to continue...");
					Console.ReadKey();
					Console.Clear();
					break;
				}
			}

		}
		private static void DisplayStock(VendingMachine vendingMachine)
		{

			foreach (var item in vendingMachine.Stock)
			{

				if (item.Value.hasStock)
				{
					Console.WriteLine(item.Key + " " + (item.Value).Item.Name + " " + (item.Value).ItemsRemaining);
				}
				else
				{
					Console.WriteLine(item.Key + " " + (item.Value).Item.Name + "> SOLD OUT");
				}
			}

			Console.WriteLine();
		}

	}
}
