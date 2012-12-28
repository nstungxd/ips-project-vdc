using BusinessLogic.Interfaces;
using System;
using UnitSettingLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IPS.Data.SqlCe.Repositories;

namespace BusinessLogic.Services
{
    public class DongBoDBServices : IDongBoDBServices
    {
        public ChangeResultSettings DongBoDBDauTu()
        {
            var dongboDataTier = new DongBoRepository();            
            return dongboDataTier.DongBoDBDauTu();
        }
    }
}