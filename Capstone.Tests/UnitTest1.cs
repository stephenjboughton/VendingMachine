using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;
using Capstone.ItemsToVend;
using System.IO;

namespace Capstone.Tests
{
    [TestClass]
    public class UnitTest1
    {
		[TestMethod]
		public void Check_To_See_If_Change_Return_Works()
		{
			string path = Path.Combine(Environment.CurrentDirectory, "vendingmachine.txt");
			Stocker stocker = new Stocker();
			VendingMachine vendingMachine = new VendingMachine(stocker.ReturnStock(path));
			vendingMachine.Balance = 6.35M;

			int[] change = vendingMachine.MakeChange(vendingMachine.Balance);

			CollectionAssert.AreEqual(new int [] { 25, 1, 0 }, change);
		}
	}
}
