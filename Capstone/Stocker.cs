using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Capstone.ItemsToVend;

namespace Capstone
{
	public class Stocker
	{
		string path = Path.Combine(Environment.CurrentDirectory, "vendingmachine.txt");

		public static Dictionary<string, Slot> ReturnListOfStock(string path)
		{
			Dictionary<string, Slot> stock = new Dictionary<string, Slot>();
			try
			{
				using (StreamReader sr = new StreamReader(path))
				{
					while (!sr.EndOfStream)
					{
						string[] line = sr.ReadLine().Split('|');
						Slot slot = new Slot(line[0], new PurchasableItem(line[1], decimal.Parse(line[2])));
						stock.Add(line[0], slot);

					}
				}
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.Message);
			}
			return stock;
		}
	}
}