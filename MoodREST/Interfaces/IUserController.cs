using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodREST.Interfaces
{
    interface IUserController
    {
        public List<Administrator> GetAll();
        public Administrator Get(int id);
        public Administrator Put(int id, Administrator user);
        public bool Post(Administrator user);
        public Administrator Delete(int id);
    }
}
