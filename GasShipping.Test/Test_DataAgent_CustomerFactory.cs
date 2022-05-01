using System;
using System.Collections.Generic;
using NUnit.Framework;
using GasShipping.DataAgent;
using GasShipping.Model;
using Microsoft.VisualStudio.CodeCoverage;

namespace GasShipping.Test
{
    public class Test_DataAgent_CustomerFactory
    {
        string DEMO_FILE_NAME = "TEST.JSON";
        string DEMO_FILE_PATH = @"C:\Users\binma\source\repos\GasShipping\GasShipping.DataAgent\Files\";
        Customers customer1;
        Customers customer2;
        Customers customer3;
        Customers customer4;
        CustomerFactory TestCustomerFactory;
        string myString = @"[
  {
    ""Id"": 11,
    ""Name"": ""customer11"",
    ""Location"": {
      ""X"": 11,
      ""Y"": 11
    },
    ""CustomerType"": 1,
    ""Quantity"": 11.1
  }
]";

        [SetUp]
        public void Setup()
        {
            customer1 = new Customers(1, "customer1", new Location(10, 10), 0, 10.5);
            customer2 = new Customers(2, "customer2", new Location(20, 20), 0, 20.5);
            customer3 = new Customers(3, "customer3", new Location(30, 30), 0, 30.5);
            customer4 = new Customers(4, "customer4", new Location(40, 40), 0, 40.5);
            TestCustomerFactory = new CustomerFactory(new FileAgent(DEMO_FILE_NAME, DEMO_FILE_PATH));
        }

        public void CreateCustomerList()
        {
            TestCustomerFactory.Customers.AddRange(new List<Customers> { customer1,customer2,customer3,customer4});
        }
        [Test]

        public void Test001_addCustomerIsNotEmpty()
        {
            TestCustomerFactory.AddCustomer(customer1);
            Assert.IsNotEmpty(TestCustomerFactory.Customers);
        }
        [Test]
        public void Test002_RemoveCustomerIsNotEmpty()
        {
            TestCustomerFactory.AddCustomer(customer1);
            TestCustomerFactory.RemoveCustomer(customer1);

            //Assert.IsTrue(1==TestShipFactory.Ships.Count);
            Assert.IsEmpty(TestCustomerFactory.Customers);
        }
        [Test]
        public void Test003_RemoveCustomerThrowsException()
        {
            TestCustomerFactory.AddCustomer(customer1);
            TestCustomerFactory.RemoveCustomer(customer1);

            Assert.IsEmpty(TestCustomerFactory.Customers);
            Assert.Catch<ArgumentNullException>(() => TestCustomerFactory.RemoveCustomer(null));
        }
        [Test]
        public void Test004_RemoveNonExistingCustomer()
        {
            TestCustomerFactory.AddCustomer(customer1);
            TestCustomerFactory.RemoveCustomer(customer2);
            Assert.IsTrue(1 == TestCustomerFactory.Customers.Count);
        }
        [Test]
        public void Test005_returnJSONString()
        {
            CreateCustomerList();
            var stringTest = TestCustomerFactory.SetCustomersToJSONString();
            Assert.IsNotEmpty(stringTest);
        }
        [Test]
        public void Test006_checkJSONFormatString()
        {
            var tempCustomer= new Customers(11, "customer11", new Location(11, 11), 1, 11.1);
            TestCustomerFactory.AddCustomer(tempCustomer);
            var outString = TestCustomerFactory.SetCustomersToJSONString();
            Assert.AreEqual(myString.Trim(), outString.Trim());
        }
        [Test]
        public void Test007_returnCustomerObjectFromJSONString()
        {
            var tempCustomer = TestCustomerFactory.GetShipsFromJSONString(myString);
            Assert.IsNotEmpty(tempCustomer);
            Assert.IsTrue(tempCustomer.Count == 1);
        }
        [Test]
        public void Test008_returnCustomerObjectFromJSONStringEqule()
        {
            var tempCustomers = TestCustomerFactory.GetShipsFromJSONString(myString);
            var tempCustomer = new Customers(11, "customer11", new Location(11, 11), 1, 11.1);
            TestCustomerFactory.AddCustomer(tempCustomer);
            Assert.AreEqual(tempCustomers[0].Id, TestCustomerFactory.Customers[0].Id);
        }
    }
}
