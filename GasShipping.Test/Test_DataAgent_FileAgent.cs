using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasShipping.DataAgent;

namespace GasShipping.Test
{
    public class Test_DataAgent_FileAgent
    {
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
            

        }
        [Test]
        public void Test001_getCurrectDirctory()
        {
            var path = Constants.PATH;
            Assert.IsNotNull(path);
           
        }
        [Test]
        public void Test002_WriteStringToFile()
        {
            var fileAgent=new FileAgent(Constants.SHIPS_FILE_NAME, Constants.PATH);
            bool isTrue=fileAgent.WriteFile(myString);
            Assert.IsTrue(isTrue);

        }
        [Test]
        public void Test003_ReadStringFromFile()
        {
            var fileAgent = new FileAgent(Constants.SHIPS_FILE_NAME, Constants.PATH);
            string fromFile = fileAgent.ReadFile();
            Assert.IsNotNull(fromFile);
            Assert.AreEqual(myString, fromFile);

        }
        //TODO: more testing.
    }
}
