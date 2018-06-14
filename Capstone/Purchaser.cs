using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
	public class Purchaser
	{
		decimal FeedMoney { get; set; }
		
		public Purchaser(VendingMachine vendingMachine)
		{
			
		}

		public decimal FeedMoney()
		{
			Console.WriteLine("> How much money are you spending: ");
			string FeedMoney = Console.ReadLine();
		}







		public static string PurchaseMenu(VendingMachine vendingMachine)
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
			}

			while (!validchoices.Contains(input));

			return input;
		}
	}
}
