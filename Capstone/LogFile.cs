using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Capstone;
using Capstone.ItemsToVend;

namespace Capstone
{
	public class LogFile
	{
		public void LoggingInfo(string message)
		{

			using (StreamWriter sw = new StreamWriter("Log.txt", true))
			{
				sw.WriteLine(System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToString("hh:mm:ss tt") + " " + message);
			}
		}

		public string LogPurchase(string product, string slot, decimal initialAmount, decimal finalBalance)
		{
			string message = ($"{product} {slot} {initialAmount:C2} {finalBalance:C2}");
			return message;
		}

		public string LogFeedMoney(decimal startingBalance, decimal moneyFed)
		{
			string message = ($"FEED MONEY: {startingBalance:C2} {moneyFed:C2}");
			return message;
		}

		public string LogGiveChange(decimal startingBalance, decimal finalBalance)
		{
			string message = ($"GIVE CHANGE: {startingBalance:C2} {finalBalance:C2}");
			return message;
		}

		public string ConsoleLog()
		{
			string line = "";
			using (StreamReader sr = new StreamReader("log.txt"))
			{
				while (!sr.EndOfStream)
				{
					line = sr.ReadLine();
					Console.WriteLine(line);
				}
			}

			return null;
		}
	}
}