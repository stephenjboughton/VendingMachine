using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.ItemsToVend
{
	public class DrinkItem : PurchasableItem
	{

		public DrinkItem(string name, decimal price) : base(name, price) { }
		
		public override string ConsumeMessage()
		{
			string consumeMessage = "Glug Glug, Yum!";
			return consumeMessage;
		}
	} 
}
