using GasShipping.DataAgent;
using GasShipping.Model;
using NUnit.Framework;
using System.Collections.Generic;

namespace GasShipping.Test
{
    public class Test_DataAgent_FileAgent
    {
        Ship ship1;
        Ship ship2;
        Ship ship3;
        Ship ship4;
        string DEMO_FILE_NAME = "TEST.JSON";
        string DEMO_FILE_PATH = @"C:\Users\binma\source\repos\GasShipping\GasShipping.DataAgent\Files\";

        ShipsFactory TestShipFactory;
        string myString = @"[
  {
    ""ID"": 99,
    ""Name"": ""ship 99"",
    ""Location"": {
      ""X"": 99,
      ""Y"": 55
    },
    ""Total Capacity"": 56,
    ""Current Capacity"": 55
  }
]";
        [SetUp]
        public void Setup()
        {
            ship1 = new Ship(1, "ship 1", null, 10);
            ship2 = new Ship(2, "ship 2", new Location(2, 2), 20, 10);
            ship3 = new Ship(3, "ship 3", new Location(3, 3), 30, 20);
            ship4 = new Ship(4, "ship 4", new Location(4, 4), 40, 30);
            TestShipFactory = new ShipsFactory(new FileAgent(DEMO_FILE_NAME, DEMO_FILE_PATH));

        }
        public void CreateShipList()
        {
            TestShipFactory.Ships.AddRange(new List<Ship> { ship1, ship2, ship3, ship4 });
        }
        //[Test]
        //public void Test001_getCurrectDirctory()
        //{
        //    var path = Constants.PATH;
        //    Assert.IsNotNull(path);

        //}
        [Test]
        public void Test002_WriteStringToFile()
        {
            var fileAgent = new FileAgent(DEMO_FILE_NAME, DEMO_FILE_PATH);
            bool isTrue = fileAgent.WriteFile(myString);
            Assert.IsTrue(isTrue);

        }
        [Test]
        public void Test003_ReadStringFromFile()
        {
            var fileAgent = new FileAgent(DEMO_FILE_NAME, DEMO_FILE_PATH);
            string fromFile = fileAgent.ReadFile();
            Assert.IsNotNull(fromFile);
            Assert.AreEqual(myString, fromFile);

        }

        [Test]
        public void Test004_GetListOFobjectsToFIle()
        {
            CreateShipList();
            var stringTest = TestShipFactory.SetShipsToJSONString();
            var fileAgent = new FileAgent(DEMO_FILE_NAME, DEMO_FILE_PATH);
            bool isTrue = fileAgent.WriteFile(stringTest);

            string fromFile = fileAgent.ReadFile();
            Assert.IsTrue(isTrue);
            Assert.AreEqual(fromFile, stringTest);

        }
        [Test]
        public void Test005_GetListOFobjectsFromFIle()
        {
            CreateShipList();
            var stringTest = TestShipFactory.SetShipsToJSONString();
            var fileAgent = new FileAgent(DEMO_FILE_NAME, DEMO_FILE_PATH);
            bool isTrue = fileAgent.WriteFile(stringTest);
            string fromFile = fileAgent.ReadFile();
            Assert.IsTrue(isTrue);
            Assert.AreEqual(fromFile, stringTest);
        }
    }
}
