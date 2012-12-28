using System.ServiceModel;

namespace BusinessLogic.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBaoCaoServices" in both code and config file together.
    [ServiceContract]
    public interface IBaoCaoServices
    {
        [OperationContract]
        void DoWork();
    }
}
