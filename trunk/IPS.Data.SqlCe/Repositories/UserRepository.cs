using IPS.Data.SqlCe.Initializers;
using Oracle.DataAccess.Client;
using System;
using System.Data;
using UnitSettingLibrary;

namespace IPS.Data.SqlCe.Repositories
{
    public class UserRepository :IUserDataTier
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

        public ChangeResultSettings XoaNguoiDung(string mdv, string nsd, string pas, string maDonVi, long nguoiDungId)
        {
            var result = new ChangeResultSettings();
            try
            {
                ConnectDB.CloseConnection(_connectGs);
                _connectGs = new OracleConnection();
                _connectGs = ConnectDB.GetOracleConnection(_connectGs);
                var cm = _connectGs.CreateCommand();
                cm.CommandText = "usp_user_delete";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new OracleParameter("mdv", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("pas", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("ma_dvi", OracleDbType.Varchar2)).Value = maDonVi;
                cm.Parameters.Add(new OracleParameter("so_id_xoa", OracleDbType.Long)).Value = nguoiDungId;
                var op = new OracleParameter("row_updated", OracleDbType.Long, 15) { Direction = ParameterDirection.Output };
                cm.Parameters.Add(op);
                cm.ExecuteNonQuery();
                var rowUpdated = cm.Parameters["row_updated"].Value.ToString();
                if (rowUpdated == "" || rowUpdated == "0")
                    result.ChangeResult = ChangeResult.ThatBai;
            }
            catch (Exception ex)
            {
                result.Message = "Có lỗi trong quá trình xóa người dùng. Vui lòng thử lại!";
                result.ChangeResult = ChangeResult.ThatBai;
            }
            return result;
        }

        public ChangeResultSettings IsExistsUserName(string maDonVi, string tenNguoiDung)
        {
            var result = new ChangeResultSettings();
            try
            {
                ConnectDB.CloseConnection(_connectGs);
                _connectGs = new OracleConnection();
                _connectGs = ConnectDB.GetOracleConnection(_connectGs);
                var cm = _connectGs.CreateCommand();
                cm.CommandText = "usp_check_exists_user";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new OracleParameter("ma_dvi_check", OracleDbType.Varchar2)).Value = maDonVi;
                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = tenNguoiDung;
                var op = new OracleParameter("total_result", OracleDbType.Long, 15) { Direction = ParameterDirection.Output };
                cm.Parameters.Add(op);
                cm.ExecuteNonQuery();
                var total = Convert.ToInt32(cm.Parameters["total_result"].Value.ToString());
                switch (total)
                {
                    case 0:
                        result.ChangeResult = ChangeResult.ThanhCong;
                        break;
                    default:
                        result.ChangeResult = ChangeResult.ThatBai;
                        break;
                }
            }
            catch (Exception ex)
            {
                result.Message = "Có lỗi trong quá trình kiểm tra tên đăng nhập. Vui lòng thử lại!";
                result.ChangeResult = ChangeResult.ThatBai;
            }
            return result;
        }

        public ChangeResultSettings IsExistsUserGroupName(string moduleId, string maDonVi, string maNhom)
        {
            var result = new ChangeResultSettings();
            try
            {
                ConnectDB.CloseConnection(_connectGs);
                _connectGs = new OracleConnection();
                _connectGs = ConnectDB.GetOracleConnection(_connectGs);
                var cm = _connectGs.CreateCommand();
                cm.CommandText = "usp_check_exists_usergroup";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new OracleParameter("moduleId", OracleDbType.Varchar2)).Value = moduleId;
                cm.Parameters.Add(new OracleParameter("ma_dvi_check", OracleDbType.Varchar2)).Value = maDonVi;
                cm.Parameters.Add(new OracleParameter("ma_nhom_check", OracleDbType.Varchar2)).Value = maNhom;
                var op = new OracleParameter("total_result", OracleDbType.Long, 15) { Direction = ParameterDirection.Output };
                cm.Parameters.Add(op);
                cm.ExecuteNonQuery();
                var total = Convert.ToInt32(cm.Parameters["total_result"].Value.ToString());
                switch (total)
                {
                    case 0:
                        result.ChangeResult = ChangeResult.ThanhCong;
                        break;
                    default:
                        result.ChangeResult = ChangeResult.ThatBai;
                        break;
                }
            }
            catch (Exception ex)
            {
                result.Message = "Có lỗi trong quá trình kiểm tra tên nhóm. Vui lòng thử lại!";
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
                cm.CommandText = "usp_check_login";
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


        public ChangeResultSettings IsExistsEmail(string email)
        {
            var result = new ChangeResultSettings();
            try
            {
                ConnectDB.CloseConnection(_connectGs);
                _connectGs = new OracleConnection();
                _connectGs = ConnectDB.GetOracleConnection(_connectGs);
                var cm = _connectGs.CreateCommand();
                cm.CommandText = "usp_check_exists_email";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new OracleParameter("email_check", OracleDbType.Varchar2)).Value = email;
                var op = new OracleParameter("total_result", OracleDbType.Long, 15) { Direction = ParameterDirection.Output };
                cm.Parameters.Add(op);
                cm.ExecuteNonQuery();
                var total = Convert.ToInt32(cm.Parameters["total_result"].Value.ToString());                              
                switch (total)
                {                    
                    case 0:
                        result.ChangeResult = ChangeResult.ThanhCong;
                        break;
                    default:
                        result.ChangeResult = ChangeResult.ThatBai;                       
                        break;                    
                }
            }
            catch (Exception ex)
            {
                result.Message = "Có lỗi trong quá trình kiểm tra email. Vui lòng thử lại!";
                result.ChangeResult = ChangeResult.ThatBai;
            }
            return result;
        }
    }
}
