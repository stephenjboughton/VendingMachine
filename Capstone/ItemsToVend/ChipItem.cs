using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.ItemsToVend
{
	public class ChipItem : PurchasableItem
	{

		public ChipItem(string name, decimal price) : base(name, price) { }

		public override string ConsumeMessage()
		{
			string consumeMessage = "Crunch Crunch, Yum!";
			return consumeMessage;
		}
	}
}
