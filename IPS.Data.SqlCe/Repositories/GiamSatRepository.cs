using IPS.Data.SqlCe.Initializers;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitSettingLibrary;

namespace IPS.Data.SqlCe.Repositories
{
    public class GiamSatRepository : IGiamSatDataTier
    {
        private OracleConnection _connectGs;
        private OracleDataAdapter _oracleAdapter;

        public DataTable ChiTietKeHoachVon(string mdv, string nsd, string pas, string maDonVi, long namKHV, long idDuAn)
        {
            throw new NotImplementedException();
        }

        public DataTable ChiTietMoiThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau)
        {
            throw new NotImplementedException();
        }

        public DataTable ChiTietMoThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau)
        {
            throw new NotImplementedException();
        }

        public DataTable ChiTietXetThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau)
        {
            throw new NotImplementedException();
        }

        public DataTable ChiTietGoiThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau)
        {
            try
            {
                ConnectDB.CloseConnection(_connectGs);
                _connectGs = new OracleConnection();
                _connectGs = ConnectDB.GetOracleConnection(_connectGs);
                var cm = _connectGs.CreateCommand();
                cm.CommandText = "usp_ChiTiet_GoiThau";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new OracleParameter("ma_donvi", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("pas", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("id_goithau", OracleDbType.Long)).Value = idGoiThau;
                cm.Parameters.Add(new OracleParameter("ma_donvi_thuchien", OracleDbType.Varchar2)).Value = maDonVi;
                cm.Parameters.Add(new OracleParameter("cs_lke", OracleDbType.RefCursor)).Direction =
                    ParameterDirection.Output;

                var tableGs = new DataTable();
                _oracleAdapter = new OracleDataAdapter(cm);
                _oracleAdapter.Fill(tableGs);
                return tableGs;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ConnectDB.CloseConnection(_connectGs);
            }
        }

        public DataTable ChiTietHopDong(string mdv, string nsd, string pas, string maDonVi, long idHopDong)
        {
            try
            {
                ConnectDB.CloseConnection(_connectGs);
                _connectGs = new OracleConnection();
                _connectGs = ConnectDB.GetOracleConnection(_connectGs);
                var cm = _connectGs.CreateCommand();
                cm.CommandText = "usp_ChiTiet_HopDong";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new OracleParameter("ma_donvi", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("pas", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("id_hopdong", OracleDbType.Long)).Value = idHopDong;
                cm.Parameters.Add(new OracleParameter("ma_donvi_thuchien", OracleDbType.Varchar2)).Value = maDonVi;
                cm.Parameters.Add(new OracleParameter("cs_lke", OracleDbType.RefCursor)).Direction =
                    ParameterDirection.Output;

                var tableGs = new DataTable();
                _oracleAdapter = new OracleDataAdapter(cm);
                _oracleAdapter.Fill(tableGs);
                return tableGs;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ConnectDB.CloseConnection(_connectGs);
            }
        }

        public DataTable ChiTietDuAn(string mdv, string nsd, string pas, string maDonVi, long idDuAn)
        {
            try
            {
                ConnectDB.CloseConnection(_connectGs);
                _connectGs = new OracleConnection();
                _connectGs = ConnectDB.GetOracleConnection(_connectGs);
                var cm = _connectGs.CreateCommand();
                cm.CommandText = "usp_ChiTiet_DuAn";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new OracleParameter("ma_donvi", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("pas", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("id_duan", OracleDbType.Long)).Value = idDuAn;
                cm.Parameters.Add(new OracleParameter("ma_donvi_thuchien", OracleDbType.Varchar2)).Value = maDonVi;
                cm.Parameters.Add(new OracleParameter("cs_lke", OracleDbType.RefCursor)).Direction =
                    ParameterDirection.Output;

                var tableGs = new DataTable();
                _oracleAdapter = new OracleDataAdapter(cm);
                _oracleAdapter.Fill(tableGs);
                return tableGs;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ConnectDB.CloseConnection(_connectGs);
            }
        }

        public object[] TimKiemDuAn(string mdv, string nsd, string pas, SearchProjectSetting searchProjectSetting,
                                    int pageSize, int pageIndex = 1)
        {
            try
            {
                ConnectDB.CloseConnection(_connectGs);
                _connectGs = new OracleConnection();
                _connectGs = ConnectDB.GetOracleConnection(_connectGs);
                var cm = _connectGs.CreateCommand();
                cm.CommandText = "usp_TimKiem_DuAn";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new OracleParameter("ma_donvi", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("pas", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("ma_duan", OracleDbType.Varchar2)).Value =
                    searchProjectSetting.MaDuAn;
                cm.Parameters.Add(new OracleParameter("loai_duan", OracleDbType.Varchar2)).Value =
                    searchProjectSetting.LoaiDuAn;
                cm.Parameters.Add(new OracleParameter("nhom_duan", OracleDbType.Varchar2)).Value =
                    searchProjectSetting.NhomDuAn;
                cm.Parameters.Add(new OracleParameter("loai_nguonvon", OracleDbType.Long)).Value =
                    searchProjectSetting.LoaiNguonVon;
                cm.Parameters.Add(new OracleParameter("phancap", OracleDbType.Varchar2)).Value =
                    searchProjectSetting.PhanCap;
                cm.Parameters.Add(new OracleParameter("ma_donvi_quanly", OracleDbType.Varchar2)).Value =
                    searchProjectSetting.MaDonViQuanLy;
                cm.Parameters.Add(new OracleParameter("ma_donvi_thuchien", OracleDbType.Varchar2)).Value =
                    searchProjectSetting.MaDonViThucHien;
                cm.Parameters.Add(new OracleParameter("toantu_tongvon", OracleDbType.Varchar2)).Value =
                    searchProjectSetting.TongVonDauTuToanTu;
                cm.Parameters.Add(new OracleParameter("tongvon", OracleDbType.Long)).Value =
                    searchProjectSetting.TongVonDauTu;
                cm.Parameters.Add(new OracleParameter("toantu_nam_bd", OracleDbType.Varchar2)).Value =
                    searchProjectSetting.NamBatDauToanTu;
                cm.Parameters.Add(new OracleParameter("nam_bd", OracleDbType.Long)).Value =
                    searchProjectSetting.NamBatDau;
                cm.Parameters.Add(new OracleParameter("toantu_nam_kt", OracleDbType.Varchar2)).Value =
                    searchProjectSetting.NamKetThucToanTu;
                cm.Parameters.Add(new OracleParameter("nam_kt", OracleDbType.Long)).Value =
                    searchProjectSetting.NamKetThuc;
                cm.Parameters.Add(new OracleParameter("page_index", OracleDbType.Long)).Value = pageIndex;
                cm.Parameters.Add(new OracleParameter("page_size", OracleDbType.Long)).Value = pageSize;
                var op = new OracleParameter("total_record", OracleDbType.Long, 15)
                             {Direction = ParameterDirection.Output};
                cm.Parameters.Add(op);
                cm.Parameters.Add(new OracleParameter("cs_lke", OracleDbType.RefCursor)).Direction =
                    ParameterDirection.Output;

                var tableGs = new DataTable();
                _oracleAdapter = new OracleDataAdapter(cm);
                _oracleAdapter.Fill(tableGs);
                var totalRecord = cm.Parameters["total_record"].Value.ToString();
                var arrObject = new object[2];               
                arrObject[0] = tableGs;
                arrObject[1] = totalRecord;                
                return arrObject;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                ConnectDB.CloseConnection(_connectGs);
            }
        }

        public object[] DanhSachDuAn(string mdv, string nsd, string pas, int pageSize, int pageIndex = 1)
        {
            try
            {
                ConnectDB.CloseConnection(_connectGs);
                _connectGs = new OracleConnection();
                _connectGs = ConnectDB.GetOracleConnection(_connectGs);
                var cm = _connectGs.CreateCommand();
                cm.CommandText = "usp_DanhSach_DuAn";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new OracleParameter("ma_donvi", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("pas", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("page_index", OracleDbType.Long)).Value = pageIndex;
                cm.Parameters.Add(new OracleParameter("page_size", OracleDbType.Long)).Value = pageSize;
                var op = new OracleParameter("total_record", OracleDbType.Long, 15)
                             {Direction = ParameterDirection.Output};
                cm.Parameters.Add(op);
                cm.Parameters.Add(new OracleParameter("cs_lke", OracleDbType.RefCursor)).Direction =
                    ParameterDirection.Output;

                var tableGs = new DataTable();
                _oracleAdapter = new OracleDataAdapter(cm);
                _oracleAdapter.Fill(tableGs);
                var totalRecord = cm.Parameters["total_record"].Value.ToString();
                var arrObject = new object[2];                
                arrObject[0] = tableGs;
                arrObject[1] = totalRecord;                
                return arrObject;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ConnectDB.CloseConnection(_connectGs);
            }
        }

        public DataTable DanhSachGiaiDoanKHV(string mdv, string nsd, string pas, string maDonVi, long idDuAn, long nam)
        {
            try
            {
                ConnectDB.CloseConnection(_connectGs);
                _connectGs = new OracleConnection();
                _connectGs = ConnectDB.GetOracleConnection(_connectGs);
                var cm = _connectGs.CreateCommand();
                cm.CommandText = "usp_DanhSach_KHV";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new OracleParameter("ma_donvi", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("pas", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("ma_donvi_thuchien", OracleDbType.Varchar2)).Value = maDonVi;
                cm.Parameters.Add(new OracleParameter("nam_khv", OracleDbType.Long)).Value = nam;
                cm.Parameters.Add(new OracleParameter("id_duan", OracleDbType.Long)).Value = idDuAn;
                cm.Parameters.Add(new OracleParameter("cs_lke", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

                var tableGs = new DataTable();
                _oracleAdapter = new OracleDataAdapter(cm);
                _oracleAdapter.Fill(tableGs);
                return tableGs;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ConnectDB.CloseConnection(_connectGs);
            }
        }

        public object[] DanhSachGoiThau(string mdv, string nsd, string pas, string maDonVi, long idDuAn, int pageSize, int pageIndex = 1)
        {
            try
            {
                ConnectDB.CloseConnection(_connectGs);
                _connectGs = new OracleConnection();
                _connectGs = ConnectDB.GetOracleConnection(_connectGs);
                var cm = _connectGs.CreateCommand();
                cm.CommandText = "usp_DanhSach_GoiThau";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new OracleParameter("ma_donvi", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("pas", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("ma_donvi_thuchien", OracleDbType.Varchar2)).Value = maDonVi;
                cm.Parameters.Add(new OracleParameter("id_duan", OracleDbType.Long)).Value = idDuAn;
                cm.Parameters.Add(new OracleParameter("page_index", OracleDbType.Long)).Value = pageIndex;
                cm.Parameters.Add(new OracleParameter("page_size", OracleDbType.Long)).Value = pageSize;
                var op = new OracleParameter("total_record", OracleDbType.Long, 15) { Direction = ParameterDirection.Output };
                cm.Parameters.Add(op);
                cm.Parameters.Add(new OracleParameter("cs_lke", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

                var tableGs = new DataTable();
                _oracleAdapter = new OracleDataAdapter(cm);
                _oracleAdapter.Fill(tableGs);
                var totalRecord = cm.Parameters["total_record"].Value.ToString();
                var arrObject = new object[2];                
                arrObject[0] = tableGs;
                arrObject[1] = totalRecord;               
                return arrObject;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ConnectDB.CloseConnection(_connectGs);
            }
        }

        public object[] DanhSachHopDong(string mdv, string nsd, string pas, string maDonVi, long idGoiThau, int pageSize, int pageIndex = 1)
        {
            try
            {
                ConnectDB.CloseConnection(_connectGs);
                _connectGs = new OracleConnection();
                _connectGs = ConnectDB.GetOracleConnection(_connectGs);
                var cm = _connectGs.CreateCommand();
                cm.CommandText = "usp_DanhSach_HDO";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new OracleParameter("ma_donvi", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("pas", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("ma_donvi_thuchien", OracleDbType.Varchar2)).Value = maDonVi;
                cm.Parameters.Add(new OracleParameter("id_goithau", OracleDbType.Long)).Value = idGoiThau;
                cm.Parameters.Add(new OracleParameter("page_index", OracleDbType.Long)).Value = pageIndex;
                cm.Parameters.Add(new OracleParameter("page_size", OracleDbType.Long)).Value = pageSize;
                var op = new OracleParameter("total_record", OracleDbType.Long, 15) { Direction = ParameterDirection.Output };
                cm.Parameters.Add(op);
                cm.Parameters.Add(new OracleParameter("cs_lke", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

                var tableGs = new DataTable();
                _oracleAdapter = new OracleDataAdapter(cm);
                _oracleAdapter.Fill(tableGs);
                var totalRecord = cm.Parameters["total_record"].Value.ToString();
                var arrObject = new object[2];               
                arrObject[0] = tableGs;
                arrObject[1] = totalRecord;                
                return arrObject;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ConnectDB.CloseConnection(_connectGs);
            }
        }

        public ChangeResultSettings CapNhatLoaiNguonVon(string mdv, string nsd, string pas, string maDonVi, long idDuAn, long loaiNguonVon)
        {
            var result = new ChangeResultSettings();
            try
            {
                ConnectDB.CloseConnection(_connectGs);
                _connectGs = new OracleConnection();
                _connectGs = ConnectDB.GetOracleConnection(_connectGs);
                var cm = _connectGs.CreateCommand();
                cm.CommandText = "usp_CapNhat_DuAn_LoaiNguonVon";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new OracleParameter("ma_donvi", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("pas", OracleDbType.Varchar2)).Value = "";
                cm.Parameters.Add(new OracleParameter("id_duan", OracleDbType.Long)).Value = idDuAn;
                cm.Parameters.Add(new OracleParameter("ma_donvi_thuchien", OracleDbType.Varchar2)).Value = maDonVi;
                cm.Parameters.Add(new OracleParameter("loai_nguonvon", OracleDbType.Long)).Value = loaiNguonVon;
                var op = new OracleParameter("row_updated", OracleDbType.Long, 15) { Direction = ParameterDirection.Output };
                cm.Parameters.Add(op);
                cm.ExecuteNonQuery();
                var rowUpdated = cm.Parameters["row_updated"].Value.ToString();
                if (rowUpdated == "0")
                    result.ChangeResult = ChangeResult.ThatBai;
            }
            catch (Exception ex)
            {
                result.ChangeResult = ChangeResult.ThatBai;
                result.Message = ex.Message;
                throw;
            }
            return result;
        }

        public ChangeResultSettings GiamSat(string mdv, string nsd, string pas, long loaiGiamSat, List<GiamSatSetting> listGiamSat = null)
        {
            if (listGiamSat == null || listGiamSat.Count == 0) return null;
            var result = new ChangeResultSettings();
            try
            {
                ConnectDB.CloseConnection(_connectGs);
                _connectGs = new OracleConnection();
                _connectGs = ConnectDB.GetOracleConnection(_connectGs);
                var cm = _connectGs.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                switch (loaiGiamSat)
                {
                    case (long)LoaiGiamSat.GiamSatKHV:
                        foreach (var gs in listGiamSat)
                        {
                            if (gs.GiamSatID == 0)
                            {
                                cm.CommandText = "usp_GS_KHV_Insert";
                                cm.Parameters.Add(new OracleParameter("ma_donvi", OracleDbType.Varchar2)).Value = "";
                                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = "hoa";
                                cm.Parameters.Add(new OracleParameter("pas", OracleDbType.Varchar2)).Value = "";
                                cm.Parameters.Add(new OracleParameter("ma_donvi_thuchien", OracleDbType.Varchar2)).Value = gs.MaDonVi;
                                cm.Parameters.Add(new OracleParameter("id_duan", OracleDbType.Long)).Value = gs.DuAnID;
                                cm.Parameters.Add(new OracleParameter("nam_khv", OracleDbType.Long)).Value = gs.NamKHV;
                                cm.Parameters.Add(new OracleParameter("giaidoan_khv", OracleDbType.Long)).Value = gs.GiaiDoanKHV;
                                cm.Parameters.Add(new OracleParameter("kq_giamsat", OracleDbType.Long)).Value = gs.KetQuaGiamSat;
                                cm.Parameters.Add(new OracleParameter("ghichu_giamsat", OracleDbType.NVarchar2)).Value = gs.GhiChu;
                                cm.Parameters.Add(new OracleParameter("dot_khv", OracleDbType.Long)).Value = gs.DotKHV;
                                cm.Parameters.Add(new OracleParameter("so_quyetdinh", OracleDbType.Varchar2)).Value = gs.SoQD;
                                var op = new OracleParameter("row_inserted", OracleDbType.Long, 15) { Direction = ParameterDirection.Output };
                                cm.Parameters.Add(op);
                                cm.ExecuteNonQuery();
                                var rowInserted = cm.Parameters["row_inserted"].Value.ToString();
                                if (rowInserted == "" || rowInserted == "0")
                                    throw new Exception("Thêm mới bản ghi giám sát kế hoạch vốn thất bại");
                            }
                            else
                            {
                                cm.CommandText = "usp_GS_KHV_Update";
                                cm.Parameters.Add(new OracleParameter("ma_donvi", OracleDbType.Varchar2)).Value = "";
                                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = "hoa";
                                cm.Parameters.Add(new OracleParameter("pas", OracleDbType.Varchar2)).Value = "";
                                cm.Parameters.Add(new OracleParameter("id_giamsat", OracleDbType.Long)).Value = gs.GiamSatID;
                                cm.Parameters.Add(new OracleParameter("kq_giamsat", OracleDbType.Long)).Value = gs.KetQuaGiamSat;
                                cm.Parameters.Add(new OracleParameter("ghichu_giamsat", OracleDbType.NVarchar2)).Value = gs.GhiChu;
                                var op = new OracleParameter("row_updated", OracleDbType.Long, 15) { Direction = ParameterDirection.Output };
                                cm.Parameters.Add(op);
                                cm.ExecuteNonQuery();
                                var rowUpdated = cm.Parameters["row_updated"].Value.ToString();
                                if (rowUpdated == "" || rowUpdated == "0")
                                    result.ChangeResult = ChangeResult.ThatBai;
                            }
                        }
                        break;

                    case (long)LoaiGiamSat.GiamSatHopDong:
                        foreach (var gs in listGiamSat)
                        {
                            if (gs.GiamSatID == 0)
                            {
                                cm.CommandText = "usp_GS_HDO_Insert";
                                cm.Parameters.Add(new OracleParameter("ma_donvi", OracleDbType.Varchar2)).Value = "";
                                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = "hoa";
                                cm.Parameters.Add(new OracleParameter("pas", OracleDbType.Varchar2)).Value = "";
                                cm.Parameters.Add(new OracleParameter("ma_donvi_thuchien", OracleDbType.Varchar2)).Value = gs.MaDonVi;
                                cm.Parameters.Add(new OracleParameter("id_hopdong", OracleDbType.Long)).Value = gs.HopDongID;
                                cm.Parameters.Add(new OracleParameter("id_duan", OracleDbType.Long)).Value = gs.DuAnID;
                                cm.Parameters.Add(new OracleParameter("id_goithau", OracleDbType.Long)).Value = gs.GoiThauID;
                                cm.Parameters.Add(new OracleParameter("kq_giamsat", OracleDbType.Long)).Value = gs.KetQuaGiamSat;
                                cm.Parameters.Add(new OracleParameter("ghichu_giamsat", OracleDbType.NVarchar2)).Value = gs.GhiChu;
                                var op = new OracleParameter("row_inserted", OracleDbType.Long, 15) { Direction = ParameterDirection.Output };
                                cm.Parameters.Add(op);
                                cm.ExecuteNonQuery();
                                var rowInserted = cm.Parameters["row_inserted"].Value.ToString();
                                if (rowInserted == "" || rowInserted == "0")
                                    throw new Exception("Thêm mới bản ghi giám sát hợp đồng thất bại");
                            }
                            else
                            {
                                cm.CommandText = "usp_GS_HDO_Update";
                                cm.Parameters.Add(new OracleParameter("ma_donvi", OracleDbType.Varchar2)).Value = "";
                                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = "hoa";
                                cm.Parameters.Add(new OracleParameter("pas", OracleDbType.Varchar2)).Value = "";
                                cm.Parameters.Add(new OracleParameter("id_giamsat", OracleDbType.Long)).Value = gs.GiamSatID;
                                cm.Parameters.Add(new OracleParameter("kq_giamsat", OracleDbType.Long)).Value = gs.KetQuaGiamSat;
                                cm.Parameters.Add(new OracleParameter("ghichu_giamsat", OracleDbType.NVarchar2)).Value = gs.GhiChu;
                                var op = new OracleParameter("row_updated", OracleDbType.Long, 15) { Direction = ParameterDirection.Output };
                                cm.Parameters.Add(op);
                                cm.ExecuteNonQuery();
                                var rowUpdated = cm.Parameters["row_updated"].Value.ToString();
                                if (rowUpdated == "" || rowUpdated == "0")
                                    result.ChangeResult = ChangeResult.ThatBai;
                            }
                        }
                        break;

                    case (long)LoaiGiamSat.GiamSatChonNhaThau:
                        foreach (var gs in listGiamSat)
                        {
                            if (gs.GiamSatID == 0)
                            {
                                cm.CommandText = "usp_GS_GThau_Insert";
                                cm.Parameters.Add(new OracleParameter("ma_donvi", OracleDbType.Varchar2)).Value = "";
                                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = "hoa";
                                cm.Parameters.Add(new OracleParameter("pas", OracleDbType.Varchar2)).Value = "";
                                cm.Parameters.Add(new OracleParameter("ma_donvi_thuchien", OracleDbType.Varchar2)).Value = gs.MaDonVi;
                                cm.Parameters.Add(new OracleParameter("id_goithau", OracleDbType.Long)).Value = gs.GoiThauID;
                                cm.Parameters.Add(new OracleParameter("giaidoan_goithau", OracleDbType.Long)).Value = gs.GiaiDoanChonNhaThau;
                                cm.Parameters.Add(new OracleParameter("id_duan", OracleDbType.Long)).Value = gs.DuAnID;
                                cm.Parameters.Add(new OracleParameter("kq_giamsat", OracleDbType.Long)).Value = gs.KetQuaGiamSat;
                                cm.Parameters.Add(new OracleParameter("ghichu_giamsat", OracleDbType.NVarchar2)).Value = gs.GhiChu;
                                var op = new OracleParameter("row_inserted", OracleDbType.Long, 15) { Direction = ParameterDirection.Output };
                                cm.Parameters.Add(op);
                                cm.ExecuteNonQuery();
                                var rowInserted = cm.Parameters["row_inserted"].Value.ToString();
                                if (rowInserted == "" || rowInserted == "0")
                                    throw new Exception("Thêm mới bản ghi giám sát tiến trình lựa chọn nhà thầu thất bại");
                            }
                            else
                            {
                                cm.CommandText = "usp_GS_GThau_Update";
                                cm.Parameters.Add(new OracleParameter("ma_donvi", OracleDbType.Varchar2)).Value = "";
                                cm.Parameters.Add(new OracleParameter("nsd", OracleDbType.Varchar2)).Value = "hoa";
                                cm.Parameters.Add(new OracleParameter("pas", OracleDbType.Varchar2)).Value = "";
                                cm.Parameters.Add(new OracleParameter("id_giamsat", OracleDbType.Long)).Value = gs.GiamSatID;
                                cm.Parameters.Add(new OracleParameter("kq_giamsat", OracleDbType.Long)).Value = gs.KetQuaGiamSat;
                                cm.Parameters.Add(new OracleParameter("ghichu_giamsat", OracleDbType.NVarchar2)).Value = gs.GhiChu;
                                var op = new OracleParameter("row_updated", OracleDbType.Long, 15) { Direction = ParameterDirection.Output };
                                cm.Parameters.Add(op);
                                cm.ExecuteNonQuery();
                                var rowUpdated = cm.Parameters["row_updated"].Value.ToString();
                                if (rowUpdated == "" || rowUpdated == "0")
                                    result.ChangeResult = ChangeResult.ThatBai;
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                result.ChangeResult = ChangeResult.ThatBai;
                result.Message = ex.Message;
                throw;
            }
            return result;
        }
    }
}
