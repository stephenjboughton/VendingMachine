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
		public Dictionary<string, Slot> ReturnStock(string path)
		{
			Dictionary<string, Slot> stock = new Dictionary<string, Slot>();
			try
			{
				using (StreamReader sr = new StreamReader(path))
				{
					while (!sr.EndOfStream)
					{
						string[] line = sr.ReadLine().Split('|');
						if (line[3] == "Chip")
						{
							Slot slot = new Slot(line[0], new ChipItem(line[1], decimal.Parse(line[2])));
							stock.Add(line[0], slot);
						}
						else if (line[3] == "Candy")
						{
							Slot slot = new Slot(line[0], new CandyItem(line[1], decimal.Parse(line[2])));
							stock.Add(line[0], slot);
						}
						else if (line[3] == "Drink")
						{
							Slot slot = new Slot(line[0], new DrinkItem(line[1], decimal.Parse(line[2])));
							stock.Add(line[0], slot);
						}
						else
						{
							Slot slot = new Slot(line[0], new GumItem(line[1], decimal.Parse(line[2])));
							stock.Add(line[0], slot);
						}
					}
				}
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.Message);
			}
			return stock;
		}

		public Dictionary<string, decimal> SalesReport(string path)
		{
			Dictionary<string, decimal> sales = new Dictionary<string, decimal>();
			try
			{
				using (StreamReader sr = new StreamReader(path))
				{
					while (!sr.EndOfStream)
					{
						string[] line = sr.ReadLine().Split('|');
						
						sales.Add(line[1], 0.00M);
						
					}
				}
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.Message);
			}
			return sales;
		}
	}
}