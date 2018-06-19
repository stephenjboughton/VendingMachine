using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using Capstone.ItemsToVend;

namespace Capstone.Tests
{
	[TestClass]
	public class DispenseItemTests
	{
        Dictionary<string, Slot> initialStock = new Dictionary<string, Slot>()
        {
            { "A1", new Slot("A1", new GumItem("Test GUM", 1.0M)) }
        };
        VendingMachine vendingMachine;

        [TestInitialize]
        public void Initialize()
        {
            vendingMachine = new VendingMachine(initialStock);
        }


		[TestMethod]
		public void CheckToSeeIfDispenseItemReducesStock()
		{			
			vendingMachine.Balance = 5.00M;

			vendingMachine.DispenseItem("A1");

			Assert.AreEqual(4, initialStock["A1"].ItemsRemaining);
			Assert.AreEqual(4.0M, vendingMachine.Balance);
		}
	}
}
