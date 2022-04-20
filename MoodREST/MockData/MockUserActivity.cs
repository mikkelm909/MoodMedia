using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodREST.MockData
{
    public static class MockUserActivity
    {
        public static IEnumerable<UserActivity> GetMockData()
        {
            var userActivities = new List<UserActivity>() {
                new UserActivity(1, 3, 4, 5),
                new UserActivity(2, 10, 9, 2),
                new UserActivity(3, 20, 6, 30),
                new UserActivity(4, 2, 4, 5),
                new UserActivity(5, 1, 1, 1),
            };
            return userActivities;
        }
    }
}
