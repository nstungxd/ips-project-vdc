using System.ServiceModel;
using UnitSettingLibrary;

namespace BusinessLogic.Interfaces
{
    [ServiceContract]
    public interface IDongBoDBServices
    {
        [OperationContract]
        ChangeResultSettings DongBoDBDauTu();
    }
}
