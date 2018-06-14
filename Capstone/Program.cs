﻿using System;
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
			VendingMachine vendingMachine = new VendingMachine(stocker.ReturnListOfStock(path));
			


			string input = PromptUserForMenuChoice();

			while (input != "Q")
			{

				switch (input)
				{
					case "1": // Display current sztock
						DisplayStock(vendingMachine);
						break;
					case "2": // Make a purchase
						Purchase();
						break;
				}

				input = PromptUserForMenuChoice();
			}
		}

		/// <summary>
		/// allows the user to make a purchase
		/// </summary>
		private static void Purchase()
		{

		}

		/// <summary>
		/// allows the user to view all items in the machine
		/// </summary>
		private static void DisplayStock(VendingMachine vendingMachine)
		{
			foreach (var item in vendingMachine.Stock)
			{
				Console.WriteLine(item.Key);
			}
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
					break;
				}
			}

			while (!validchoices.Contains(input));

			return input;
		}
	}
}
