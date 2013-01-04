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
        DataTable ChiTietKeHoachVon(string mdv, string nsd, string pas, string maDonVi, long namKHV, long idDuAn);

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
        DataTable ChiTietMoiThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau);

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
        DataTable ChiTietMoThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau);

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
        DataTable ChiTietXetThau(string mdv, string nsd, string pas, string maDonVi, long idGoiThau);

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
        string ChiTietGoiThauReturnString(string mdv, string nsd, string pas, string maDonVi, long idGoiThau);

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
        string ChiTietHopDongReturnString(string mdv, string nsd, string pas, string maDonVi, long idHopDong);

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
        string ChiTietDuAnReturnString(string mdv, string nsd, string pas, string maDonVi, long idDuAn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="searchProjectSetting">object chua cac tham so search</param>
        /// <param name="pageIndex">trang du lieu can lay</param> 
        /// <returns>object[0]: danh sach, object[1]:tong so ban ghi, object[2]: tong so trang</returns>
        [OperationContract]
        object[] TimKiemDuAn(string mdv, string nsd, string pas, SearchProjectSetting searchProjectSetting, int pageIndex = 1);

        /// <summary>
        /// lay danh sach du an
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="pageIndex">trang du lieu can lay</param> 
        /// <returns>object[0]: danh sach, object[1]:tong so ban ghi, object[2]: tong so trang</returns>
        [OperationContract]
        object[] DanhSachDuAn(string mdv, string nsd, string pas, int pageIndex = 1);

        /// <summary>
        /// lay danh sach cac giai doan cua 1 ke hoach von
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="maDonVi">ma don vi thuc hien du an</param>
        /// <param name="idDuAn">id du an</param>
        /// <param name="nam">nam ke hoach</param>
        /// <returns>danh sach cac giai doan von kieu json</returns>
        [OperationContract]
        string DanhSachGiaiDoanKHVReturnString(string mdv, string nsd, string pas, string maDonVi, long idDuAn, long nam);

        /// <summary>
        /// lay danh sach cac goi thau thuoc 1 du an
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="maDonVi">ma don vi thuc hien du an</param>
        /// <param name="idDuAn">id du an</param>
        /// <param name="pageIndex">trang du lieu can lay</param> 
        /// <returns>danh sach goi thau kieu json</returns>
        [OperationContract]
        string DanhSachGoiThauReturnString(string mdv, string nsd, string pas, string maDonVi, long idDuAn, int pageIndex = 1);

        /// <summary>
        /// lay sanh sach cac hop dong thuoc 1 goi thau
        /// </summary>
        /// <param name="mdv">ma don vi nguoi dang su dung</param>
        /// <param name="nsd">ma nguoi su dung</param>
        /// <param name="pas">mat khau nguoi su dung</param>
        /// <param name="maDonVi">ma don vi thuc hien du an</param>
        /// <param name="idGoiThau">id goi thau</param>
        /// <param name="pageIndex">trang du lieu can lay</param>
        /// <returns>danh sach hop dong kieu json</returns>
        [OperationContract]
        string DanhSachHopDongReturnString(string mdv, string nsd, string pas, string maDonVi, long idGoiThau, int pageIndex = 1);

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
        ChangeResultSettings CapNhatLoaiNguonVon(string mdv, string nsd, string pas, string maDonVi, long idDuAn, long loaiNguonVon);

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
        ChangeResultSettings GiamSat(string mdv, string nsd, string pas,long loaiGiamSat, List<GiamSatSetting> listGiamSat = null);

        /// <summary>
        /// lay danh sach don vi de fill du lieu vao dropdownlist
        /// </summary>
        /// <returns>danh sach don vi gom ma,ten</returns>
        [OperationContract]
        List<DonViShortModel> DanhSachDonVi(string mdv, string nsd, string pas);
    }
}
