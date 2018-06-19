using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.ItemsToVend;

namespace Capstone
{
	public class TransactionMenu
	{
		public void PurchaseMenu(VendingMachine vendingMachine)
		{
			while (true)
			{

				Console.WriteLine("-----TE Vending Machine-----");
				Console.WriteLine("  Powered by Umbrella Corp");
				Console.WriteLine();
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
						Console.Clear();
					}
					else
					{
						Console.WriteLine("That is not a valid amount to deposit. Please try again.");
						Console.WriteLine();
					}
				}
				else if (input == "2")
				{
					Console.Clear();
					Console.WriteLine("-----TE Vending Machine-----");
					Console.WriteLine("  Powered by Umbrella Corp");
					Console.WriteLine();
					DisplayStock(vendingMachine);
					Console.Write("> What product would you like to purchase? ");
					Console.WriteLine();
					Console.WriteLine();
					Console.WriteLine($"> Current Money Provided {vendingMachine.Balance:C}");
					string productSelection = Console.ReadLine().ToUpper();

					while (true)
					{
						if (!vendingMachine.ValidProductSelection(productSelection))
						{
							Console.WriteLine("This is not a valid product choice. Please try again.");
							Console.WriteLine();
							break;
						}
						else if (!vendingMachine.ProductInStock(productSelection))
						{
							Console.WriteLine("This product is currently out of stock. Please select a different product.");
							Console.WriteLine();
							break;
						}
						else if (!vendingMachine.HasRequiredBalance(productSelection))
						{
							Console.WriteLine("You have not inserted enough money to buy this product. Please insert more money or select a different item!");
							Console.WriteLine();
							break;
						}
						else
						{
							Console.WriteLine();
							Console.WriteLine("Your product is now being dispensed. Thank you!");
							Console.WriteLine();
							vendingMachine.DispenseItem(productSelection);
							break;
						}
					}
				}
				else if (input == "3")
				{
					Console.Clear();
					Console.WriteLine();
					Console.WriteLine($"> Your change is... ");
					Change change = vendingMachine.MakeChange(vendingMachine.Balance);
					Console.WriteLine($"{change.Quarters} quarters, " +
						$"{change.Dimes} dimes, " +
						$"and {change.Nickels} nickels.");
					Console.WriteLine();
					while (vendingMachine.PurchasedStock.Count > 0)
					{
						PurchasableItem item = vendingMachine.PurchasedStock.Dequeue();
						//vendingMachine.SalesReport(item);
						Console.WriteLine(item.ConsumeMessage());
					}
					Console.WriteLine();
					Console.WriteLine("> Press any key to continue...");
					Console.ReadKey();
					Console.Clear();
					break;
				}
			}

		}
		private static void DisplayStock(VendingMachine vendingMachine)
		{

			foreach (var item in vendingMachine.ItemSlot)
			{

				if (item.HasStock)
				{
					Console.WriteLine(item.SlotNumber.PadRight(10) + " " + (item.Item.Name).PadRight(20) + " " + (item.Item.Price));
				}
				else
				{
					Console.WriteLine(item.SlotNumber.PadRight(10) + " " + (item.Item.Name).PadRight(20) + "> SOLD OUT");
				}
			}

			Console.WriteLine();
		}

	}
}
