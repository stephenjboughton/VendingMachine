using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Capstone.Tests
{
	[TestClass]
	public class DispenseItemTests
	{
		[TestMethod]
		public void CheckToSeeIfDispenseItemReducesStock()
		{
			string path = Path.Combine(Environment.CurrentDirectory, "vendingmachine.txt");
			Stocker stocker = new Stocker();
			var Stock = stocker.ReturnStock(path);
			VendingMachine vendingMachine = new VendingMachine(Stock);
			vendingMachine.Balance = 5.00M;

			vendingMachine.DispenseItem("A1");

			Assert.AreEqual(4, Stock["A1"].ItemsRemaining);
			Assert.AreEqual(1.95M, vendingMachine.Balance);
		}
	}
}
