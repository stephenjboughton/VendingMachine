using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone
{
	public class SalesReport
	{
		string path = Path.Combine(Environment.CurrentDirectory, "vendingmachine.txt");
		Stocker stocker = new Stocker();

		private Dictionary<string, int> Report
		{
			get
			{
				foreach (var item in stocker.ReturnStock(path))
				{
					this.Report[item.Value.Item.Name] = 0;
				}

				return Report;
			}
		}

		public void AddToReport(string product)
		{
			this.Report[product]++;
		}

		public void WriteReport()
		{

			using (StreamWriter sw = new StreamWriter("Log.txt", true))
			{
				foreach (var item in this.Report)
				{
					sw.WriteLine($"{item.Key} {item.Value}");
				}

			}
		}
	}
}
