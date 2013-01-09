using BusinessLogic.Models;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGiamSatServices" in both code and config file together.
    [ServiceContract]
    public interface IGiamSatServices
    {
        /// <summary>
        /// lay chi tiet ke hoach von
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="maDonVi">ma don vi thuc hien ke hoach von</param>
        /// <param name="namKHV">nam ke hoach von</param>
        /// <param name="idDuAn">id du an</param>
        /// <returns>DataTable</returns>
        [OperationContract]
        KeHoachVonModel ChiTietKeHoachVon(string mdv, string nsd, string pas, string maDonVi, int namKHV, long idDuAn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="maDonVi"></param>
        /// <param name="idGoiThau"></param>
        /// <returns></returns>
        [OperationContract]
        ThongTinMoiThauModel ChiTietMoiThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="maDonVi"></param>
        /// <param name="idGoiThau"></param>
        /// <returns></returns>
        [OperationContract]
        ThongTinMoThauModel ChiTietMoThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="maDonVi"></param>
        /// <param name="idGoiThau"></param>
        /// <returns></returns>
        [OperationContract]
        ThongTinXetThauModel ChiTietXetThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="maDonVi"></param>
        /// <param name="idGoiThau"></param>
        /// <returns></returns>
        [OperationContract]
        GoiThauModel ChiTietGoiThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="maDonVi"></param>
        /// <param name="idHopDong"></param>
        /// <returns></returns>
        [OperationContract]
        HopDongModel ChiTietHopDong(string mdv, string nsd, string pas, string maDonVi, long idHopDong);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="maDonVi"></param>
        /// <param name="idDuAn"></param>
        /// <returns></returns>
        [OperationContract]
        DuAnShortModel ChiTietDuAn(string mdv, string nsd, string pas, string maDonVi, long idDuAn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="searchProjectSetting">object chua cac tham so search</param>
        /// <param name="pageIndex">trang du lieu can lay</param> 
        /// <param name="pageSize"></param> 
        /// <returns>object[0]: danh sach, object[1]:tong so ban ghi, object[2]: tong so trang</returns>
        [OperationContract]
        ListDuAnModelGridView TimKiemDuAn(string mdv, string nsd, string pas, SearchProjectSetting searchProjectSetting, int pageSize, int pageIndex = 1);

        /// <summary>
        /// lay danh sach du an
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="pageIndex">trang du lieu can lay</param> 
        /// <param name="pageSize"></param> 
        /// <returns>object[0]: danh sach, object[1]:tong so ban ghi, object[2]: tong so trang</returns>
        [OperationContract]
        ListDuAnModelGridView DanhSachDuAn(string mdv, string nsd, string pas,int pageSize, int pageIndex = 1);

        /// <summary>
        /// lay danh sach nam khv de bind for dropdownlist
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="idDuAn"></param>
        /// <returns></returns>
        [OperationContract]
        List<int> NamKeHoachVon(string mdv, string nsd, string pas, string maDonVi, long idDuAn);            

            /// <summary>
        /// lay danh sach cac giai doan cua 1 ke hoach von
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="maDonVi">ma don vi thuc hien du an</param>
        /// <param name="idDuAn">id du an</param>
        /// <param name="nam">nam ke hoach</param>
        /// <returns>danh sach cac giai doan von</returns>
        [OperationContract]
        List<KeHoachVonShortModel> DanhSachGiaiDoanKHV(string mdv, string nsd, string pas, string maDonVi, long idDuAn, int nam);

        /// <summary>
        /// lay danh sach cac goi thau thuoc 1 du an
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="maDonVi">ma don vi thuc hien du an</param>
        /// <param name="idDuAn">id du an</param>
        /// <param name="pageIndex">trang du lieu can lay</param> 
        /// <param name="pageSize">so ban ghi 1 trang</param>
        /// <returns>danh sach goi thau</returns>
        [OperationContract]
        ListGoiThauModelGridView DanhSachGoiThau(string mdv, string nsd, string pas, string maDonVi, long idDuAn, int pageSize,
                                           int pageIndex = 1);

        /// <summary>
        /// lay sanh sach cac hop dong thuoc 1 goi thau
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="maDonVi">ma don vi thuc hien du an</param>
        /// <param name="idGoiThau">id goi thau</param>
        /// <param name="pageIndex">trang du lieu can lay</param>
        /// <param name="pageSize">so ban ghi 1 trang</param>
        /// <returns>danh sach hop dong</returns>
        [OperationContract]
        ListHopDongModelGridView DanhSachHopDong(string mdv, string nsd, string pas, string maDonVi, long idGoiThau, int pageSize,
                                           int pageIndex = 1);

        /// <summary>
        /// cap nhat loai nguon von du an
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="maDonVi">ma don vi thuc hien du an</param>
        /// <param name="idDuAn">id du an</param>
        /// <param name="loaiNguonVon">loai nguon von</param>
        /// <returns>ChangeResultSettings</returns>
        [OperationContract]
        ChangeResultSettings CapNhatLoaiNguonVon(string mdv, string nsd, string pas, string maDonVi, long idDuAn,
                                                 int loaiNguonVon);

        /// <summary>
        /// thuc hien thao tac giam sat
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="loaiGiamSat">loai giam sat</param>
        /// <param name="listGiamSat">danh sach object giam sat</param>
        /// <returns></returns>
        [OperationContract]
        ChangeResultSettings GiamSat(string mdv, string nsd, string pas, int loaiGiamSat,
                                     List<GiamSatSetting> listGiamSat = null);

        /// <summary>
        /// lay danh sach don vi de fill du lieu vao dropdownlist
        /// </summary>
        /// <returns>danh sach don vi gom ma,ten</returns>
        [OperationContract]
        List<DonViShortModel> DanhSachDonVi(string mdv, string nsd, string pas, string valueFirst = null);
        
        /// <summary>        
        /// lay danh sach loai du an de fill du lieu cho dropdownlist
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="valueFirst"></param>
        /// <returns>UnitShortModel: name = ma loai, valuestring = ten loai</returns>
        [OperationContract]
        List<UnitShortModel> DanhSachLoaiDuAn(string mdv, string nsd, string pas, string valueFirst = null);
    }

}
