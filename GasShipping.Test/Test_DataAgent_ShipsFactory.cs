using NUnit.Framework;
using GasShipping.DataAgent;
using GasShipping.Model;
using System;
using System.Collections.Generic;

namespace GasShipping.Test
{
    public class Test_DataAgent_ShipsFactory
    {
        Ship ship1;
        Ship ship2;
        Ship ship3;
        Ship ship4;

        ShipsFactory TestShipFactory;
        [SetUp]
        public void Setup()
        {
             ship1 = new Ship(1, "ship 1", null, 10);
             ship2 = new Ship(2, "ship 2", new Location(2, 2), 20, 10);
            ship3 = new Ship(3, "ship 3", new Location(3, 3), 30, 20);
             ship4 = new Ship(4, "ship 4", new Location(4, 4), 40, 30);
            TestShipFactory = new ShipsFactory();
        }
        public void CreateShipList()
        {
            TestShipFactory.Ships.AddRange(new List<Ship> { ship1,ship2,ship3,ship4});
        }

        [Test]
        public void Test001_addShipIsNotEmpty()
        {
            TestShipFactory.AddShip(ship1);

            //Assert.IsTrue(1==TestShipFactory.Ships.Count);
            Assert.IsNotEmpty(TestShipFactory.Ships);
        }
        [Test]
        public void Test002_RemoveShipIsNotEmpty()
        {
            TestShipFactory.AddShip(ship1);
            TestShipFactory.RemoveShip(ship1);

            //Assert.IsTrue(1==TestShipFactory.Ships.Count);
            Assert.IsEmpty(TestShipFactory.Ships);
        }
        [Test]
        public void Test003_RemoveShipThrowsException()
        {
            TestShipFactory.AddShip(ship1);
            TestShipFactory.RemoveShip(ship1);

            Assert.IsEmpty(TestShipFactory.Ships);
            Assert.Catch<ArgumentNullException>(()=> TestShipFactory.RemoveShip(null));
        }
        [Test]
        public void Test004_RemoveNonExistingShip()
        {
            TestShipFactory.AddShip(ship1);
            TestShipFactory.RemoveShip(ship2);
            Assert.IsTrue(1 == TestShipFactory.Ships.Count);
        }

        [Test]
        public void Test005_returnAJSONString()
        {
            CreateShipList();
            var stringTest = TestShipFactory.GetShips();
            Assert.IsNotEmpty(stringTest);
        }
    }
}