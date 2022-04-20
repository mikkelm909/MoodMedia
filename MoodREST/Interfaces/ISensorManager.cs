using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLib;

namespace MoodREST.Interfaces
{
    public interface ISensorManager
    {
        IEnumerable<SensorData> Get();
        SensorData Get(int id);
        bool Create(SensorData data);
        bool Update(int id, SensorData data);
        SensorData Delete(int id);
        SensorData GetLatest();
        IEnumerable<SensorData> GetByDates(DateTime from, DateTime to);
    }
}
