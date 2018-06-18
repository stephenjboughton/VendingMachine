using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Capstone.Tests
{
	[TestClass]
	public class ValidProductSelectionTest
	{
		[DataTestMethod]
		[DataRow("a1", false)]
		[DataRow("B3", true)]
		[DataRow("D2", true)]
		[DataRow("ff", false)]
		public void CheckToSeeIfValidProductSelectionTestWorksProperly(string selection, bool expectedResult)
		{
			string path = Path.Combine(Environment.CurrentDirectory, "vendingmachine.txt");
			Stocker stocker = new Stocker();
			VendingMachine vendingMachine = new VendingMachine(stocker.ReturnStock(path));

			bool result = vendingMachine.ValidProductSelection(selection);

			Assert.AreEqual(expectedResult, result);
		}
	}
}
