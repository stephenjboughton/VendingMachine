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

			VendingMachine vendingMachine = new VendingMachine(stocker.ReturnStock(path));

			string input = PromptUserForMenuChoice();

			while (input != "Q")
			{

				switch (input)
				{
					case "1": // Display current stock
						DisplayStock(vendingMachine);
						break;
					case "2": // Make a purchase
						string choice = PurchaseMenu(vendingMachine);
						break;
				}

				input = PromptUserForMenuChoice();
			}
		}

		/// <summary>
		/// allows the user to make a purchase
		/// </summary>
		private static string PurchaseMenu(VendingMachine vendingMachine)
		{
			string[] validchoices = { "1", "2", "3", "Q" };
			string input = "";

			do
			{
				Console.WriteLine("> To Feed Money, press 1: ");
				Console.WriteLine("> To Select Product, press 2: ");
				Console.WriteLine("> To Finish Transaction, press 3: ");
				Console.WriteLine("> press Q to quit: ");
				input = Console.ReadLine().ToUpper();
				Console.Clear();

				if (input == "Q")
				{
					Console.WriteLine();
					Console.WriteLine("Umbrella Corp");
					Console.WriteLine("Our business is life itself");
					Console.WriteLine();
					break;
				}
			}

			while (!validchoices.Contains(input));

			return input;
		}

		/// <summary>
		/// allows the user to view all items in the machine
		/// </summary>
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
			Console.WriteLine("> Press any key to continue...");
			Console.ReadKey();
			Console.Clear();
		}

		/// <summary>
		/// Prompt the user for a menu choice
		/// </summary>
		/// <returns></returns>
		private static string PromptUserForMenuChoice()
		{

			string[] validchoices = { "1", "2", "Q" };
			string input = "";

			do
			{
				Console.WriteLine("-----TE Vending Machine-----");
				Console.WriteLine("  Powered by Umbrella Corp");
				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine("> Display Vending Machine Items, press 1: ");
				Console.WriteLine("> Make a Purchase, press 2: ");
				Console.WriteLine("> press Q to quit: ");
				input = Console.ReadLine().ToUpper();
				Console.Clear();

				if (input == "Q")
				{
					Console.WriteLine();
					Console.WriteLine("Umbrella Corp");
					Console.WriteLine("Our business is life itself");
					Console.WriteLine();
					break;
				}
			}

			while (!validchoices.Contains(input));

			return input;
		}
	}
}
