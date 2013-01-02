using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UnitSettingLibrary;

namespace BusinessLogic.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDongBoDBServices" in both code and config file together.
    [ServiceContract]
    public interface IDongBoDBServices
    {
        [OperationContract]
        ChangeResultSettings DongBoDBDauTu();
    }
}
