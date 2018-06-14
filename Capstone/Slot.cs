using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
	public class Slot
	{
		public Stack<PurchasableItem> slotStock = new Stack<PurchasableItem>();

		public bool hasStock
		{
			get
			{
				if (slotStock.Count > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

	}
}
