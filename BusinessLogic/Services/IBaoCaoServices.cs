using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BusinessLogic.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBaoCaoServices" in both code and config file together.
    [ServiceContract]
    public interface IBaoCaoServices
    {
        [OperationContract]
        void DoWork();
    }
}
