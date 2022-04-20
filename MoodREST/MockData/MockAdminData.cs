using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodREST.MockData
{
    public static class MockAdminData
    {
        public static IEnumerable<Administrator> GetMockData()
        {
            var administrators = new List<Administrator>() {
                new Administrator(1, "Admin-1", "Test1234"),
                new Administrator(2, "Admin-2", "Test1234"),
                new Administrator(3, "Admin-3", "Test1234"),
                new Administrator(4, "Admin-4", "Test1234"),
                new Administrator(5, "Admin-5", "Test1234"),
                new Administrator(6, "Admin-6", "Test1234"),
                new Administrator(7, "Admin-7", "Test1234"),
            };
            return administrators;
        }
    }
}
