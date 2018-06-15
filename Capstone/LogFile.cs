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
				sw.WriteLine(System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToString("hh:mm:ss tt") + " " + message.PadRight(20));
			}
		}

		public string LogPurchase(string product, string slot, decimal initialAmount, decimal finalBalance)
		{
			string message = ($"{product}  {slot}  {initialAmount:C2}  {finalBalance:C2}");
			return message;
		}

		public string LogFeedMoney(decimal moneyFed, decimal finalBalance)
		{
			string message = ($"FEED MONEY: {moneyFed:C2} {finalBalance:C2}");
			return message;
		}

		public string LogGiveChange(decimal startingBalance, decimal finalBalance)
		{
			string message = ($"GIVE CHANGE: {startingBalance:C2} {finalBalance:C2}");
			return message;
		}
	}
}