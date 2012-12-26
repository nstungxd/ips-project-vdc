using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPS.Model;

namespace IPS.Data.SqlCe.Repositories
{
    public class UserRepository
    {
        public IEnumerable<User> GetAll()
        {
            List<User> listUser = new List<User>();
            return listUser;
        }
    }
}
