using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;
using Capstone.ItemsToVend;
using System.IO;

namespace Capstone.Tests
{
	[TestClass]
	public class ChangeReturnTests
	{
		[DataTestMethod]
		[DataRow(6.35, new int [] {25, 1, 0})]
		[DataRow(1.95, new int[] { 7, 2, 0 })]
		[DataRow(12.55, new int[] { 50, 0, 1 })]
		public void Check_To_See_If_Change_Return_Works(double balance, int[] changeExpected)
		{
			string path = Path.Combine(Environment.CurrentDirectory, "vendingmachine.txt");
			Stocker stocker = new Stocker();
			VendingMachine vendingMachine = new VendingMachine(stocker.ReturnStock(path));
			vendingMachine.Balance = (decimal)balance;

			int[] change = vendingMachine.MakeChange(vendingMachine.Balance);

			CollectionAssert.AreEqual(changeExpected, change);
		}

		[TestMethod]
		public void Check_To_See_If_Change_Return_Leaves_Zero_Balance()
		{
			string path = Path.Combine(Environment.CurrentDirectory, "vendingmachine.txt");
			Stocker stocker = new Stocker();
			VendingMachine vendingMachine = new VendingMachine(stocker.ReturnStock(path));
			vendingMachine.Balance = 5.85M;

			vendingMachine.MakeChange(vendingMachine.Balance);
			decimal balance = vendingMachine.Balance;

			Assert.AreEqual(0.00M, balance);
		}
	}
}
