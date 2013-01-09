using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UnitSettingLibrary;

namespace BusinessLogic.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserServices" in both code and config file together.
    [ServiceContract]
    public interface IUserServices
    {
        /// <summary>
        /// them moi hoac cap nhat nhom nguoi dung
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="nhomNguoiDung"></param>
        /// <returns></returns>
        [OperationContract]
        ChangeResultSettings CapNhatNhomNguoiDung(string mdv, string nsd, string pas, NhomNguoiDungModel nhomNguoiDung);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="moduleId"></param>
        /// <param name="maDonVi"></param>
        /// <returns></returns>
        [OperationContract]
        List<NhomNguoiDungModel> DanhSachNhomNguoiDung(string mdv, string nsd, string pas, int moduleId, string maDonVi);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maNhom"></param>
        /// <param name="maDonVi"></param>
        /// <returns></returns>
        [OperationContract]
        NhomNguoiDungModel ChiTietNhomNguoiDung(string mdv, string nsd, string pas, string maDonVi, string maNhom);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="nhomId"></param>
        /// <returns></returns>
        [OperationContract]
        ChangeResultSettings XoaNhomNguoiDung(string mdv, string nsd, string pas, string maDonVi, long nhomId);

        /// <summary>
        /// them moi hoac cap nhat nguoi dung
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="nguoiDung"></param>
        /// <returns></returns>
        [OperationContract]
        ChangeResultSettings CapNhatNguoiDung(string mdv, string nsd, string pas, NguoiDungModel nguoiDung);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <returns></returns>
        [OperationContract]
        List<NhomNguoiDungModel> DanhSachNguoiDung(string mdv, string nsd, string pas, string maDonVi);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="nguoiDungId"></param>
        /// <returns></returns>
        [OperationContract]
        List<NhomNguoiDungModel> ChitietNguoiDung(string mdv, string nsd, string pas, string maDonVi, long nguoiDungId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="nhomNguoiDungId"></param>
        /// <returns></returns>
        [OperationContract]
        ChangeResultSettings XoaNguoiDung(string mdv, string nsd, string pas, string maDonVi, long nhomNguoiDungId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maDonVi"></param>
        /// <param name="tenNguoiDung"></param>
        /// <returns></returns>
        [OperationContract]
        ChangeResultSettings IsExistsUserName(string maDonVi, string tenNguoiDung);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="maDonVi"></param>
        /// <param name="tenNhom"></param>
        /// <returns></returns>
        [OperationContract]
        ChangeResultSettings IsExistsUserGroupName(int moduleId, string maDonVi, string tenNhom);
    }
}
