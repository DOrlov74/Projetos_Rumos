using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloPOS;

namespace TestModeloPOS
{
    [TestClass]
    public class TestStoreService
    {
        [TestMethod]
        public void TestAddStore()
        {
            // Prepare
            StoreService batata = new StoreService();

            // Execute
            Store s = batata.AddStore("Loja1", "Porto");
            // Assert
            Assert.IsNotNull(s);
            Assert.AreEqual("Loja1", s.StoreName);
            Assert.AreEqual("Porto", s.City);

            // Execute
            Store ss = batata.AddStore("Loja1", "Porto");
            // Assert
            Assert.IsNull(ss);
        }
    }
}
