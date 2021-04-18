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
    public class StoreService_UserTest
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
            _collections.UsersCollection = config.GetSection("CollectionNames").GetValue<string>("UsersCollection");
        }

        [TestMethod]
        public void CreateUserTestMethod()
        {
            // Prepare
            User user = new User()
            {
                Id = 1,
                Name = "Admin",
                Address = "Rua Dr.Eduardo Neves, 3, 1050 - 077 Lisboa, Portugal",
                City = "Lisboa",
                Email="admin@gmail.com",
                Phone = "914555666",
                Password="abcd1234"
            };

            StoreService ss = new StoreService(_settings, _collections);

            //Execute
            ss.CreateUser(user);
            User dbUser = ss.GetUser(user.Id);

            //Assert
            Assert.AreEqual(user.Name, dbUser.Name);
            Assert.AreEqual(user.Address, dbUser.Address);
            Assert.AreEqual(user.Email, dbUser.Email);
            Assert.AreEqual(user.Phone, dbUser.Phone);
            Assert.AreEqual(user.Password, dbUser.Password);
        }
        [TestMethod]
        public void UpdateFieldTestMethod()
        {
            // Prepare
            StoreService ss = new StoreService(_settings, _collections);
            User oldUser = ss.GetUser(1);
            string oldAddress = oldUser.Address;
            string oldPhone = oldUser.Phone;
            oldUser.Address = "Avenida João Crisóstomo, 30 A, 1050-127 Lisboa, Portugal";
            oldUser.Phone = "914777888";

            //Execute
            ss.UpdateUser(1, oldUser);
            User dbUser = ss.GetUser(1);

            //Assert
            Assert.AreEqual(dbUser.Name, oldUser.Name);
            Assert.AreEqual(oldUser.Address, dbUser.Address);
            Assert.AreEqual(dbUser.Email, oldUser.Email);
            Assert.AreEqual(dbUser.Phone, oldUser.Phone);
            Assert.AreEqual(dbUser.Password, oldUser.Password);
        }
        [TestMethod]
        public void UpdateUserTestMethod()
        {
            // Prepare
            StoreService ss = new StoreService(_settings, _collections);
            User updatedUser = new User()
            {
                Id = 1,
                Name = "Administrator",
                Address = "Rua Oliveira Monteiro, 168, 4050–438 Porto, Portugal",
                City = "Porto",
                Email = "administrator@gmail.com",
                Phone = "914333222",
                Password="1234abcd"
            };

            //Execute
            ss.UpdateUser(1, updatedUser);
            User dbUser = ss.GetUser(updatedUser.Id);

            //Assert
            Assert.AreEqual(updatedUser.Name, dbUser.Name);
            Assert.AreEqual(updatedUser.Address, dbUser.Address);
            Assert.AreEqual(updatedUser.Email, dbUser.Email);
            Assert.AreEqual(updatedUser.Phone, dbUser.Phone);
            Assert.AreEqual(updatedUser.Password, dbUser.Password);
        }
        [TestMethod]
        public void ListUserTestMethod()
        {
            // Prepare
            User user = new User()
            {
                Id = 2,
                Name = "Customer",
                Address = "Av. Prof. Dr. Joaquim Veríssimo Serrão, nº 14 A, 2005-266 Santarém, Portugal",
                City = "Santarém",
                Email = "customer@gmail.com",
                Phone = "914111222",
                Password = "password"
            };
            StoreService ss = new StoreService(_settings, _collections);
            ss.CreateUser(user);

            //Execute
            List<User> dbUsers = ss.GetUsers();

            //Assert
            Assert.AreEqual(dbUsers.Count, 2);
            Assert.AreEqual(dbUsers[1].Name, user.Name);
            Assert.AreEqual(dbUsers[1].Address, user.Address);
            Assert.AreEqual(dbUsers[1].Email, user.Email);
            Assert.AreEqual(dbUsers[1].Phone, user.Phone);
            Assert.AreEqual(dbUsers[1].Password, user.Password);
        }
        [TestMethod]
        public void RemoveUserTestMethod()
        {
            // Prepare
            StoreService ss = new StoreService(_settings, _collections);

            //Execute
            ss.RemoveUser(1);
            List<User> dbUsers = ss.GetUsers();

            //Assert
            Assert.AreEqual(dbUsers.Count, 1);

            //Execute
            ss.RemoveUser(2);
            dbUsers = ss.GetUsers();

            //Assert
            Assert.AreEqual(dbUsers.Count, 0);
        }
    }
}
