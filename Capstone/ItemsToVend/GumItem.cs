using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.ItemsToVend

{
	public class GumItem : PurchasableItem
	{

		public GumItem(string name, decimal price) : base(name, price) { }

		public override string ConsumeMessage()
		{
			string consumeMessage = "Chew Chew, Yum!";
			return consumeMessage;
		}
	}
}
