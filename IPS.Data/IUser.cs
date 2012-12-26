using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IPS.Data
{
    public interface IUser
    {
        IEnumerable<IUser> GetAll();
    }
}
