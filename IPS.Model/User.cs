using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS.Model
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            return users;
        }
    }
}
