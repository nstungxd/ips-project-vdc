﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPS.Model;

namespace IPS.Data.SqlCe.Repositories
{
    public class UserRepository :IUser
    {
        public IEnumerable<IUser> GetAll()
        {
            var listUser = new List<IUser>();
            return listUser;
        }
    }
}