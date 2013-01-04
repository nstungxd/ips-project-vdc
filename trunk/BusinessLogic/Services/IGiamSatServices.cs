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
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="namKHV"></param>
        /// <param name="idDuAn"></param>
        /// <returns></returns>
        [OperationContract]
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
        [OperationContract]
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
        [OperationContract]
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
        [OperationContract]
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
        [OperationContract]
        string ChiTietGoiThauReturnString(string mdv, string nsd, string pas, string maDonVi, long idGoiThau);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="idHopDong"></param>
        /// <returns></returns>
        [OperationContract]
        string ChiTietHopDongReturnString(string mdv, string nsd, string pas, string maDonVi, long idHopDong);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="idDuAn"></param>
        /// <returns></returns>
        [OperationContract]
        string ChiTietDuAnReturnString(string mdv, string nsd, string pas, string maDonVi, long idDuAn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="searchProjectSetting"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [OperationContract]
        object[] TimKiemDuAn(string mdv, string nsd, string pas, SearchProjectSetting searchProjectSetting, int pageIndex = 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [OperationContract]
        object[] DanhSachDuAn(string mdv, string nsd, string pas, int pageIndex = 1);

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
        [OperationContract]
        string DanhSachGiaiDoanKHVReturnString(string mdv, string nsd, string pas, string maDonVi, long idDuAn, long nam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pas"> </param>
        /// <param name="maDonVi"></param>
        /// <param name="idDuAn"></param>
        /// <param name="pageIndex"></param>
        /// <param name="mdv"> </param>
        /// <param name="nsd"> </param>
        /// <returns></returns>
        [OperationContract]
        string DanhSachGoiThauReturnString(string mdv, string nsd, string pas, string maDonVi, long idDuAn, int pageIndex = 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdv"></param>
        /// <param name="nsd"></param>
        /// <param name="pas"></param>
        /// <param name="maDonVi"></param>
        /// <param name="idGoiThau"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [OperationContract]
        string DanhSachHopDongReturnString(string mdv, string nsd, string pas, string maDonVi, long idGoiThau, int pageIndex = 1);

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
        [OperationContract]
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
        [OperationContract]
        ChangeResultSettings GiamSat(string mdv, string nsd, string pas,long loaiGiamSat, List<GiamSatSetting> listGiamSat = null);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<DonViShortModel> DanhSachDonVi(string mdv, string nsd, string pas);
    }
}
