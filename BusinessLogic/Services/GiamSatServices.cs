using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Web;
using IPS.Data.SqlCe.Repositories;
using UnitSettingLibrary;

namespace BusinessLogic.Services
{
    public class GiamSatServices : IGiamSatServices
    {

        public DataTable ChiTietKeHoachVon(string maDonVi, long namKHV, long idDuAn)
        {
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            return giamSatDataTier.ChiTietKeHoachVon(mdv,nsd,pas,maDonVi,namKHV,idDuAn);
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

        public string ChiTietDuAnReturnString(string maDonVi, long idDuAn)
        {
            var sReturn = "";
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            var tableData = giamSatDataTier.ChiTietDuAn(mdv, nsd, pas, maDonVi, idDuAn);
            if (tableData != null && tableData.Rows.Count > 0)
            {
                sReturn = Common.ConvertTableToJsonString(tableData);
            }
            return sReturn;
        }

        public object[] TimKiemDuAn(SearchProjectSetting searchProjectSetting, int pageIndex = 1)
        {            
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            var objData = giamSatDataTier.TimKiemDuAn(mdv, nsd, pas, searchProjectSetting, pageIndex);
            return objData;
        }

        public object[] DanhSachDuAn(int pageIndex = 1)
        {
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            var objData = giamSatDataTier.DanhSachDuAn(mdv, nsd, pas, pageIndex);
            return objData;
        }

        public string DanhSachGiaiDoanKHVReturnString(string maDonVi, long idDuAn, long nam)
        {
            var sReturn = "";
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            var objData = giamSatDataTier.DanhSachGiaiDoanKHV(mdv, nsd, pas, maDonVi, idDuAn, nam);
            if (objData != null)
            {
                sReturn += objData[0] + "-" + objData[1] + "-" + Common.ConvertTableToJsonString(objData[2] as DataTable);                
            }
            return sReturn;
        }

        public string DanhSachGoiThauReturnString(string maDonVi, long idDuAn, int pageIndex = 1)
        {
            var sReturn = "";
            var giamSatDataTier = new GiamSatRepository();
            var mdv = "";
            var nsd = "";
            var pas = "";
            var objData = giamSatDataTier.DanhSachGoiThau(mdv, nsd, pas, maDonVi, idDuAn, pageIndex);
            if (objData != null)
            {
                sReturn += objData[0] + "-" + objData[1] + "-" + Common.ConvertTableToJsonString(objData[2] as DataTable);
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
            var objData = giamSatDataTier.DanhSachHopDong(mdv, nsd, pas, maDonVi, idGoiThau, pageIndex);
            if (objData != null)
            {
                sReturn += objData[0] + "-" + objData[1] + "-" + Common.ConvertTableToJsonString(objData[2] as DataTable);
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