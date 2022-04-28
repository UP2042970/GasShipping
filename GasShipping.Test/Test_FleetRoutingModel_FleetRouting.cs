using GasShipping.FleetRoutingModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasShipping.Test
{
    public class Test_FleetRoutingModel_FleetRouting
    {
        FleetRouting FleetRouting { get; set; } 
        [SetUp]
        public void Setup()
        {
            FleetRouting = new();
        }

        [TearDown]  
        public void TearDown()
        {

        }

        [Test]
        public void Test_001_ComputeEuclideanDistanceMatrix_length()
        {
            int[,] vs = { { 2, -1 }, { -2, 2 } };
            var output = FleetRouting.ComputeEuclideanDistanceMatrix(vs);
            Assert.AreEqual(4, output.Length);
        }
        [Test]
        public void Test_002_ComputeEuclideanDistanceMatrix_CorrectOutput()
        {
            int[,] vs = { { 2, -1 }, { -2, 2 } };
            var output = FleetRouting.ComputeEuclideanDistanceMatrix(vs);
            long [,] temp = { { 0, 5 }, { 5, 0 } };
            Assert.AreEqual(temp,output);
        }
        [Test]
        public void Test_003_ComputeEuclideanDistanceMatrix_CorrectOutputBig()
        {
            int[,] vs = { { 1,2,3},{ 2,3,4},{0,1,2} };
            var output = FleetRouting.ComputeEuclideanDistanceMatrix(vs);
            long[,] temp = { { 0, 5 }, { 5, 0 } };
            Assert.AreNotEqual(temp, output);
        }

    }
}
