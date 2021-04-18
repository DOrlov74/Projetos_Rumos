using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB_WebAPI.Models;
using MongoDB_WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace MongoDB_WebAPI_TestProject
{
    [TestClass]
    public class StoreService_StoreTest
    {
        private IDatabaseSettings _settings=new DatabaseSettings();
        private ICollectionNames _collections=new CollectionNames();
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
        }

        [TestMethod]
        public void CreateStoreTestMethod()
        {
            // Prepare
            Store store = new Store() {
                Id = "L01",   
                StoreName = "Lisbon 01",
                StoreAddress = "Rua Dr.Eduardo Neves, 3, 1050 - 077 Lisboa, Portugal",
                Active = true,
                CreatedDate = DateTime.Now  
            };

            StoreService ss = new StoreService(_settings, _collections);
            
            //Execute
            ss.CreateStore(store);
            Store dbStore = ss.GetStore(store.Id);

            //Assert
            Assert.AreEqual(store.StoreName, dbStore.StoreName);
            Assert.AreEqual(store.StoreAddress, dbStore.StoreAddress);
            Assert.AreEqual(store.Active, true);
            Assert.AreEqual(store.CreatedDate, dbStore.CreatedDate);
        }
        [TestMethod]
        public void UpdateFieldTestMethod()
        {
            // Prepare
            StoreService ss = new StoreService(_settings, _collections);
            Store oldStore = ss.GetStore("L01");
            string oldStoreAddress = oldStore.StoreAddress;
            DateTime? oldCreatedDate = oldStore.CreatedDate;
            var modifiedDate = DateTime.Now;
            oldStore.StoreName= "Lisboa 02";
            oldStore.ModifiedDate = modifiedDate;

            //Execute
            ss.UpdateStore("L01", oldStore);
            Store dbStore = ss.GetStore("L01");

            //Assert
            Assert.AreEqual(dbStore.StoreName, "Lisboa 02");
            Assert.AreEqual(oldStoreAddress, dbStore.StoreAddress);
            Assert.AreEqual(dbStore.Active, true);
            Assert.AreEqual(dbStore.ModifiedDate, modifiedDate);
            Assert.AreEqual(oldCreatedDate, dbStore.CreatedDate);
        }
        [TestMethod]
        public void UpdateStoreTestMethod()
        {
            // Prepare
            StoreService ss = new StoreService(_settings, _collections);
            Store oldStore= ss.GetStore("L01");
            Store updatedStore = new Store()
            {
                Id = "L01",
                StoreName = "Porto 01",
                StoreAddress = "Rua Oliveira Monteiro, 168, 4050–438 Porto, Portugal",
                Active = true,
                ModifiedDate = DateTime.Now,
                CreatedDate=oldStore.CreatedDate
            };

            //Execute
            ss.UpdateStore("L01", updatedStore);
            Store dbStore = ss.GetStore(updatedStore.Id);

            //Assert
            Assert.AreEqual(updatedStore.StoreName, dbStore.StoreName);
            Assert.AreEqual(updatedStore.StoreAddress, dbStore.StoreAddress);
            Assert.AreEqual(updatedStore.Active, true);
            Assert.AreEqual(updatedStore.ModifiedDate, dbStore.ModifiedDate);
            Assert.AreEqual(updatedStore.CreatedDate, dbStore.CreatedDate);
        }
        [TestMethod]
        public void ListStoreTestMethod()
        {
            // Prepare
            StoreService ss = new StoreService(_settings, _collections);
            Store dbStore = ss.GetStore("L01");

            //Execute
            List<Store> dbStores = ss.GetStores();

            //Assert
            Assert.AreEqual(dbStores.Count, 2);
            Assert.AreEqual(dbStores[1].StoreName, dbStore.StoreName);
            Assert.AreEqual(dbStores[1].StoreAddress, dbStore.StoreAddress);
            Assert.AreEqual(dbStores[1].Active, true);
            Assert.AreEqual(dbStores[1].ModifiedDate, dbStore.ModifiedDate);
            Assert.AreEqual(dbStores[1].CreatedDate, dbStore.CreatedDate);
        }
        [TestMethod]
        public void RemoveStoreTestMethod()
        {
            // Prepare
            StoreService ss = new StoreService(_settings, _collections);

            //Execute
            ss.RemoveStore("L01");
            List<Store> dbStores = ss.GetStores();

            //Assert
            Assert.AreEqual(dbStores.Count, 1);
        }
    }
}
