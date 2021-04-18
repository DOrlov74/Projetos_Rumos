using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloPOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestModeloPOS
{
    [TestClass]
    public class TestCustomer
    {
        [TestMethod]
        public void TestNewCustomer()
        {
            // Prepare
            Customer c1 = new Customer();
            Customer c2 = new Customer();
            // Execute

            // Assert
            Assert.AreEqual( 1, c1.CustomerId);
            Assert.AreEqual( 2, c2.CustomerId);

        }
    }
}
