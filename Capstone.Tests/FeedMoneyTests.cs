using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using Capstone;
using Capstone.ItemsToVend;

namespace Capstone.Tests
{
	[TestClass]
	public class FeedMoneyTests
	{
		Dictionary<string, Slot> initialStock = new Dictionary<string, Slot>()
		{
			{ "A1", new Slot("A1", new GumItem("Test GUM", 1.0M)) }
		};

			[DataTestMethod]
			[DataRow(1.00, 1.00)]
			[DataRow(2.00, 2.00)]
			[DataRow(5.00, 5.00)]
			[DataRow(10.00, 10.00)]
			public void CheckToSeeIfFeedMoneyProducesCorrectBalance(double money, double expectedBalance)
			{
				VendingMachine vendingMachine = new VendingMachine(initialStock);
				vendingMachine.FeedMoney((decimal)money);
				double balance = (double)vendingMachine.Balance;

				Assert.AreEqual(expectedBalance, balance);
			}

			[TestMethod]
			public void CheckToSeeIfMultipleFeedMoneyCallsProducesCorrectBalance()
			{
				VendingMachine vendingMachine = new VendingMachine(initialStock);

				vendingMachine.FeedMoney(5.00M);
				vendingMachine.FeedMoney(2.00M);
				vendingMachine.FeedMoney(10.00M);
				decimal balance = vendingMachine.Balance;

				Assert.AreEqual(17.00M, balance);
			}
	}
}
