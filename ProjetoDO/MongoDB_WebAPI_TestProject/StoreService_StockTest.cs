using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB_WebAPI.Models;
using MongoDB_WebAPI.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MongoDB_WebAPI_TestProject
{
    [TestClass]
    public class StoreService_StockTest
    {
        private IDatabaseSettings _settings = new DatabaseSettings();
        private ICollectionNames _collections = new CollectionNames();
        [TestInitialize]
        public void Initalize()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            IConfiguration config = builder.Build();
            _settings.ConnectionString = config.GetSection("DatabaseSettings").GetValue<string>("ConnectionString");
            _settings.DatabaseName = config.GetSection("DatabaseSettings").GetValue<string>("DatabaseName");
            _collections.StoresCollection = config.GetSection("CollectionNames").GetValue<string>("StoresCollection");
            _collections.StocksCollection = config.GetSection("CollectionNames").GetValue<string>("StocksCollection");
            _collections.ProductsCollection = config.GetSection("CollectionNames").GetValue<string>("ProductsCollection");
            _collections.FamiliesCollection = config.GetSection("CollectionNames").GetValue<string>("FamiliesCollection");
        }

        [TestMethod]
        public void CreateStockTestMethod()
        {
            // Prepare
            Store store = new Store()
            {
                Id = "L01",
                StoreName = "Lisbon 01",
                StoreAddress = "Rua Dr.Eduardo Neves, 3, 1050 - 077 Lisboa, Portugal",
                Active = true,
                CreatedDate = DateTime.Now
            };
            Family fruits = new Family()
            {
                FamilyId = "FRUIT",
                FamilyName = "Fruits"
            };
            Product apple = new Product()
            {
                ProductId = 1,
                ProductName = "Apple",
                FamilyId = "FRUIT",
                UnitMeasure = "kg",
                UnitPrice = 1.99M,
                Discontinued = false,
                DateCreated = DateTime.Now
            };

            Stock appleStock = new Stock()
            {
                StockId=1,
                ProductId=1,
                StoreId="L01",
                Quantity=10,
                CreatedDate=DateTime.Now
            };

            StoreService ss = new StoreService(_settings, _collections);

            //Execute
            ss.CreateStore(store);
            ss.CreateFamily(fruits);
            ss.CreateProduct(apple);
            ss.CreateStock(appleStock);
            Stock dbStock = ss.GetStock(appleStock.StockId);

            //Assert
            Assert.AreEqual(appleStock.ProductId, dbStock.ProductId);
            Assert.AreEqual(appleStock.StoreId, dbStock.StoreId);
            Assert.AreEqual(appleStock.Quantity, dbStock.Quantity);
            Assert.AreEqual(appleStock.CreatedDate, dbStock.CreatedDate);
        }
        [TestMethod]
        public void UpdateFieldTestMethod()
        {
            // Prepare
            Product orange = new Product()
            {
                ProductId = 2,
                ProductName = "Orange",
                FamilyId = "FRUIT",
                UnitMeasure = "kg",
                UnitPrice = 1.59M,
                Discontinued = false,
                DateCreated = DateTime.Now
            };
            StoreService ss = new StoreService(_settings, _collections);
            ss.CreateProduct(orange);
            Stock oldStock = ss.GetStock(1);
            DateTime? oldCreatedDate = oldStock.CreatedDate;
            var modifiedDate = DateTime.Now;
            oldStock.ProductId = 2;
            oldStock.Quantity = 15;
            oldStock.ModifiedDate = modifiedDate;

            //Execute
            ss.UpdateStock(1, oldStock);
            Stock dbStock = ss.GetStock(1);

            //Assert
            Assert.AreEqual(dbStock.StoreId, oldStock.StoreId);
            Assert.AreEqual(oldStock.ProductId, dbStock.ProductId);
            Assert.AreEqual(dbStock.Quantity, oldStock.Quantity);
            Assert.AreEqual(dbStock.ModifiedDate, modifiedDate);
            Assert.AreEqual(oldCreatedDate, dbStock.CreatedDate);
        }
        [TestMethod]
        public void UpdateStockTestMethod()
        {
            // Prepare
            StoreService ss = new StoreService(_settings, _collections);
            Stock oldStock = ss.GetStock(1);
            Stock updatedStock = new Stock()
            {
                StockId = 1,
                ProductId = 1,
                StoreId = "L01",
                Quantity = 10,
                ModifiedDate = DateTime.Now,
                CreatedDate = oldStock.CreatedDate
            };

            //Execute
            ss.UpdateStock(1, updatedStock);
            Stock dbStock = ss.GetStock(updatedStock.StockId);

            //Assert
            Assert.AreEqual(updatedStock.StoreId, dbStock.StoreId);
            Assert.AreEqual(updatedStock.ProductId, dbStock.ProductId);
            Assert.AreEqual(updatedStock.Quantity, dbStock.Quantity);
            Assert.AreEqual(updatedStock.ModifiedDate, dbStock.ModifiedDate);
            Assert.AreEqual(updatedStock.CreatedDate, dbStock.CreatedDate);
        }
        [TestMethod]
        public void ListStockTestMethod()
        {
            // Prepare
            Stock orangeStock = new Stock()
            {
                StockId = 2,
                ProductId = 2,
                StoreId = "L01",
                Quantity = 15,
                CreatedDate = DateTime.Now
            };
            StoreService ss = new StoreService(_settings, _collections);
            ss.CreateStock(orangeStock);
            Stock dbStock = ss.GetStock(2);

            //Execute
            List<Stock> dbStocks = ss.GetStocks();

            //Assert
            Assert.AreEqual(dbStocks.Count, 2);
            Assert.AreEqual(dbStocks[1].StoreId, dbStock.StoreId);
            Assert.AreEqual(dbStocks[1].ProductId, dbStock.ProductId);
            Assert.AreEqual(dbStocks[1].Quantity, dbStock.Quantity);
            Assert.AreEqual(dbStocks[1].CreatedDate, dbStock.CreatedDate);
        }
        [TestMethod]
        public void RemoveStockTestMethod()
        {
            // Prepare
            StoreService ss = new StoreService(_settings, _collections);

            //Execute
            ss.RemoveStock(1);
            List<Stock> dbStocks = ss.GetStocks();

            //Assert
            Assert.AreEqual(dbStocks.Count, 1);

            //Execute
            ss.RemoveStock(2);
            dbStocks = ss.GetStocks();

            //Assert
            Assert.AreEqual(dbStocks.Count, 0);
        }
    }
}
