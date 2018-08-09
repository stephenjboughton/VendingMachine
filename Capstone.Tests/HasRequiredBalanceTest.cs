using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Capstone.ItemsToVend;

namespace Capstone.Tests
{
	[TestClass]
	public class HasRequiredBalanceTest
	{
		Dictionary<string, Slot> initialStock = new Dictionary<string, Slot>()
		{
			{ "A1", new Slot("A1", new GumItem("Test GUM", 1.0M)) }
		};

		[DataTestMethod]
		[DataRow("A1", false)]
		[DataRow("A3", false)]
		[DataRow("C3", true)]
		[DataRow("D2", true)]
		public void CheckToSeeIfHasRequiredBalance(string selection, bool expectedResult)
		{
			VendingMachine vendingMachine = new VendingMachine(initialStock);

			vendingMachine.FeedMoney(2);
			bool result = vendingMachine.HasRequiredBalance(selection);

			Assert.AreEqual(expectedResult, result);
		}
	}
}
