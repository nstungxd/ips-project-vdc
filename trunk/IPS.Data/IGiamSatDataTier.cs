using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitSettingLibrary;

namespace IPS.Data
{
    public interface IGiamSatDataTier
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DataTable DanhSachDonVi(string mdv, string nsd, string pas);

        /// <summary>
        /// lay danh sach nam ke hoach von de bind dropdownlist
        /// </summary>
        /// <returns></returns>
        DataTable NamKeHoachVon(string maDonVi, long idDuAn);   

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="namKHV"></param>
        /// <param name="idDuAn"></param>
        /// <returns></returns>
        DataTable ChiTietKeHoachVon(string mdv, string nsd, string pas, string maDonVi, long namKHV, long idDuAn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="idGoiThau"></param>
        /// <returns></returns>
        DataTable ChiTietMoiThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="idGoiThau"></param>
        /// <returns></returns>
        DataTable ChiTietMoThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="idGoiThau"></param>
        /// <returns></returns>
        DataTable ChiTietXetThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="idGoiThau"></param>
        /// <returns></returns>
        DataTable ChiTietGoiThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="idHopDong"></param>
        /// <returns></returns>
        DataTable ChiTietHopDong(string mdv, string nsd, string pas, string maDonVi, long idHopDong);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="idDuAn"></param>
        /// <returns></returns>
        DataTable ChiTietDuAn(string mdv, string nsd, string pas, string maDonVi, long idDuAn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="searchProjectSetting"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        object[] TimKiemDuAn(string mdv, string nsd, string pas, SearchProjectSetting searchProjectSetting, int pageSize, int pageIndex = 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        object[] DanhSachDuAn(string mdv, string nsd, string pas, int pageSize, int pageIndex = 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="idDuAn"></param>
        /// <param name="nam"></param>
        /// <returns></returns>
        DataTable DanhSachGiaiDoanKHV(string mdv, string nsd, string pas, string maDonVi, long idDuAn, int nam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="idDuAn"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        object[] DanhSachGoiThau(string mdv, string nsd, string pas, string maDonVi, long idDuAn, int pageSize, int pageIndex = 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="idGoiThau"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        object[] DanhSachHopDong(string mdv, string nsd, string pas, string maDonVi, long idGoiThau, int pageSize, int pageIndex = 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="idDuAn"></param>
        /// <param name="loaiNguonVon"></param>
        /// <returns></returns>
        ChangeResultSettings CapNhatLoaiNguonVon(string mdv, string nsd, string pas, string maDonVi, long idDuAn, long loaiNguonVon);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="loaiGiamSat"></param>
        /// <param name="listGiamSat"></param>
        /// <returns></returns>
        ChangeResultSettings GiamSat(string mdv, string nsd, string pas, long loaiGiamSat, List<GiamSatSetting> listGiamSat = null);
    }
}
