using IPS.Data.SqlCe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UnitSettingLibrary;

namespace BusinessLogic.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DongBoDBServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DongBoDBServices.svc or DongBoDBServices.svc.cs at the Solution Explorer and start debugging.
    public class DongBoDBServices : IDongBoDBServices
    {
        public ChangeResultSettings DongBoDBDauTu()
        {
            var dongboDataTier = new DongBoRepository();
            return dongboDataTier.DongBoDBDauTu();
        }
    }
}
