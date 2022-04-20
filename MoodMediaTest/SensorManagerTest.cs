using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib;
using MoodREST.Interfaces;
using MoodREST.Managers;
using MoodREST.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodMediaTest
{
    [TestClass]
    public class SensorManagerTest
    {
        private ISensorManager _mgr;
            
        [TestInitialize]
        public void Setup()
        {
            _mgr = new SensorManager(MockSensorData.GetMockData());
        }

        [TestCleanup]
        public void CleanUp()
        {
            _mgr = new SensorManager(MockSensorData.GetMockData());
        }

        [TestMethod]
        public void Get_GetAllTest()
        {
            var expectedList = MockSensorData.GetMockData();
            var actualList = _mgr.Get();

            Assert.IsTrue(expectedList.SequenceEqual(actualList));
        }

        [TestMethod]
        public void Get_GetSingle_ValidIdTest()
        {
            var expectedData = new SensorData(1, "MockSensor 1", 20, 50, 800);
            var actualData = _mgr.Get(1);
            Assert.AreEqual(expectedData, actualData);

            expectedData = new SensorData(4, "MockSensor 1", 21, 66, 950);
            actualData = _mgr.Get(4);
            Assert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Get_GetSingle_InvalidIdTest()
        {
            _mgr.Get(0);
        }

        [TestMethod]
        public void CreateTest()
        {
            // Test that proper Id is given as well
            var newData = new SensorData(0, "MockSensor 3", 35, 80, 900);

            var result = _mgr.Create(newData);
            Assert.IsTrue(result);

            var dataAdded = _mgr.Get(8);

            newData.Id = 8; // Change id of new data to expected value given by manager
            Assert.AreEqual(newData, dataAdded);

            // Test that id gets overriden
            var newData2 = new SensorData(5, "MockSensor 3", 35, 80, 900);

            var result2 = _mgr.Create(newData2);
            Assert.IsTrue(result2);

            var dataAdded2 = _mgr.Get(9);

            newData.Id = 9; // Id should have counted up 1 higher than before
            Assert.AreEqual(newData2, dataAdded2);
        }

        [TestMethod]
        public void Update_ValidIdTest()
        {
            var newData = new SensorData(0, "MockSensor 3", 35, 80, 900);

            var result = _mgr.Update(6, newData);
            Assert.IsTrue(result);
            var updatedData = _mgr.Get(6);

            newData.Id = 6; // Expected id for equals
            Assert.AreEqual(newData, updatedData);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Update_InvalidIdTest()
        {
            var newData = new SensorData(0, "MockSensor 3", 35, 80, 900);

            _mgr.Update(0, newData);
        }

        [TestMethod]
        public void Delete_ValidIdTest()
        {
            var expectedDeletedData = new SensorData(1, "MockSensor 1", 20, 50, 800);
            var actualDeletedData = _mgr.Delete(1);

            Assert.AreEqual(expectedDeletedData, actualDeletedData);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Delete_InvalidIdTest()
        {
            _mgr.Delete(0);
        }
    }
}
