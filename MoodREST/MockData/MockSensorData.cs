using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodREST.MockData
{
    public class MockSensorData
    {
        public static IEnumerable<SensorData> GetMockData()
        {
            var data = new List<SensorData>() {
                new SensorData(1, "MockSensor 1", 10, 50, 800, new DateTime(2021,11,01,12,30,00)),
                new SensorData(2, "MockSensor 2", 21, 45, 900, new DateTime(2021,11,05,10,30,00)),
                new SensorData(3, "MockSensor 1", 23, 46.4, 850, new DateTime(2021,11,10,15,30,00)),
                new SensorData(4, "MockSensor 1", 21, 66, 950, new DateTime(2021,12,01,12,30,00)),
                new SensorData(5, "MockSensor 2", 22, 55, 1000, new DateTime(2021,12,04,14,30,00)),
                new SensorData(6, "MockSensor 1", 21.5, 49, 800, new DateTime(2021,12,15,12,30,00)),
                new SensorData(7, "MockSensor 2", 15, 51, 900, new DateTime(2021,12,20,12,30,00)),
            };
            return data;
        }
    }
}
