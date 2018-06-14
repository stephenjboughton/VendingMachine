using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.ItemsToVend;

namespace Capstone
{
	public class Slot
	{
		public Stack<PurchasableItem> slotStock = new Stack<PurchasableItem>();
		PurchasableItem Item { get; }
		string SlotNumber { get; }
		int ItemsRemaining
		{
			get
			{
				return slotStock.Count;
			}
		}

		public Slot(string slotNumber, PurchasableItem item)
		{
			this.SlotNumber = slotNumber;
			this.Item = item;
		}

		public void FillSlot(PurchasableItem itemFromStocker)
		{
			slotStock.Push(this.Item);
			slotStock.Push(this.Item);
			slotStock.Push(this.Item);
			slotStock.Push(this.Item);
			slotStock.Push(this.Item);
		}

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
