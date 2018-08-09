using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using Capstone.ItemsToVend;

namespace Capstone.Tests
{
	[TestClass]
	public class ProductInStockTest
	{
		Dictionary<string, Slot> initialStock = new Dictionary<string, Slot>()
		{
			{ "A1", new Slot("A1", new GumItem("Test GUM", 1.0M)) },
			{ "A3", new Slot("A3", new ChipItem("Test Chip", 1.50M)) }
		};

		[DataTestMethod]
		[DataRow("A1", false)]
		[DataRow("A3", true)]
		public void CheckToSeeIfProductInStockMethodWorks(string selection, bool expectedResult)
		{
			VendingMachine vendingMachine = new VendingMachine(initialStock);
			vendingMachine.DispenseItem("A1");
			vendingMachine.DispenseItem("A1");
			vendingMachine.DispenseItem("A1");
			vendingMachine.DispenseItem("A1");
			vendingMachine.DispenseItem("A1");
			bool result = vendingMachine.ProductInStock(selection);

			Assert.AreEqual(expectedResult, result);
		}
	}
}
