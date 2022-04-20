using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib;
using MoodREST.Managers;

namespace MoodMediaTest
{
    [TestClass]
    public class UnitTestUserManger
    {
        private UserManager userManager;

        [TestInitialize]
        public void Setup()
        {
            userManager = new UserManager();
            userManager.TestSetup();
        }

        [TestMethod]
        public void GetAllTest()
        {
            List<User> actualUsers = userManager.GetAll();
            List<User> expectedUsers = new List<User>() {
                new User(0, "Mikkel", "solrød", "mikk568f@edu.zealand.dk", "B)", "1234"),
                new User(1, "Oscar", "Roskål", "oscar568f@edu.zealand.dk", "B)", "1234"),
                new User(2, "Steven", "Kan ikke huske", "steve568f@edu.zealand.dk", "B)", "1234"),
                new User(3, "Christopher", "Roskål", "chris568f@edu.zealand.dk", "B)", "1234"),
            };

            CollectionAssert.AreEqual(expectedUsers ,actualUsers);
        }

        [TestMethod]
        public void GetById()
        {
            User actualUser = userManager.Get(0);
            User expectedUser = new User(0, "Mikkel", "solrød", "mikk568f@edu.zealand.dk", "B)", "1234");

            Assert.AreEqual(expectedUser, actualUser);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetByFalseId()
        {
            User actualUser = userManager.Get(4);
        }

        [TestMethod]
        public void UpdateUser()
        {
            User updatedUser = new User(0, "John Dark Souls", "Soul", "dark68f@edu.zealand.dk", "B)", "jds");
            userManager.Update(0, updatedUser);

            Assert.AreEqual(updatedUser, userManager.Get(0));
            Assert.IsTrue(userManager.GetAll().Count() == 4);
        }

        [TestMethod]
        public void PostUser()
        {
            User newUser = new User(4, "John Dark Souls", "Soul", "dark68f@edu.zealand.dk", "B)", "jds");
            userManager.Post(newUser);

            Assert.IsTrue(userManager.GetAll().Count() == 5);
            Assert.AreEqual(newUser, userManager.Get(4));
        }

        [TestMethod]
        public void DeleteUser()
        {
            User removedUser = new User(0, "Mikkel", "solrød", "mikk568f@edu.zealand.dk", "B)", "1234");

            //Remove method also returns the deleted user
            Assert.AreEqual(removedUser, userManager.Remove(0));
            Assert.IsTrue(userManager.GetAll().Count() == 3);
        }
    }
}
