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
		public PurchasableItem Item { get; }
		public string SlotNumber { get; }
		public int ItemsRemaining
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

			this.FillSlot();
		}

		private void FillSlot()
		{
			slotStock.Push(this.Item);
			slotStock.Push(this.Item);
			slotStock.Push(this.Item);
			slotStock.Push(this.Item);
			slotStock.Push(this.Item);
		}

		public bool HasStock
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
