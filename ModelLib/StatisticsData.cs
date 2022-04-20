using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class StatisticsData
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public Action Action { get; set; }
        public DateTime Time { get; set; }

        public StatisticsData()
        {

        }

        public StatisticsData(int id, string userid, string username, Action action, DateTime time)
        {
            Id = id;
            UserId = userid;
            UserName = username;
            Action = action;
            Time = time;
        }

        public override string ToString()
        {
            return $"{Id}: {Action} by {UserName}({UserId}) at {Time}";
        }

        public override bool Equals(object obj)
        {
            return obj is StatisticsData data &&
                   UserId == data.UserId &&
                   UserName == data.UserName &&
                   Action == data.Action &&
                   Time == data.Time;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, UserId, UserName, Action, Time);
        }
    }
}
