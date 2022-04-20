using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class Administrator
    {
        public Administrator()
        {

        }
        public Administrator(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Administrator administrator &&
                   Username == administrator.Username &&
                   Password == administrator.Password &&
                   Id == administrator.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Username, Password, Id);
        }
    }
}
