using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Capstone.Tests
{
	[TestClass]
	public class HasRequiredBalanceTest
	{
		[DataTestMethod]
		[DataRow("A1", false)]
		[DataRow("A3", false)]
		[DataRow("C3", true)]
		[DataRow("D2", true)]
		public void CheckToSeeIfHasRequiredBalance(string selection, bool expectedResult)
		{
			string path = Path.Combine(Environment.CurrentDirectory, "vendingmachine.txt");
			Stocker stocker = new Stocker();
			VendingMachine vendingMachine = new VendingMachine(stocker.ReturnStock(path));

			vendingMachine.FeedMoney(2);
			bool result = vendingMachine.HasRequiredBalance(selection);

			Assert.AreEqual(expectedResult, result);
		}
	}
}
