using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Capstone.Tests
{
	[TestClass]
	public class FeedMoneyTests
	{
		[TestClass]
		public class FeedMoneyMethodTests
		{
			[DataTestMethod]
			[DataRow(1.00, 1.00)]
			[DataRow(2.00, 2.00)]
			[DataRow(5.00, 5.00)]
			[DataRow(10.00, 10.00)]
			public void CheckToSeeIfFeedMoneyProducesCorrectBalance(double money, double expectedBalance)
			{
				string path = Path.Combine(Environment.CurrentDirectory, "vendingmachine.txt");
				Stocker stocker = new Stocker();
				VendingMachine vendingMachine = new VendingMachine(stocker.ReturnStock(path));

				vendingMachine.FeedMoney((decimal)money);
				double balance = (double)vendingMachine.Balance;

				Assert.AreEqual(expectedBalance, balance);
			}

			[TestMethod]
			public void CheckToSeeIfMultipleFeedMoneyCallsProducesCorrectBalance()
			{
				string path = Path.Combine(Environment.CurrentDirectory, "vendingmachine.txt");
				Stocker stocker = new Stocker();
				VendingMachine vendingMachine = new VendingMachine(stocker.ReturnStock(path));

				vendingMachine.FeedMoney(5.00M);
				vendingMachine.FeedMoney(2.00M);
				vendingMachine.FeedMoney(10.00M);
				decimal balance = vendingMachine.Balance;

				Assert.AreEqual(17.00M, balance);
			}
		}
	}
}
