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
        DataTable ChiTietKeHoachVon(string mdv, string nsd, string pas, string maDonVi, long namKHV, long idDuAn);

        DataTable ChiTietMoiThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau);

        DataTable ChiTietMoThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau);

        DataTable ChiTietXetThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau);

        DataTable ChiTietGoiThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau);

        DataTable ChiTietHopDong(string mdv, string nsd, string pas, string maDonVi, long idHopDong);

        DataTable ChiTietDuAn(string mdv, string nsd, string pas, string maDonVi, long idDuAn);

        object[] TimKiemDuAn(string mdv, string nsd, string pas, SearchProjectSetting searchProjectSetting, int pageIndex = 1);

        object[] DanhSachDuAn(string mdv, string nsd, string pas, int pageIndex = 1);

        object[] DanhSachGiaiDoanKHV(string mdv, string nsd, string pas, string maDonVi, long idDuAn, long nam);

        object[] DanhSachGoiThau(string mdv, string nsd, string pas, string maDonVi, long idDuAn, int pageIndex = 1);

        object[] DanhSachHopDong(string mdv, string nsd, string pas, string maDonVi, long idGoiThau, int pageIndex = 1);

        ChangeResultSettings CapNhatLoaiNguonVon(string mdv, string nsd, string pas, string maDonVi, long idDuAn, long loaiNguonVon);

        ChangeResultSettings GiamSat(string mdv, string nsd, string pas, long loaiGiamSat, List<GiamSatSetting> listGiamSat = null);
    }
}
