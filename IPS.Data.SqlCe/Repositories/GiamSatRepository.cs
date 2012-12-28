using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitSettingLibrary;

namespace IPS.Data.SqlCe.Repositories
{
    public class GiamSatRepository: IGiamSatDataTier
    {
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
            throw new NotImplementedException();
        }

        public DataTable ChiTietHopDong(string mdv, string nsd, string pas, string maDonVi, long idHopDong)
        {
            throw new NotImplementedException();
        }

        public DataTable ChiTietDuAn(string mdv, string nsd, string pas, string maDonVi, long idDuAn)
        {
            throw new NotImplementedException();
        }

        public object[] TimKiemDuAn(string mdv, string nsd, string pas, SearchProjectSetting searchProjectSetting, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public object[] DanhSachDuAn(string mdv, string nsd, string pas, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public object[] DanhSachGiaiDoanKHV(string mdv, string nsd, string pas, string maDonVi, long idDuAn, long nam)
        {
            throw new NotImplementedException();
        }

        public object[] DanhSachGoiThau(string mdv, string nsd, string pas, string maDonVi, long idDuAn, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public object[] DanhSachHopDong(string mdv, string nsd, string pas, string maDonVi, long idGoiThau, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public ChangeResultSettings CapNhatLoaiNguonVon(string mdv, string nsd, string pas, string maDonVi, long idDuAn, long loaiNguonVon)
        {
            throw new NotImplementedException();
        }

        public ChangeResultSettings GiamSat(string mdv, string nsd, string pas, long loaiGiamSat, List<GiamSatSetting> listGiamSat = null)
        {
            throw new NotImplementedException();
        }
    }
}
