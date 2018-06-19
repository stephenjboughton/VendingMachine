using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Capstone.Tests
{
	[TestClass]
	public class ProductInStockTest
	{
		[DataTestMethod]
		[DataRow("A1", true)]
		[DataRow("A3", false)]
		[DataRow("D2", true)]
		public void CheckToSeeIfProductInStockMethodWorks(string selection, bool expectedResult)
		{
			string path = Path.Combine(Environment.CurrentDirectory, "vendingmachine.txt");
			Stocker stocker = new Stocker();
			VendingMachine vendingMachine = new VendingMachine(stocker.ReturnStock(path));

			vendingMachine.DispenseItem("A3");
			vendingMachine.DispenseItem("A3");
			vendingMachine.DispenseItem("A3");
			vendingMachine.DispenseItem("A3");
			vendingMachine.DispenseItem("A3");
			bool result = vendingMachine.ProductInStock(selection);

			Assert.AreEqual(expectedResult, result);
		}
	}
}
