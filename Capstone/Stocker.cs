using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Capstone.ItemsToVend;

namespace Capstone
{
	public class Stocker
	{
		string path = Path.Combine(Environment.CurrentDirectory, "vendingmachine.txt");
		List<PurchasableItem> quiz = new List<PurchasableItem>();

	}
}