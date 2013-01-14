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
        public KeHoachVonModel ChiTietKeHoachVon(string mdv, string nsd, string pas, string maDonVi, int namKHV, long idDuAn)
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

        public DuAnShortModel ChiTietDuAn(string mdv, string nsd, string pas, string maDonVi, long idDuAn)
        {
            try
            {                
                var giamSatDataTier = new GiamSatRepository();
                var tableData = giamSatDataTier.ChiTietDuAn(mdv, nsd, pas, maDonVi, idDuAn);
                if (tableData != null && tableData.Rows.Count > 0)
                {
                    var duAn = new DuAnShortModel();
                    duAn.IdDuAn = idDuAn;
                    duAn.MaDonVi = maDonVi;
                    duAn.MaDuAn = tableData.Rows[0]["ma"].ToString();
                    duAn.TenDuAn = tableData.Rows[0]["ten"].ToString();
                    duAn.LoaiNguonVon = (LoaiNguonVon)Convert.ToInt32(tableData.Rows[0]["loai_nguon_von"]);
                    duAn.LoaiPhanCap = (LoaiPhanCap)Enum.Parse(typeof(LoaiPhanCap), tableData.Rows[0]["phan_cap"].ToString());
                    duAn.NhomDuAn = (NhomDuAn)Enum.Parse(typeof(NhomDuAn), tableData.Rows[0]["nhom_da"].ToString());
                    duAn.MaLoaiDuAn = tableData.Rows[0]["loai"].ToString();
                    duAn.TenLoaiDuAn = tableData.Rows[0]["ten_loai_duan"].ToString();
                    duAn.NamBatDau = Convert.ToInt32(tableData.Rows[0]["nam_bd"]);
                    duAn.NamKetThuc = Convert.ToInt32(tableData.Rows[0]["nam_kt"]);
                    duAn.TongVonDauTu = Convert.ToInt64(tableData.Rows[0]["tien_qd"]);
                    duAn.TenDonViThucHien = tableData.Rows[0]["ten_donvi_thuchien"].ToString();
                    duAn.TenDonViQuanLy = tableData.Rows[0]["ten_donvi_quanly"].ToString();
                    duAn.SoQuyetDinh = tableData.Rows[0]["so_qd"].ToString();
                    duAn.TenLoaiNguonVon = EnumHelper.GetDescription(duAn.LoaiNguonVon);
                    duAn.TenLoaiPhanCap = EnumHelper.GetDescription(duAn.LoaiPhanCap);
                    duAn.TenNhomDuAn = EnumHelper.GetDescription(duAn.NhomDuAn);
                    return duAn;
                }
                return null;                
            }
            catch (Exception ex)
            {
                return null;                
            }           
        }

        public ListDuAnModelGridView TimKiemDuAn(string mdv, string nsd, string pas, SearchProjectSetting searchProjectSetting, int pageSize, int pageIndex = 1)
        {
            try
            {
                var listDuAn = new ListDuAnModelGridView();
                var giamSatDataTier = new GiamSatRepository();
                var objData = giamSatDataTier.TimKiemDuAn(mdv, nsd, pas, searchProjectSetting, pageSize, pageIndex);
                if (objData != null)
                {
                    var list = new List<DuAnShortModel>();
                    var pageSetting = new PaginationSetting
                                          {
                                              PageSize = pageSize,
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
                            duan.LoaiNguonVon = (LoaiNguonVon)Convert.ToInt32(dr["loai_nguon_von"]);
                            duan.LoaiPhanCap = (LoaiPhanCap)Enum.Parse(typeof(LoaiPhanCap), dr["phancap"].ToString()); 
                            duan.MaDonVi = dr["ma_dvi"].ToString();
                            duan.MaDuAn = dr["ma"].ToString();
                            duan.NamBatDau = Convert.ToInt32(dr["nambd"]);
                            duan.NamKetThuc = Convert.ToInt32(dr["namkt"]);
                            duan.NhomDuAn = (NhomDuAn)Enum.Parse(typeof(NhomDuAn), dr["nhom_da"].ToString());
                            duan.TenDuAn = dr["ten"].ToString();
                            duan.TongVonDauTu = Convert.ToInt64(dr["tienqd"]);
                            duan.TenLoaiNguonVon = EnumHelper.GetDescription(duan.LoaiNguonVon);
                            duan.TenLoaiPhanCap = EnumHelper.GetDescription(duan.LoaiPhanCap);
                            duan.TenNhomDuAn = EnumHelper.GetDescription(duan.NhomDuAn);
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

        public ListDuAnModelGridView DanhSachDuAn(string mdv, string nsd, string pas,int pageSize, int pageIndex = 1)
        {
            try
            {
                var listDuAn = new ListDuAnModelGridView();
                var giamSatDataTier = new GiamSatRepository();
                var objData = giamSatDataTier.DanhSachDuAn(mdv, nsd, pas, pageSize, pageIndex);
                if (objData != null)
                {
                    var list = new List<DuAnShortModel>();
                    var pageSetting = new PaginationSetting
                    {
                        PageSize = pageSize,
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
                            duan.LoaiNguonVon = (LoaiNguonVon)Convert.ToInt32(dr["loai_nguon_von"]);
                            duan.LoaiPhanCap = (LoaiPhanCap)Enum.Parse(typeof(LoaiPhanCap), dr["phancap"].ToString()); 
                            duan.MaDonVi = dr["ma_dvi"].ToString();
                            duan.MaDuAn = dr["ma"].ToString();
                            duan.NamBatDau = Convert.ToInt32(dr["nambd"]);
                            duan.NamKetThuc = Convert.ToInt32(dr["namkt"]);
                            duan.NhomDuAn = (NhomDuAn)Enum.Parse(typeof(NhomDuAn), dr["nhom_da"].ToString());
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

                if (tableData != null && tableData.Rows.Count > 0)
                {
                    var listId = new List<int>();
                    foreach (DataRow dr in tableData.Rows)
                    {
                        var id = Convert.ToInt32(dr["dot"]);
                        if (listId.Exists(element => element == id)) break;
                        listId.Add(id);

                        var soQuyetDinh = dr["so_qd"].ToString();
                        var trangThai = "dk";
                        if (soQuyetDinh != " ")
                            trangThai = "pd";
                            // da tham dinh ke hoach von
                        else if (dr["td_noi"].ToString() != "0" || dr["td_ngoai"].ToString() != "0")
                            trangThai = "td";

                        var xoa = (TinhTrangXoa)Convert.ToInt32(dr["khv_xoa"]);

                        var khv = new KeHoachVonShortModel();
                        khv.IdDuAn = idDuAn;
                        khv.MaDonVi = maDonVi;
                        khv.NamKHV = nam;
                        khv.Dot = id;
                        khv.SoQuyetDinh = soQuyetDinh;                      
                        khv.GiaiDoanKHV = GiaiDoanKHV.DangKyKHV;
                        khv.TinhTrangXoa = xoa;
                        if (trangThai != "") khv.TrangThaiThucHien = "Hoàn thành";
                        else khv.TrangThaiThucHien = "Chưa thực hiện";
                        listKeHoachVon.Add(khv);

                        khv = new KeHoachVonShortModel();
                        khv.IdDuAn = idDuAn;
                        khv.MaDonVi = maDonVi;
                        khv.NamKHV = nam;
                        khv.Dot = id;
                        khv.SoQuyetDinh = soQuyetDinh;  
                        khv.GiaiDoanKHV = GiaiDoanKHV.ThamDinhKHV;
                        khv.TinhTrangXoa = xoa;
                        if (trangThai == "td" || trangThai == "pd") khv.TrangThaiThucHien = "Hoàn thành";
                        else khv.TrangThaiThucHien = "Chưa thực hiện";
                        listKeHoachVon.Add(khv);

                        khv = new KeHoachVonShortModel();
                        khv.IdDuAn = idDuAn;
                        khv.MaDonVi = maDonVi;
                        khv.NamKHV = nam;
                        khv.Dot = id;
                        khv.SoQuyetDinh = soQuyetDinh;                       
                        khv.GiaiDoanKHV = GiaiDoanKHV.PheDuyetKHV;
                        khv.TinhTrangXoa = xoa;
                        if (trangThai == "pd") khv.TrangThaiThucHien = "Hoàn thành";
                        else khv.TrangThaiThucHien = "Chưa thực hiện";
                        listKeHoachVon.Add(khv);
                    }
                    foreach (var l in listKeHoachVon)
                    {
                        foreach (DataRow dr in tableData.Rows)
                        {
                            if (l.Dot == Convert.ToInt32(dr["dot"]))
                            {
                                if (!dr.IsNull("giamsat_id"))
                                {
                                    if (l.GiaiDoanKHV == (GiaiDoanKHV)Convert.ToInt32(dr["ma_gd_khv"]))
                                    {
                                        l.IdGiamSat = Convert.ToInt64(dr["giamsat_id"]);
                                        l.KetQuaGiamSat = (KetQuaGiamSat)Convert.ToInt32(dr["ma_kq_gs"]);
                                        l.GhiChuGiamSat = dr["ghi_chu"].ToString();
                                        break;

                                    }
                                }
                            }
                        }

                    }
                }
                return listKeHoachVon;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ListGoiThauModelGridView DanhSachGoiThau(string mdv, string nsd, string pas, string maDonVi, long idDuAn, int pageSize, int pageIndex = 1)
        {
            try
            {                
                var listGoiThau = new ListGoiThauModelGridView();              
                var giamSatDataTier = new GiamSatRepository();
                var listTrunggian = new List<TrungGian>();
                var objData = giamSatDataTier.DanhSachGoiThau(mdv, nsd, pas, maDonVi, idDuAn, pageSize, pageIndex);
                if (objData != null)
                {
                    var list = new List<GoiThauShortModel>();
                    var pageSetting = new PaginationSetting
                                          {
                                              // 1 ban ghi phan ra moi thau, mo thau, xet thau nen total reocord phai nhan voi 3
                                              PageSize = pageSize*3,
                                              TotalRecords = Convert.ToInt64(objData[1])*3
                                          };
                    listGoiThau.TotalPage = pageSetting.TotalPage;
                    listGoiThau.TotalRecords = pageSetting.TotalRecords;
                    var table = objData[0] as DataTable;
                    if (table != null && table.Rows.Count > 0)
                    {
                        
                        foreach (DataRow dr in table.Rows)
                        {
                            var isGiamSat = false;
                            var id = Convert.ToInt64(dr["id_goithau"]);
                            var hinhthuc = dr["hinhthuc_dauthau"].ToString();
                            var xoa = (TinhTrangXoa)Convert.ToInt32(dr["goithau_xoa"]);
                            var ten = dr["ten_goithau"].ToString();

                            if (!dr.IsNull("ma_gd_gthau"))
                            {
                                var giaidoan = Convert.ToInt32(dr["ma_gd_gthau"]);
                                if (listTrunggian.Exists(element => element.Id == id && element.GiaiDoan == giaidoan)) break;
                                listTrunggian.Add(new TrungGian { Id = id, GiaiDoan = giaidoan });
                                isGiamSat = true;
                            }
                            else { listTrunggian.Add(new TrungGian { Id = id, GiaiDoan = -1 }); }

                            if (!isGiamSat)
                            {

                                var goithau = new GoiThauShortModel();
                                goithau.IdDuAn = idDuAn;
                                goithau.MaDonVi = maDonVi;
                                goithau.IdGoiThau = id;
                                goithau.HinhThucDauThau = hinhthuc;
                                goithau.TinhTrangXoa = xoa;
                                goithau.TenGoiThau = ten;
                                goithau.GiaiDoanDauThau = (int)GiaiDoanChonNhaThau.MoiThau;
                                //todo: xac dinh trang thai lai
                                goithau.TrangThaiThucHien = "Hoàn thành";
                                list.Add(goithau);

                                goithau = new GoiThauShortModel();
                                goithau.IdDuAn = idDuAn;
                                goithau.MaDonVi = maDonVi;
                                goithau.IdGoiThau = id;
                                goithau.HinhThucDauThau = hinhthuc;
                                goithau.TinhTrangXoa = xoa;
                                goithau.TenGoiThau = ten;
                                goithau.GiaiDoanDauThau = GiaiDoanChonNhaThau.MoThau;
                                //todo: xac dinh trang thai lai
                                goithau.TrangThaiThucHien = "Hoàn thành";
                                list.Add(goithau);

                                goithau = new GoiThauShortModel();
                                goithau.IdDuAn = idDuAn;
                                goithau.MaDonVi = maDonVi;
                                goithau.IdGoiThau = id;
                                goithau.HinhThucDauThau = hinhthuc;
                                goithau.TinhTrangXoa = xoa;
                                goithau.TenGoiThau = ten;
                                goithau.GiaiDoanDauThau = GiaiDoanChonNhaThau.XetThau;
                                //todo: xac dinh trang thai lai
                                goithau.TrangThaiThucHien = "Hoàn thành";
                                list.Add(goithau);
                            }
                            else
                            {
                                var goithau = new GoiThauShortModel();
                                goithau.IdDuAn = idDuAn;
                                goithau.MaDonVi = maDonVi;
                                goithau.IdGoiThau = id;
                                goithau.HinhThucDauThau = hinhthuc;
                                goithau.TinhTrangXoa = xoa;
                                goithau.TenGoiThau = ten;
                                goithau.GiaiDoanDauThau = (GiaiDoanChonNhaThau)Convert.ToInt32(dr["ma_gd_gthau"]);                               
                                goithau.TrangThaiThucHien = "Hoàn thành";
                                list.Add(goithau);
                            }
                        }
                        foreach (var l in list)
                        {
                            foreach (DataRow dr in table.Rows)
                            {
                                if (l.IdGoiThau == Convert.ToInt64(dr["id_goithau"]))
                                {
                                    if (!dr.IsNull("id_giamsat"))
                                    {
                                        if (l.GiaiDoanDauThau == (GiaiDoanChonNhaThau)Convert.ToInt32(dr["ma_gd_gthau"]))
                                        {
                                            l.IdGiamSat = Convert.ToInt64(dr["id_giamsat"]);
                                            l.KetQuaGiamSat = (KetQuaGiamSat)Convert.ToInt32(dr["ma_kq_gs"]);
                                            l.GhiChuGiamSat = dr["ghi_chu"].ToString();                                           
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

        public ListHopDongModelGridView DanhSachHopDong(string mdv, string nsd, string pas, string maDonVi, long idGoiThau, int pageSize, int pageIndex = 1)
        {
            try
            {                
                var listHopDong = new ListHopDongModelGridView();                
                var giamSatDataTier = new GiamSatRepository();
                var objData = giamSatDataTier.DanhSachHopDong(mdv, nsd, pas, maDonVi, idGoiThau, pageSize, pageIndex);
                if (objData != null)
                {
                    var list = new List<HopDongShortModel>();
                    var pageSetting = new PaginationSetting
                                          {
                                              PageSize = pageSize,
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
                            hopdong.MaDonVi = maDonVi;
                            hopdong.IdGoiThau = idGoiThau;
                            hopdong.TenHopDong = dr["ten_hd"].ToString();
                            hopdong.BenA = dr["ben_a"].ToString();
                            hopdong.BenB = dr["ben_b"].ToString();
                            hopdong.TienNoiTe = Convert.ToInt64(dr["tien_nt"]);
                            hopdong.TienNgoaiTe = Convert.ToInt64(dr["tien_ngt"]);
                            hopdong.TinhTrangHopDong = dr["tinhtrang_hdo"].ToString();
                            hopdong.TinhTrangXoa = (TinhTrangXoa)Convert.ToInt32(dr["hdo_xoa"]);

                            // check giai doan von da duoc giam sat chua
                            if (!dr.IsNull("id_giamsat"))
                            {
                                hopdong.IdGiamSat = Convert.ToInt64(dr["id_giamsat"]);
                                hopdong.KetQuaGiamSat = (KetQuaGiamSat)Convert.ToInt32(dr["ma_kq_gs"]);
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

        public ChangeResultSettings CapNhatLoaiNguonVon(string mdv, string nsd, string pas, string maDonVi, long idDuAn, int loaiNguonVon)
        {
            var giamSatDataTier = new GiamSatRepository();          
            var objData = giamSatDataTier.CapNhatLoaiNguonVon(mdv, nsd, pas, maDonVi, idDuAn, loaiNguonVon);
            return objData;
        }

        public ChangeResultSettings GiamSat(string mdv, string nsd, string pas, int loaiGiamSat, List<GiamSatSetting> listGiamSat = null)
        {
            var giamSatDataTier = new GiamSatRepository();           
            var objData = giamSatDataTier.GiamSat(mdv, nsd, pas, loaiGiamSat, listGiamSat);
            return objData;
        }   


        public List<DonViShortModel> DanhSachDonVi(string mdv, string nsd, string pas, string valueFirst = null)
        {
            try
            {
                var listDonVi = new List<DonViShortModel>();
                var giamSatDataTier = new GiamSatRepository();
                var tableData = giamSatDataTier.DanhSachDonVi(mdv, nsd, pas);
                var donvi = new DonViShortModel();
                if (valueFirst != null)
                {
                    donvi.TenDonVi = valueFirst;
                    donvi.MaDonVi = "";
                }
                listDonVi.Add(donvi);
                if (tableData != null && tableData.Rows.Count > 0)
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
            catch (Exception)
            {
                return null;                
            }            
        }

        public List<int> NamKeHoachVon(string mdv, string nsd, string pas, string maDonVi, long idDuAn)
        {
            var listNam = new List<int>();
            var giamSatDataTier = new GiamSatRepository();
            var tableData = giamSatDataTier.NamKeHoachVon(mdv, nsd, pas, maDonVi, idDuAn);           
            if (tableData != null && tableData.Rows.Count > 0)
            {
                listNam.AddRange(from DataRow dr in tableData.Rows select Convert.ToInt32(dr["nam"]));
            }
            return listNam;
        }

        public List<UnitShortModel> DanhSachLoaiDuAn(string mdv, string nsd, string pas, string valueFirst = null)
        {
            try
            {
                var listDonVi = new List<UnitShortModel>();
                var giamSatDataTier = new GiamSatRepository();
                var tableData = giamSatDataTier.DanhSachLoaiDuAn(mdv, nsd, pas);
                var model = new UnitShortModel();
                if (valueFirst != null)
                {
                    model.ValueString =  valueFirst;
                    model.Name = "";
                }
                listDonVi.Add(model);
                if (tableData != null && tableData.Rows.Count > 0)
                {
                    foreach (DataRow dr in tableData.Rows)
                    {
                        model = new UnitShortModel();
                        model.Name = dr["ma"].ToString();
                        model.ValueString = dr["ten"].ToString();
                        listDonVi.Add(model);
                    }
                }
                return listDonVi;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
