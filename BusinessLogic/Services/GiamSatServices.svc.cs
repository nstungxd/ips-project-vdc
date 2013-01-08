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
        private int PageSize = 20;

        public KeHoachVonModel ChiTietKeHoachVon(string mdv, string nsd, string pas, string maDonVi, long namKHV, long idDuAn)
        {
            var giamSatDataTier = new GiamSatRepository();           
            var data = giamSatDataTier.ChiTietKeHoachVon(mdv, nsd, pas, maDonVi, namKHV, idDuAn);
            return new KeHoachVonModel();
        }

        public ThongTinMoiThauModel ChiTietMoiThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau)
        {
            var giamSatDataTier = new GiamSatRepository();           
            var data = giamSatDataTier.ChiTietMoiThau(mdv, nsd, pas, maDonVi, idGoiThau);
            return new ThongTinMoiThauModel();
        }

        public ThongTinMoThauModel ChiTietMoThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau)
        {
            var giamSatDataTier = new GiamSatRepository();           
            var data = giamSatDataTier.ChiTietMoThau(mdv, nsd, pas, maDonVi, idGoiThau);
            return new ThongTinMoThauModel();
        }

        public ThongTinXetThauModel ChiTietXetThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau)
        {
            var giamSatDataTier = new GiamSatRepository();            
            var data = giamSatDataTier.ChiTietXetThau(mdv, nsd, pas, maDonVi, idGoiThau);
            return new ThongTinXetThauModel();
        }


        public GoiThauModel ChiTietGoiThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau)
        {            
            var giamSatDataTier = new GiamSatRepository();            
            var tableData = giamSatDataTier.ChiTietGoiThau(mdv, nsd, pas, maDonVi, idGoiThau);
            return new GoiThauModel();
        }

        public HopDongModel ChiTietHopDong(string mdv, string nsd, string pas, string maDonVi, long idHopDong)
        {          
            var giamSatDataTier = new GiamSatRepository();            
            var tableData = giamSatDataTier.ChiTietHopDong(mdv, nsd, pas, maDonVi, idHopDong);
            return new HopDongModel();
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
                            duan.LoaiNguonVon = Convert.ToInt32(dr["loai_nguon_von"]);
                            duan.LoaiPhanCap = dr["phancap"].ToString();
                            duan.MaDonVi = dr["ma_dvi"].ToString();
                            duan.MaDuAn = dr["ma"].ToString();
                            duan.NamBatDau = Convert.ToInt32(dr["nambd"]);
                            duan.NamKetThuc = Convert.ToInt32(dr["namkt"]);
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
                            duan.LoaiNguonVon = Convert.ToInt32(dr["loai_nguon_von"]);
                            duan.LoaiPhanCap = dr["phancap"].ToString();
                            duan.MaDonVi = dr["ma_dvi"].ToString();
                            duan.MaDuAn = dr["ma"].ToString();
                            duan.NamBatDau = Convert.ToInt32(dr["nambd"]);
                            duan.NamKetThuc = Convert.ToInt32(dr["namkt"]);
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

        public List<KeHoachVonShortModel> DanhSachGiaiDoanKHV(string mdv, string nsd, string pas, string maDonVi, long idDuAn, int nam)
        {
            try
            {
                var listKeHoachVon = new List<KeHoachVonShortModel>();
                var giamSatDataTier = new GiamSatRepository();
                var tableData = giamSatDataTier.DanhSachGiaiDoanKHV(mdv, nsd, pas, maDonVi, idDuAn, nam);                    

                if (tableData.Rows.Count > 0)
                {
                    foreach (DataRow dr in tableData.Rows)
                    {
                        var khv = new KeHoachVonShortModel();
                        khv.MaDonVi = maDonVi;
                        khv.IdDuAn = idDuAn;
                        khv.NamKHV = nam;
                        khv.Dot = Convert.ToInt32(dr["dot"]);
                        khv.SoQuyetDinh = dr["so_qd"].ToString();                   
                        khv.TinhTrangXoa = Convert.ToInt32(dr["khv_xoa"]);
                        // kiem tra tinh trang thuc hien cua ke hoach von
                            // da phe duyet ke hoach von
                        if (khv.SoQuyetDinh != " ")
                            khv.TrangThaiThucHien = "pd";
                            // da tham dinh ke hoach von
                        else if (dr["td_noi"].ToString() != "0" || dr["td_ngoai"].ToString() != "0")
                            khv.TrangThaiThucHien = "td";
                            // da dang ky ke hoach von
                        else khv.TrangThaiThucHien = "dk";

                        // check giai doan von da duoc giam sat chua
                        if (!dr.IsNull("giamsat_id"))
                        {
                            khv.IdGiamSat = Convert.ToInt64(dr["giamsat_id"]);
                            khv.GiaiDoanKHV = Convert.ToInt32(dr["ma_gd_khv"]);
                            khv.KetQuaGiamSat = Convert.ToInt32(dr["ma_kq_gs"]);
                            khv.GhiChuGiamSat = dr["ghi_chu"].ToString();
                        }
                        listKeHoachVon.Add(khv);
                    }
                }
                return listKeHoachVon;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ListGoiThauModelGridView DanhSachGoiThau(string mdv, string nsd, string pas, string maDonVi, long idDuAn, int pageIndex = 1)
        {
            try
            {
                PageSize = 3;
                var listGoiThau = new ListGoiThauModelGridView();
                var giamSatDataTier = new GiamSatRepository();
                var objData = giamSatDataTier.DanhSachGoiThau(mdv, nsd, pas, maDonVi, idDuAn, PageSize, pageIndex);
                if (objData != null)
                {
                    var list = new List<GoiThauShortModel>();
                    var pageSetting = new PaginationSetting
                                          {
                                              // 1 ban ghi phan ra moi thau, mo thau, xet thau nen total reocord phai nhan voi 3
                                              PageSize = PageSize*3,
                                              TotalRecords = Convert.ToInt64(objData[1])*3
                                          };
                    listGoiThau.TotalPage = pageSetting.TotalPage;
                    listGoiThau.TotalRecords = pageSetting.TotalRecords;
                    var table = objData[0] as DataTable;
                    if (table != null && table.Rows.Count > 0)
                    {
                        var listId = new List<long>();
                        foreach (DataRow dr in table.Rows)
                        {
                            var id = Convert.ToInt64(dr["id_goithau"]);
                            if (listId.Exists(element => element == id)) break;
                            listId.Add(id);

                            var hinhthuc = dr["hinhthuc_dauthau"].ToString();
                            var xoa = Convert.ToInt32(dr["goithau_xoa"]);
                            var ten = dr["ten_goithau"].ToString();

                            var goithau = new GoiThauShortModel();
                            goithau.IdDuAn = idDuAn;
                            goithau.MaDonVi = maDonVi;
                            goithau.IdGoiThau = id;
                            goithau.HinhThucDauThau = hinhthuc;
                            goithau.TinhTrangXoa = xoa;
                            goithau.TenGoiThau = ten;
                            goithau.TenGiaiDoan = "Mời thầu";
                            goithau.GiaiDoanDauThau = (int) GiaiDoanChonNhaThau.MoiThau;
                            list.Add(goithau);

                            goithau = new GoiThauShortModel();
                            goithau.IdDuAn = idDuAn;
                            goithau.MaDonVi = maDonVi;
                            goithau.IdGoiThau = id;
                            goithau.HinhThucDauThau = hinhthuc;
                            goithau.TinhTrangXoa = xoa;
                            goithau.TenGoiThau = ten;
                            goithau.GiaiDoanDauThau = (int) GiaiDoanChonNhaThau.MoThau;
                            goithau.TenGiaiDoan = "Mở thầu";
                            list.Add(goithau);

                            goithau = new GoiThauShortModel();
                            goithau.IdDuAn = idDuAn;
                            goithau.MaDonVi = maDonVi;
                            goithau.IdGoiThau = id;
                            goithau.HinhThucDauThau = hinhthuc;
                            goithau.TinhTrangXoa = xoa;
                            goithau.TenGoiThau = ten;
                            goithau.GiaiDoanDauThau = (int) GiaiDoanChonNhaThau.XetThau;
                            goithau.TenGiaiDoan = "Xét thầu";
                            list.Add(goithau);
                        }
                        foreach (var l in list)
                        {
                            foreach (DataRow dr in table.Rows)
                            {
                                if (l.IdGoiThau == Convert.ToInt64(dr["id_goithau"]))
                                {
                                    if (!dr.IsNull("id_giamsat"))
                                    {
                                        if (l.GiaiDoanDauThau == Convert.ToInt32(dr["ma_gd_gthau"]))
                                        {
                                            l.IdGiamSat = Convert.ToInt64(dr["id_giamsat"]);
                                            l.KetQuaGiamSat = Convert.ToInt32(dr["ma_kq_gs"]);
                                            l.GhiChuGiamSat = dr["ghi_chu"].ToString();
                                            //todo: xac dinh trang thai lai
                                            l.TrangThaiThucHien = "Hoàn thành";
                                            break;

                                        }
                                    }
                                }
                            }

                        }
                    }
                    listGoiThau.GoiThauModelsGridView = list;
                }
                return listGoiThau;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ListHopDongModelGridView DanhSachHopDong(string mdv, string nsd, string pas, string maDonVi, long idGoiThau, int pageIndex = 1)
        {
            try
            {
                var listHopDong = new ListHopDongModelGridView();
                PageSize = 10;
                var giamSatDataTier = new GiamSatRepository();
                var objData = giamSatDataTier.DanhSachHopDong(mdv, nsd, pas, maDonVi, idGoiThau, PageSize, pageIndex);
                if (objData != null)
                {
                    var list = new List<HopDongShortModel>();
                    var pageSetting = new PaginationSetting
                                          {
                                              PageSize = PageSize,
                                              TotalRecords = Convert.ToInt64(objData[1])
                                          };
                    listHopDong.TotalPage = pageSetting.TotalPage;
                    listHopDong.TotalRecords = pageSetting.TotalRecords;
                    var table = objData[0] as DataTable;
                    if (table != null && table.Rows.Count > 0)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            var hopdong = new HopDongShortModel();
                            hopdong.IdHopDong = Convert.ToInt64(dr["id_hopdong"]);
                            ;
                            hopdong.MaDonVi = maDonVi;
                            hopdong.IdGoiThau = idGoiThau;
                            hopdong.TenHopDong = dr["ten_hd"].ToString();
                            hopdong.BenA = dr["ben_a"].ToString();
                            hopdong.BenB = dr["ben_b"].ToString();
                            hopdong.TienNoiTe = Convert.ToInt64(dr["tien_nt"]);
                            hopdong.TienNgoaiTe = Convert.ToInt64(dr["id_hopdong"]);
                            hopdong.TinhTrangHopDong = dr["tinhtrang_hdo"].ToString();
                            hopdong.TinhTrangXoa = Convert.ToInt32(dr["tien_ngt"]);

                            // check giai doan von da duoc giam sat chua
                            if (!dr.IsNull("id_giamsat"))
                            {
                                hopdong.IdGiamSat = Convert.ToInt64(dr["id_giamsat"]);
                                hopdong.KetQuaGiamSat = Convert.ToInt32(dr["ma_kq_gs"]);
                                hopdong.GhiChuGiamSat = dr["ghi_chu"].ToString();
                            }
                            list.Add(hopdong);
                        }
                        listHopDong.HopDongModelsGridView = list;
                    }
                }
                return listHopDong;
            }
            catch (Exception)
            {
                return null;
            }
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

        public List<int> NamKeHoachVon(string maDonVi, long idDuAn)
        {
            var listNam = new List<int>();
            var giamSatDataTier = new GiamSatRepository();
            var tableData = giamSatDataTier.NamKeHoachVon(maDonVi,idDuAn);           
            if (tableData != null && tableData.Rows.Count > 0)
            {
                listNam.AddRange(from DataRow dr in tableData.Rows select Convert.ToInt32(dr["nam"]));
            }
            return listNam;
        }
    }
}
