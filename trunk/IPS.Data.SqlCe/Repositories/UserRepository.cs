using IPS.Data.SqlCe.Initializers;
using Oracle.DataAccess.Client;
using System;
using System.Data;
using UnitSettingLibrary;

namespace IPS.Data.SqlCe.Repositories
{
    public class UserRepository :IUser
    {
        private OracleConnection _connectGs;
        private OracleDataAdapter _oracleAdapter;

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


        public ChangeResultSettings Login(string maDonVi, string userName, string pass)
        {
            var result = new ChangeResultSettings();
            try
            {
                ConnectDB.CloseConnection(_connectGs);
                _connectGs = new OracleConnection();
                _connectGs = ConnectDB.GetOracleConnection(_connectGs);
                var cm = _connectGs.CreateCommand();
                cm.CommandText = "usp_login";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new OracleParameter("mdv", OracleDbType.Varchar2)).Value = maDonVi;
                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = userName;
                cm.Parameters.Add(new OracleParameter("pas", OracleDbType.Varchar2)).Value = pass;
                // 0 chinh xac, 1 tai khoan da lock
                cm.Parameters.Add(new OracleParameter("cs_lke", OracleDbType.RefCursor)).Direction =
                    ParameterDirection.Output;

                var tableGs = new DataTable();
                _oracleAdapter = new OracleDataAdapter(cm);
                _oracleAdapter.Fill(tableGs);
                var resultLogin = 2;                
                if(tableGs.Rows.Count>0) resultLogin = Convert.ToInt32(tableGs.Rows[0]["khoa"]);
                switch (resultLogin)
                {
                    case 2:
                        result.ChangeResult = ChangeResult.ThatBai;
                        result.Message = "Tên hoặc mật khẩu không chính xác!";
                        break;
                    case 0:
                        result.ChangeResult = ChangeResult.ThanhCong;                        
                        break;
                    case 1:
                        result.ChangeResult = ChangeResult.ThatBai;
                        result.Message = "Tài khoản đã bị khóa. Vui lòng liên hệ với admin!";
                        break;
                    default:
                        throw new Exception();
                }                                
            }
            catch (Exception ex)
            {
                result.Message = "Có lỗi trong quá trình đăng nhập. Vui lòng thử lại!";
                result.ChangeResult = ChangeResult.ThatBai;
            }
            return result;
        }
    }
}
