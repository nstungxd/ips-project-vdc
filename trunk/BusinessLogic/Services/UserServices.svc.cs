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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserServices.svc or UserServices.svc.cs at the Solution Explorer and start debugging.
    public class UserServices : IUserServices
    {

        public ChangeResultSettings CapNhatNhomNguoiDung(string mdv, string nsd, string pas, NhomNguoiDungModel nhomNguoiDung)
        {
            throw new NotImplementedException();
        }

        public List<NhomNguoiDungModel> DanhSachNhomNguoiDung(string mdv, string nsd, string pas, int moduleId, string maDonVi)
        {
            throw new NotImplementedException();
        }

        public NhomNguoiDungModel ChiTietNhomNguoiDung(string mdv, string nsd, string pas, string maDonVi, string maNhom)
        {
            throw new NotImplementedException();
        }

        public ChangeResultSettings XoaNhomNguoiDung(string mdv, string nsd, string pas, string maDonVi, long nhomId)
        {
            throw new NotImplementedException();
        }

        public ChangeResultSettings CapNhatNguoiDung(string mdv, string nsd, string pas, NguoiDungModel nguoiDung)
        {
            throw new NotImplementedException();
        }

        public List<NhomNguoiDungModel> DanhSachNguoiDung(string mdv, string nsd, string pas, string maDonVi)
        {
            throw new NotImplementedException();
        }

        public List<NhomNguoiDungModel> ChitietNguoiDung(string mdv, string nsd, string pas, string maDonVi, long nguoiDungId)
        {
            throw new NotImplementedException();
        }

        public ChangeResultSettings XoaNguoiDung(string mdv, string nsd, string pas, string maDonVi, long nhomNguoiDungId)
        {
            throw new NotImplementedException();
        }

        public ChangeResultSettings IsExistsUserName(string maDonVi, string tenNguoiDung)
        {
            throw new NotImplementedException();
        }

        public ChangeResultSettings IsExistsUserGroupName(int moduleId, string maDonVi, string tenNhom)
        {
            throw new NotImplementedException();
        }


        public ChangeResultSettings Login(string maDonVi, string userName, string pass)
        {
            try
            {
                var userDataTier = new UserRepository();
                var resultlogin = userDataTier.Login(maDonVi,userName,pass);
                return resultlogin;
            }
            catch (Exception)
            {
                return new ChangeResultSettings()
                           {
                               ChangeResult = ChangeResult.ThatBai,
                               Message = "Có lỗi trong quá trình đăng nhập. Vui lòng thử lại!"
                           };                
            }
        }
    }
}
