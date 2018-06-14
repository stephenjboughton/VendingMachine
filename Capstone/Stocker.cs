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

		private static List<PurchasableItem> ReturnListOfStock(string path)
		{
			List<PurchasableItem> itemsToStock = new List<PurchasableItem>();
			try
			{
				using (StreamReader sr = new StreamReader(path))
				{
					while (!sr.EndOfStream)
					{
						string[] line = sr.ReadLine().Split('|');
						itemsToStock.Add(new PurchasableItem(line[1], decimal.Parse(line[2])));
					}
				}
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.Message);
			}
			return itemsToStock;
		}
	}
}