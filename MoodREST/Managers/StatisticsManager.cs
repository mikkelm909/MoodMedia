using MoodREST.Interfaces;
using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodREST.Managers
{
    public class StatisticsManager
    {
        private static List<StatisticsData> _data;
        private static int _nextId = 1;

        public StatisticsManager()
        {
            _data = new List<StatisticsData>();
        }

        public IEnumerable<StatisticsData> Get()
        {
            return _data;
        }

        public StatisticsData Get(int id)
        {
            StatisticsData data = _data.Find(d => d.Id == id);
            return data ?? throw new KeyNotFoundException($"StatisticsData with id {id} not found.");
        }

        public bool Create(StatisticsData data)
        {
            data.Time = DateTime.Now;
            data.Id = _nextId++;
            _data.Add(data);
            return true;
        }

        public bool Update(int id, StatisticsData data)
        {
            try
            {
                StatisticsData dataToUpdate = Get(id);
                dataToUpdate.UserId = data.UserId;
                dataToUpdate.UserName = data.UserName;
                dataToUpdate.Action = data.Action;
                dataToUpdate.Time = data.Time;
                return true;
            }
            catch(KeyNotFoundException knfe)
            {
                throw new KeyNotFoundException(knfe.Message);
            }
        }

        public StatisticsData Delete(int id)
        {
            try
            {
                StatisticsData dataToDelete = Get(id);
                _data.Remove(dataToDelete);
                return dataToDelete;
            }
            catch (KeyNotFoundException knfe)
            {
                throw new KeyNotFoundException(knfe.Message);
            }
        }

        public IEnumerable<StatisticsData> GetByUserId(string userId)
        {
            return _data.Where(d => d.UserId == userId);
        }

        public IEnumerable<StatisticsData> GetByUrlPath(string path)
        {
            return _data.Where(d => d.Action.Url == path);
        }

        public IEnumerable<StatisticsData> GetByButton(string button)
        {
            return _data.Where(d => d.Action.Button == button);
        }

        public IEnumerable<StatisticsData> GetByDates(DateTime from, DateTime to)
        {
            return _data.Where(d => d.Time >= from && d.Time <= to);
        }

    }
}
