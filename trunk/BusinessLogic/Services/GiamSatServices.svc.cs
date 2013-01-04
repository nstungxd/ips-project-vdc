using BusinessLogic.Models;
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

        public DataTable ChiTietKeHoachVon(string mdv, string nsd, string pas, string maDonVi, long namKHV, long idDuAn)
        {
            var giamSatDataTier = new GiamSatRepository();           
            return giamSatDataTier.ChiTietKeHoachVon(mdv, nsd, pas, maDonVi, namKHV, idDuAn);
        }

        public DataTable ChiTietMoiThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau)
        {
            var giamSatDataTier = new GiamSatRepository();           
            return giamSatDataTier.ChiTietMoiThau(mdv, nsd, pas, maDonVi, idGoiThau);
        }

        public DataTable ChiTietMoThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau)
        {
            var giamSatDataTier = new GiamSatRepository();           
            return giamSatDataTier.ChiTietMoThau(mdv, nsd, pas, maDonVi, idGoiThau);
        }

        public DataTable ChiTietXetThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau)
        {
            var giamSatDataTier = new GiamSatRepository();            
            return giamSatDataTier.ChiTietXetThau(mdv, nsd, pas, maDonVi, idGoiThau);
        }


        public string ChiTietGoiThauReturnString(string mdv, string nsd, string pas, string maDonVi, long idGoiThau)
        {
            var sReturn = "";
            var giamSatDataTier = new GiamSatRepository();            
            var tableData = giamSatDataTier.ChiTietGoiThau(mdv, nsd, pas, maDonVi, idGoiThau);
            if (tableData != null && tableData.Rows.Count > 0)
            {
                sReturn = Common.ConvertTableToJsonString(tableData);
            }
            return sReturn;
        }

        public string ChiTietHopDongReturnString(string mdv, string nsd, string pas, string maDonVi, long idHopDong)
        {
            var sReturn = "";
            var giamSatDataTier = new GiamSatRepository();            
            var tableData = giamSatDataTier.ChiTietHopDong(mdv, nsd, pas, maDonVi, idHopDong);
            if (tableData != null && tableData.Rows.Count > 0)
            {
                sReturn = Common.ConvertTableToJsonString(tableData);
            }
            return sReturn;
        }

        public string ChiTietDuAnReturnString(string mdv, string nsd, string pas, string maDonVi, long idDuAn)
        {
            var sReturn = "";
            var giamSatDataTier = new GiamSatRepository();           
            var tableData = giamSatDataTier.ChiTietDuAn(mdv, nsd, pas, maDonVi, idDuAn);
            if (tableData != null && tableData.Rows.Count > 0)
            {
                sReturn = Common.ConvertTableToJsonString(tableData);
            }
            return sReturn;
        }

        public ListDuAnModelGridView TimKiemDuAn(string mdv, string nsd, string pas, SearchProjectSetting searchProjectSetting, int pageIndex = 1)
        {
            try
            {
                var listDuAn = new ListDuAnModelGridView();
                var giamSatDataTier = new GiamSatRepository();
                var objData = giamSatDataTier.TimKiemDuAn(mdv, nsd, pas, searchProjectSetting, PageSize, pageIndex);
                if (objData != null)
                {
                    var list = new List<DuAnShortModel>();
                    var pageSetting = new PaginationSetting
                                          {
                                              PageSize = PageSize,
                                              TotalRecords = Convert.ToInt64(objData[1])
                                          };
                    listDuAn.TotalPage = pageSetting.TotalPage;
                    listDuAn.TotalRecords = pageSetting.TotalRecords;
                    var table = objData[0] as DataTable;
                    if (table != null && table.Rows.Count > 0)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            var duan = new DuAnShortModel();
                            duan.IdDuAn = Convert.ToInt64(dr["so_id"]);
                            duan.LoaiNguonVon = Convert.ToInt64(dr["loai_nguon_von"]);
                            duan.LoaiPhanCap = dr["phancap"].ToString();
                            duan.MaDonVi = dr["ma_dvi"].ToString();
                            duan.MaDuAn = dr["ma"].ToString();
                            duan.NamBatDau = Convert.ToInt64(dr["nambd"]);
                            duan.NamKetThuc = Convert.ToInt64(dr["namkt"]);
                            duan.NhomDuAn = dr["nhom_da"].ToString();
                            duan.TenDuAn = dr["ten"].ToString();
                            duan.TongVonDauTu = Convert.ToInt64(dr["tienqd"]);
                            list.Add(duan);
                        }
                        listDuAn.DuAnModelsGridView = list;
                    }
                }
                return listDuAn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ListDuAnModelGridView DanhSachDuAn(string mdv, string nsd, string pas, int pageIndex = 1)
        {
            try
            {
                var listDuAn = new ListDuAnModelGridView();
                var giamSatDataTier = new GiamSatRepository();
                var objData = giamSatDataTier.DanhSachDuAn(mdv, nsd, pas, PageSize, pageIndex);
                if (objData != null)
                {
                    var list = new List<DuAnShortModel>();
                    var pageSetting = new PaginationSetting
                    {
                        PageSize = PageSize,
                        TotalRecords = Convert.ToInt64(objData[1])
                    };
                    listDuAn.TotalPage = pageSetting.TotalPage;
                    listDuAn.TotalRecords = pageSetting.TotalRecords;
                    var table = objData[0] as DataTable;
                    if (table != null && table.Rows.Count > 0)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            var duan = new DuAnShortModel();
                            duan.IdDuAn = Convert.ToInt64(dr["so_id"]);
                            duan.LoaiNguonVon = Convert.ToInt64(dr["loai_nguon_von"]);
                            duan.LoaiPhanCap = dr["phancap"].ToString();
                            duan.MaDonVi = dr["ma_dvi"].ToString();
                            duan.MaDuAn = dr["ma"].ToString();
                            duan.NamBatDau = Convert.ToInt64(dr["nambd"]);
                            duan.NamKetThuc = Convert.ToInt64(dr["namkt"]);
                            duan.NhomDuAn = dr["nhom_da"].ToString();
                            duan.TenDuAn = dr["ten"].ToString();
                            duan.TongVonDauTu = Convert.ToInt64(dr["tienqd"]);
                            list.Add(duan);
                        }
                        listDuAn.DuAnModelsGridView = list;
                    }
                }
                return listDuAn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string DanhSachGiaiDoanKHVReturnString(string mdv, string nsd, string pas, string maDonVi, long idDuAn, long nam)
        {
            var giamSatDataTier = new GiamSatRepository();           
            var tableData = giamSatDataTier.DanhSachGiaiDoanKHV(mdv, nsd, pas, maDonVi, idDuAn, nam);            
            // them cot the hien trang thai thuc hien ke hoach von
            tableData.Columns.Add("TrangThaiThucHien", typeof (String));
            if(tableData.Rows.Count>0)
            {
                for (int i = 0; i < tableData.Rows.Count; i++)
                {
                    // da duoc phe duyet
                    if(tableData.Rows[i]["so_qd"].ToString()!=" ")
                    {
                        tableData.Rows[i]["TrangThaiThucHien"] = "PD";
                    }
                    // da duoc tham dinh
                    else if (tableData.Rows[i]["td_ngoai"].ToString() != "" || tableData.Rows[i]["td_noi"].ToString() != "")
                    {
                        tableData.Rows[i]["TrangThaiThucHien"] = "TD";
                    }
                    // da dang ky
                    else
                    {
                        tableData.Rows[i]["TrangThaiThucHien"] = "DK";
                    }
                }
            }
            string sReturn = Common.ConvertTableToJsonString(tableData);
            return sReturn;
        }

        public string DanhSachGoiThauReturnString(string mdv, string nsd, string pas, string maDonVi, long idDuAn, int pageIndex = 1)
        {
            var sReturn = "";
            var giamSatDataTier = new GiamSatRepository();
            var objData = giamSatDataTier.DanhSachGoiThau(mdv, nsd, pas, maDonVi, idDuAn, PageSize, pageIndex);
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

        public string DanhSachHopDongReturnString(string mdv, string nsd, string pas, string maDonVi, long idGoiThau, int pageIndex = 1)
        {
            var sReturn = "";
            var giamSatDataTier = new GiamSatRepository();
            var objData = giamSatDataTier.DanhSachHopDong(mdv, nsd, pas, maDonVi, idGoiThau, PageSize, pageIndex);
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

        public ChangeResultSettings CapNhatLoaiNguonVon(string mdv, string nsd, string pas, string maDonVi, long idDuAn, long loaiNguonVon)
        {
            var giamSatDataTier = new GiamSatRepository();          
            var objData = giamSatDataTier.CapNhatLoaiNguonVon(mdv, nsd, pas, maDonVi, idDuAn, loaiNguonVon);
            return objData;
        }

        public ChangeResultSettings GiamSat(string mdv, string nsd, string pas, long loaiGiamSat, List<GiamSatSetting> listGiamSat = null)
        {
            var giamSatDataTier = new GiamSatRepository();           
            var objData = giamSatDataTier.GiamSat(mdv, nsd, pas, loaiGiamSat, listGiamSat);
            return objData;
        }


        public List<DonViShortModel> DanhSachDonVi(string mdv, string nsd, string pas)
        {
            var listDonVi = new List<DonViShortModel>();
            var giamSatDataTier = new GiamSatRepository();            
            var tableData = giamSatDataTier.DanhSachDonVi(mdv, nsd, pas);
            var donvi = new DonViShortModel();
            donvi.TenDonVi = "--Chọn giá trị--";
            donvi.MaDonVi = "";
            listDonVi.Add(donvi);
            if (tableData != null && tableData.Rows.Count>0)
            {                
                foreach (DataRow dr in tableData.Rows)
                {
                    donvi = new DonViShortModel();
                    donvi.MaDonVi = dr["ma"].ToString();
                    donvi.TenDonVi = dr["ten"].ToString();
                    listDonVi.Add(donvi);
                }
            }
            return listDonVi;
        }
    }
}
