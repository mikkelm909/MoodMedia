using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodREST.Managers;
using MoodREST.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodMediaTest
{
    [TestClass]
    public class AdministratorManagerTests
    {
        private AdministratorManager _administratorManager;

        [TestInitialize]
        public void Setup()
        {
            _administratorManager = new AdministratorManager(MockAdminData.GetMockData());
        }

        [DataTestMethod]
        [DataRow("admin-1", "Test1234")]
        [DataRow("admin-2", "Test1234")]
        [DataRow("admin-3", "Test1234")]
        [DataRow("admin-4", "Test1234")]
        public void ValidateAuthetication(string username, string password)
        {
            Assert.IsTrue(_administratorManager.ValidateAuthetication(username, password));
        }
    }
}
