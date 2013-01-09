using System;
using System.Data;
using UnitSettingLibrary;

namespace IPS.Data.SqlCe.Repositories
{
    public class UserRepository :IUser
    {

        public ChangeResultSettings CapNhatNhomNguoiDung(string mdv, string nsd, string pas, NhomNguoiDungModel nhomNguoiDung)
        {
            var result = new ChangeResultSettings();
            try
            {
                result.ChangeResult=ChangeResult.ThanhCong;
            }
            catch (Exception)
            {
                result.ChangeResult = ChangeResult.ThatBai;
            }
            return result;
        }

        public DataTable DanhSachNhomNguoiDung(string mdv, string nsd, string pas, int moduleId, string maDonVi)
        {
            throw new System.NotImplementedException();
        }

        public DataTable ChiTietNhomNguoiDung(string mdv, string nsd, string pas, string maDonVi, string maNhom)
        {
            throw new System.NotImplementedException();
        }

        public ChangeResultSettings XoaNhomNguoiDung(string mdv, string nsd, string pas, string maDonVi, long nhomId)
        {
            var result = new ChangeResultSettings();
            try
            {
                result.ChangeResult = ChangeResult.ThanhCong;
            }
            catch (Exception)
            {
                result.ChangeResult = ChangeResult.ThatBai;
            }
            return result;
        }

        public ChangeResultSettings CapNhatNguoiDung(string mdv, string nsd, string pas, NguoiDungModel nguoiDung)
        {
            var result = new ChangeResultSettings();
            try
            {
                result.ChangeResult = ChangeResult.ThanhCong;
            }
            catch (Exception)
            {
                result.ChangeResult = ChangeResult.ThatBai;
            }
            return result;
        }

        public DataTable DanhSachNguoiDung(string mdv, string nsd, string pas, string maDonVi)
        {
            throw new System.NotImplementedException();
        }

        public DataTable ChitietNguoiDung(string mdv, string nsd, string pas, string maDonVi, long nguoiDungId)
        {
            throw new System.NotImplementedException();
        }

        public ChangeResultSettings XoaNguoiDung(string mdv, string nsd, string pas, string maDonVi, long nhomNguoiDungId)
        {
            var result = new ChangeResultSettings();
            try
            {
                result.ChangeResult = ChangeResult.ThanhCong;
            }
            catch (Exception)
            {
                result.ChangeResult = ChangeResult.ThatBai;
            }
            return result;
        }

        public ChangeResultSettings IsExistsUserName(string maDonVi, string tenNguoiDung)
        {
            var result = new ChangeResultSettings();
            try
            {
                result.ChangeResult = ChangeResult.ThanhCong;
            }
            catch (Exception)
            {
                result.ChangeResult = ChangeResult.ThatBai;
            }
            return result;
        }

        public ChangeResultSettings IsExistsUserGroupName(int moduleId, string maDonVi, string tenNhom)
        {
            var result = new ChangeResultSettings();
            try
            {
                result.ChangeResult = ChangeResult.ThanhCong;
            }
            catch (Exception)
            {
                result.ChangeResult = ChangeResult.ThatBai;
            }
            return result;
        }
    }
}
