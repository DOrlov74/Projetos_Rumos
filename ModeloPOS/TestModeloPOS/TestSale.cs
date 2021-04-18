using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloPOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestModeloPOS
{
    [TestClass]
    public class TestSale
    {

        [TestMethod]
        public void TestAddSale()
        {
            // Prepare
            Store store = new Store();
            Product p1 = new Product(store) { Stock = 2, Price = 9 };
            Product p2 = new Product(store) { Stock = 3, Price = 12 };
            SaleLine sl1 = new SaleLine(p1, 2);
            SaleLine sl2 = new SaleLine(p2, 1);
            SaleLine sl3 = new SaleLine(p2, 2);
            Customer c = new Customer();
            Sale s = new Sale(c);

            // Execute
            s.AddLine(sl1);
            s.AddLine(sl2);
            // Assert
            Assert.AreEqual(2, s.Lines.Count);
            Assert.AreEqual(30, s.TotalPrice);

            // Execute
            s.AddLine(sl3);
            // Assert
            Assert.AreEqual(2, s.Lines.Count);
            Assert.AreEqual(3, s.Lines[1].Quantity);
            Assert.AreEqual(0, s.Lines[1].Product.Stock);
            Assert.AreEqual(54, s.TotalPrice);
        }
        [TestMethod]
        public void TestRemoveSale()
        {
            // Prepare
            Store store = new Store();
            Product p1 = new Product(store) { Stock = 2, Price = 9 };
            Product p2 = new Product(store) { Stock = 3, Price = 12 };
            SaleLine sl1 = new SaleLine(p1, 2);
            SaleLine sl2 = new SaleLine(p2, 1);
            SaleLine sl3 = new SaleLine(p2, 2);
            Customer c = new Customer();
            Sale s = new Sale(c);
            s.AddLine(sl1);
            s.AddLine(sl2);

            // Execute
            s.RemoveLine(sl3);

            // Assert
            Assert.AreEqual(2, s.Lines.Count);
            Assert.AreEqual(30, s.TotalPrice);

            // Execute
            s.RemoveLine(sl1);

            // Assert
            Assert.AreEqual(1, s.Lines.Count);
            Assert.AreEqual(12, s.TotalPrice);

            // Execute
            s.RemoveLine(sl2);
            // Assert
            Assert.AreEqual(0, s.Lines.Count);
            Assert.AreEqual(0, s.TotalPrice);
        }
        [TestMethod]
        public void TestIncreaseQuantity()
        {
            // Prepare
            Store store = new Store();
            Product p1 = new Product(store) { Stock = 2, Price = 9 };
            Product p2 = new Product(store) { Stock = 4, Price = 12 };
            SaleLine sl1 = new SaleLine(p1, 2);
            SaleLine sl2 = new SaleLine(p2, 1);
            SaleLine sl3 = new SaleLine(p2, 2);
            Customer c = new Customer();
            Sale s = new Sale(c);
            s.AddLine(sl1);
            s.AddLine(sl2);

            // Execute
            s.IncreaseQuantity(sl1);

            // Assert
            Assert.AreEqual(2, s.Lines[0].Quantity);
            Assert.AreEqual(30, s.TotalPrice);

            // Execute
            s.IncreaseQuantity(sl2);

            // Assert
            Assert.AreEqual(2, s.Lines[1].Quantity);
            Assert.AreEqual(42, s.TotalPrice);

            // Execute
            s.IncreaseQuantity(sl3);
            // Assert
            Assert.AreEqual(2, s.Lines.Count);
            Assert.AreEqual(42, s.TotalPrice);
        }
        [TestMethod]
        public void TestDecreaseQuantity()
        {
            // Prepare
            Store store = new Store();
            Product p1 = new Product(store) { Stock = 2, Price = 9 };
            Product p2 = new Product(store) { Stock = 4, Price = 12 };
            SaleLine sl1 = new SaleLine(p1, 2);
            SaleLine sl2 = new SaleLine(p2, 1);
            SaleLine sl3 = new SaleLine(p2, 2);
            Customer c = new Customer();
            Sale s = new Sale(c);
            s.AddLine(sl1);
            s.AddLine(sl2);

            // Execute
            s.DecreaseQuantity(sl1);

            // Assert
            Assert.AreEqual(1, s.Lines[0].Quantity);
            Assert.AreEqual(21, s.TotalPrice);

            // Execute
            s.DecreaseQuantity(sl2);

            // Assert
            Assert.AreEqual(1, s.Lines.Count);
            Assert.AreEqual(9, s.TotalPrice);

            // Execute
            s.DecreaseQuantity(sl3);

            // Assert
            Assert.AreEqual(1, s.Lines.Count);
            Assert.AreEqual(9, s.TotalPrice);
        }
    }
}
