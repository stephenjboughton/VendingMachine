﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.ItemsToVend
{
	public class PurchasableItem
	{
		string SlotNumber { get; set; }
		string Name { get; }
		decimal Price { get; }
		string Type { get; set; }

		public PurchasableItem(string name, decimal price)
		{
			this.Name = name;
			this.Price = price;
		}

		public virtual string ConsumeMessage()
		{
			string consumeMessage = "";
			return consumeMessage;
		}
	}
}
