using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnitSettingLibrary;
using System.Data;

namespace IPS.Data
{
    public interface IUser
    {
        /// <summary>
        /// them moi hoac cap nhat nhom nguoi dung
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="nhomNguoiDung"></param>
        /// <returns></returns>       
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
        DataTable DanhSachNhomNguoiDung(string mdv, string nsd, string pas, int moduleId, string maDonVi);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maNhom"></param>
        /// <param name="maDonVi"></param>
        /// <returns></returns>        
        DataTable ChiTietNhomNguoiDung(string mdv, string nsd, string pas, string maDonVi, string maNhom);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="nhomId"></param>
        /// <returns></returns>        
        ChangeResultSettings XoaNhomNguoiDung(string mdv, string nsd, string pas, string maDonVi, long nhomId);

        /// <summary>
        /// them moi hoac cap nhat nguoi dung
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="nguoiDung"></param>
        /// <returns></returns>       
        ChangeResultSettings CapNhatNguoiDung(string mdv, string nsd, string pas, NguoiDungModel nguoiDung);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <returns></returns>       
        DataTable DanhSachNguoiDung(string mdv, string nsd, string pas, string maDonVi);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="nguoiDungId"></param>
        /// <returns></returns>        
        DataTable ChitietNguoiDung(string mdv, string nsd, string pas, string maDonVi, long nguoiDungId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="nhomNguoiDungId"></param>
        /// <returns></returns>        
        ChangeResultSettings XoaNguoiDung(string mdv, string nsd, string pas, string maDonVi, long nhomNguoiDungId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maDonVi"></param>
        /// <param name="tenNguoiDung"></param>
        /// <returns></returns>     
        ChangeResultSettings IsExistsUserName(string maDonVi, string tenNguoiDung);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="maDonVi"></param>
        /// <param name="tenNhom"></param>
        /// <returns></returns>       
        ChangeResultSettings IsExistsUserGroupName(int moduleId, string maDonVi, string tenNhom);

        ChangeResultSettings Login(string maDonVi, string userName, string pass);
    }
}
