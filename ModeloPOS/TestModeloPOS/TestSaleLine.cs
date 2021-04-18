using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloPOS;

namespace TestModeloPOS
{
    [TestClass]
    public class TestSaleLine
    {
        [TestMethod]
        public void TestSaleLineProperties()
        {
            // Prepare
            Store store = new Store();
            Product p = new Product(store);
            SaleLine sl = new SaleLine(p);

            // Execute
            sl.IncreaseQuantity(2);
            // Assert
            Assert.IsNotNull(sl.Product);
            Assert.AreNotEqual(2, sl.Quantity);
            Assert.AreEqual(0, sl.TotalPrice);

            // Execute
            p.Stock=2;
            p.Price = 15;
            sl.IncreaseQuantity(2);
            // Assert
            Assert.AreEqual(2, sl.Quantity);
            Assert.AreEqual(30, sl.TotalPrice);
            Assert.AreEqual(0, p.Stock);

            // Execute
            sl.DecreaseQuantity(2);
            // Assert
            Assert.AreEqual(0, sl.Quantity);
            Assert.AreEqual(0, sl.TotalPrice);
            Assert.AreEqual(2, p.Stock);
        }
    }
}
