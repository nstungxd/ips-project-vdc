using System.ServiceModel;
using UnitSettingLibrary;

namespace BusinessLogic.Interfaces
{
    [ServiceContract]
    public interface IDongBoDBServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ChangeResultSettings DongBoDBDauTu();
    }
}
