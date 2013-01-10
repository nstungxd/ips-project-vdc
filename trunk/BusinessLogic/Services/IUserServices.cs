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
        /// danh sach nhom nguoi dung
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
        /// chi tiet nhom nguoi dung
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
        /// xoa nhom nguoi dung
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
        /// lay danh sach nguoi dung
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <returns></returns>
        [OperationContract]
        List<NhomNguoiDungModel> DanhSachNguoiDung(string mdv, string nsd, string pas, string maDonVi);

        /// <summary>
        /// chi tiet nguoi dung
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
        /// xoa nguoi dung
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
        /// kiem tra ton tai ten nguoi dung
        /// </summary>
        /// <param name="maDonVi"></param>
        /// <param name="tenNguoiDung"></param>
        /// <returns></returns>
        [OperationContract]
        ChangeResultSettings IsExistsUserName(string maDonVi, string tenNguoiDung);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [OperationContract]
        ChangeResultSettings IsExistsEmail(string email);

        /// <summary>
        /// kiem tra ton tai ten nhom
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="maDonVi"></param>
        /// <param name="tenNhom"></param>
        /// <returns></returns>
        [OperationContract]
        ChangeResultSettings IsExistsUserGroupName(int moduleId, string maDonVi, string tenNhom);

        /// <summary>
        /// dang nhap he thong
        /// </summary>
        /// <param name="maDonVi"></param>
        /// <param name="userName"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [OperationContract]
        ChangeResultSettings Login(string maDonVi, string userName, string pass);
    }
}
