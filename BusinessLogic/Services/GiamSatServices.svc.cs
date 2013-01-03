using IPS.Data.SqlCe.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UnitSettingLibrary;

namespace BusinessLogic.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GiamSatServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GiamSatServices.svc or GiamSatServices.svc.cs at the Solution Explorer and start debugging.
    public class GiamSatServices : IGiamSatServices
    {
        private const int PageSize = 20;

        public DataTable ChiTietKeHoachVon(string maDonVi, long namKHV, long idDuAn)
        {
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            return giamSatDataTier.ChiTietKeHoachVon(mdv, nsd, pas, maDonVi, namKHV, idDuAn);
        }

        public DataTable ChiTietMoiThau(string maDonVi, long idGoiThau)
        {
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            return giamSatDataTier.ChiTietMoiThau(mdv, nsd, pas, maDonVi, idGoiThau);
        }

        public DataTable ChiTietMoThau(string maDonVi, long idGoiThau)
        {
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            return giamSatDataTier.ChiTietMoThau(mdv, nsd, pas, maDonVi, idGoiThau);
        }

        public DataTable ChiTietXetThau(string maDonVi, long idGoiThau)
        {
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            return giamSatDataTier.ChiTietXetThau(mdv, nsd, pas, maDonVi, idGoiThau);
        }


        public string ChiTietGoiThauReturnString(string maDonVi, long idGoiThau)
        {
            var sReturn = "";
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            var tableData = giamSatDataTier.ChiTietGoiThau(mdv, nsd, pas, maDonVi, idGoiThau);
            if (tableData != null && tableData.Rows.Count > 0)
            {
                sReturn = Common.ConvertTableToJsonString(tableData);
            }
            return sReturn;
        }

        public string ChiTietHopDongReturnString(string maDonVi, long idHopDong)
        {
            var sReturn = "";
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            var tableData = giamSatDataTier.ChiTietHopDong(mdv, nsd, pas, maDonVi, idHopDong);
            if (tableData != null && tableData.Rows.Count > 0)
            {
                sReturn = Common.ConvertTableToJsonString(tableData);
            }
            return sReturn;
        }

        public DataTable ChiTietDuAn(string maDonVi, long idDuAn)
        {            
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            var tableData = giamSatDataTier.ChiTietDuAn(mdv, nsd, pas, maDonVi, idDuAn);
            return tableData;
        }

        public object[] TimKiemDuAn(SearchProjectSetting searchProjectSetting, int pageIndex = 1)
        {
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            var objData = giamSatDataTier.TimKiemDuAn(mdv, nsd, pas, searchProjectSetting, pageIndex, PageSize);
            return objData;
        }

        public object[] DanhSachDuAn(int pageIndex = 1)
        {
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            var objData = giamSatDataTier.DanhSachDuAn(mdv, nsd, pas, pageIndex, PageSize);
            return objData;
        }

        public string DanhSachGiaiDoanKHVReturnString(string maDonVi, long idDuAn, long nam)
        {
            var sReturn = "";
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            var tableData = giamSatDataTier.DanhSachGiaiDoanKHV(mdv, nsd, pas, maDonVi, idDuAn, nam);
            sReturn = Common.ConvertTableToJsonString(tableData);
            return sReturn;
        }

        public string DanhSachGoiThauReturnString(string maDonVi, long idDuAn, int pageIndex = 1)
        {
            var sReturn = "";
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            var objData = giamSatDataTier.DanhSachGoiThau(mdv, nsd, pas, maDonVi, idDuAn, pageIndex, PageSize);
            if (objData != null)
            {
                var pageSetting = new PaginationSetting
                {
                    PageSize = PageSize,
                    TotalRecords = Convert.ToInt64(objData[1])
                };
                sReturn += pageSetting.TotalRecords + "-" + pageSetting.TotalPage + "-" + Common.ConvertTableToJsonString(objData[0] as DataTable);
            }
            return sReturn;
        }

        public string DanhSachHopDongReturnString(string maDonVi, long idGoiThau, int pageIndex = 1)
        {
            var sReturn = "";
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            var objData = giamSatDataTier.DanhSachHopDong(mdv, nsd, pas, maDonVi, idGoiThau, pageIndex, PageSize);
            if (objData != null)
            {
                var pageSetting = new PaginationSetting
                {
                    PageSize = PageSize,
                    TotalRecords = Convert.ToInt64(objData[1])
                };
                sReturn += pageSetting.TotalRecords + "-" + pageSetting.TotalPage + "-" + Common.ConvertTableToJsonString(objData[0] as DataTable);
            }
            return sReturn;
        }

        public ChangeResultSettings CapNhatLoaiNguonVon(string maDonVi, long idDuAn, long loaiNguonVon)
        {
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            var objData = giamSatDataTier.CapNhatLoaiNguonVon(mdv, nsd, pas, maDonVi, idDuAn, loaiNguonVon);
            return objData;
        }

        public ChangeResultSettings GiamSat(long loaiGiamSat, List<GiamSatSetting> listGiamSat = null)
        {
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            var objData = giamSatDataTier.GiamSat(mdv, nsd, pas, loaiGiamSat, listGiamSat);
            return objData;
        }       
    }
}
