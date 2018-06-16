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

			LogFile logFile = new LogFile();

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
						TransactionMenu menu = new TransactionMenu();
						menu.PurchaseMenu(vendingMachine);
						break;
					case "3": //check the sales log
						DisplayLogFile(logFile);
						break;
				}

				input = PromptUserForMenuChoice();
			}
		}

		/// <summary>
		/// Writes the log file to the console after user has entered correct password.
		/// </summary>
		/// <param name="logFile"></param>
		private static void DisplayLogFile(LogFile logFile)
		{
			Console.Beep();
			Console.Beep();
			string input = "";

			Console.WriteLine("-----TE Vending Machine-----");
			Console.WriteLine("  Powered by Umbrella Corp");
			Console.WriteLine();
			Console.WriteLine("       MANAGERS ONLY");
			Console.WriteLine();
			Console.Write("> Please enter password: ");
			input = Console.ReadLine();

			if (input == "CLENET8")
			{

				Console.WriteLine();
				Console.WriteLine(logFile.ConsoleLog());
				Console.WriteLine();
				// this is where the sales report will be displayed to the console
				Console.WriteLine("> Press any key to continue...");
				Console.ReadKey();
				Console.Clear();
			}

			else if (input != "CLENET8")
			{
				Console.WriteLine();
				Console.WriteLine("> WRONG PASSWORD");
				Console.WriteLine();
				Console.WriteLine("> Press any key to continue...");
				Console.ReadKey();
				Console.Clear();
			}
		}

		/// <summary>
		/// allows the user to view all items in the machine
		/// </summary>
		private static void DisplayStock(VendingMachine vendingMachine)
		{
			Console.WriteLine("-----TE Vending Machine-----");
			Console.WriteLine("  Powered by Umbrella Corp");
			Console.WriteLine();

			foreach (var item in vendingMachine.itemSlot)
			{

				if (item.hasStock)
				{
					Console.WriteLine(item.SlotNumber.PadRight(10) + " " + (item.Item.Name).PadRight(20) + " " + (item.ItemsRemaining));
				}
				else
				{
					Console.WriteLine(item.SlotNumber + " " + (item.Item.Name) + "> SOLD OUT");
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

			string[] validchoices = { "1", "2", "3", "Q" };
			string input = "";

			do
			{
				Console.WriteLine("-----TE Vending Machine-----");
				Console.WriteLine("  Powered by Umbrella Corp");
				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine("> Display Vending Machine Items, press 1: ");
				Console.WriteLine("> Make a Purchase, press 2: ");
				Console.WriteLine();
				Console.WriteLine("> press Q to quit: ");
				input = Console.ReadLine().ToUpper();
				Console.Clear();

				if (input == "Q")
				{
					Console.WriteLine();
					Console.WriteLine("     Umbrella Corp");
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
