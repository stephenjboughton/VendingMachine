using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.ItemsToVend
{
	public class CandyItem : PurchasableItem
	{
		public string Name { get; }
		public decimal Price { get; }

		public CandyItem(string name, decimal price) : base(name, price) { }

		public override string ConsumeMessage()
		{
			string consumeMessage = "Munch Munch, Yum!";
			return consumeMessage;
		}

	}
}
