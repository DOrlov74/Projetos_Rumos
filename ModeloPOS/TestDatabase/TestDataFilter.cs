using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloPOS;
using static DataBase.DatabaseService;
using System.Collections.Generic;
using System.Linq;

namespace TestDatabase
{
    [TestClass]
    public class TestDataFilter
    {
        [TestMethod]
        public void TestFilter()
        {
            // Prepare
            Store s1 = new Store();
            Store s2 = new Store();
            Product apple = new Product(s1) { Name = "Apple", Category = "Fruit", Stock = 3, Price = 5 };
            Product pear = new Product(s2) { Name = "Pear", Category = "Fruit", Stock = 5, Price = 8 };
            Product table = new Product(s1) { Name = "Table", Category = "Furniture", Stock = 2, Price = 20 };
            Product chair = new Product(s2) { Name = "Chair", Category = "Furniture", Stock = 4, Price = 12 };
            AddProduct(apple);
            AddProduct(pear);
            AddProduct(table);
            AddProduct(chair);

            //Execute
            ProductFilter pf = new ProductFilter();
            StoreSpecification storeSpec = new StoreSpecification(s1);
            IEnumerable<Product> store1Products = pf.Filter(storeSpec);
            
            // Assert
            foreach (Product p in store1Products)
            {
                Assert.AreEqual(s1, p.Store);
            }
            Assert.AreEqual(2, store1Products.Count());

            //Execute
            CategorySpecification catSpec = new CategorySpecification("Fruit");
            IEnumerable<Product> fruitProducts = pf.Filter(catSpec);

            // Assert
            foreach (Product p in fruitProducts)
            {
                Assert.AreEqual("Fruit", p.Category);
            }
            Assert.AreEqual(2, fruitProducts.Count());

            //Execute
            BrandSpecification brandSpec = new BrandSpecification("N/A");
            IEnumerable<Product> noBrandProducts = pf.Filter(brandSpec);

            // Assert
            foreach (Product p in noBrandProducts)
            {
                Assert.AreEqual("N/A", p.Brand);
            }
            Assert.AreEqual(4, noBrandProducts.Count());
        }
    }
}
