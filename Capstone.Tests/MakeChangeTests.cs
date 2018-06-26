using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;
using Capstone.ItemsToVend;
using System.IO;

namespace Capstone.Tests
{
	[TestClass]
	public class MakeChangeTests
	{
		Dictionary<string, Slot> initialStock = new Dictionary<string, Slot>()
		{
			{ "A1", new Slot("A1", new GumItem("Test GUM", 1.0M)) }
		};

		[DataTestMethod]
            [DataRow(6.35, 25, 1, 0)]
            [DataRow(1.95, 7, 2, 0)]
            [DataRow(12.55, 50, 0, 1 )]
            public void Check_To_See_If_Change_Return_Works(double balance, int expectedQuarters, int expectedDimes, int expectedNickels)
            {
                VendingMachine vendingMachine = new VendingMachine(initialStock);
                vendingMachine.Balance = (decimal)balance;

                Change change = vendingMachine.MakeChange(vendingMachine.Balance);

                Assert.AreEqual(expectedQuarters, change.Quarters);
                Assert.AreEqual(expectedDimes, change.Dimes);
                Assert.AreEqual(expectedNickels, change.Nickels);
            }

            [TestMethod]
			public void Check_To_See_If_Change_Return_Leaves_Zero_Balance()
			{
				VendingMachine vendingMachine = new VendingMachine(initialStock);
				vendingMachine.Balance = 5.85M;

				vendingMachine.MakeChange(vendingMachine.Balance);
				decimal balance = vendingMachine.Balance;

				Assert.AreEqual(0.00M, balance);
			}
	}
}
