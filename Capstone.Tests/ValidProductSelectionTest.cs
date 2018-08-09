using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using Capstone;
using Capstone.ItemsToVend;

namespace Capstone.Tests
{
	[TestClass]
	public class ValidProductSelectionTest
	{
		Dictionary<string, Slot> initialStock = new Dictionary<string, Slot>()
		{
			{"A1", new Slot("A1", new ChipItem("Test Chip", 3.25M)) },
			{"B3", new Slot("B3", new DrinkItem("Test Drink", 1.50M)) },
			{"D2", new Slot("D2", new GumItem("Test Gum", .85M)) }
		};

		[DataTestMethod]
		[DataRow("a1", false)]
		[DataRow("B3", true)]
		[DataRow("D2", true)]
		[DataRow("ff", false)]
		public void CheckToSeeIfValidProductSelectionTestWorksProperly(string selection, bool expectedResult)
		{
			VendingMachine vendingMachine = new VendingMachine(initialStock);

			bool result = vendingMachine.ValidProductSelection(selection);

			Assert.AreEqual(expectedResult, result);
		}
	}
}
