using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using UnitSettingLibrary;


namespace BusinessLogic.Interfaces
{
    [ServiceContract]
    public interface IGiamSatServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maDonVi"></param>
        /// <param name="namKHV"></param>
        /// <param name="idDuAn"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable ChiTietKeHoachVon(string maDonVi, long namKHV, long idDuAn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maDonVi"></param>
        /// <param name="idGoiThau"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable ChiTietMoiThau(string maDonVi, long idGoiThau);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maDonVi"></param>
        /// <param name="idGoiThau"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable ChiTietMoThau(string maDonVi, long idGoiThau);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maDonVi"></param>
        /// <param name="idGoiThau"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable ChiTietXetThau(string maDonVi, long idGoiThau);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maDonVi"></param>
        /// <param name="idGoiThau"></param>
        /// <returns></returns>
        [OperationContract]
        string ChiTietGoiThauReturnString(string maDonVi, long idGoiThau);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maDonVi"></param>
        /// <param name="idHopDong"></param>
        /// <returns></returns>
        [OperationContract]
        string ChiTietHopDongReturnString(string maDonVi, long idHopDong);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maDonVi"></param>
        /// <param name="idDuAn"></param>
        /// <returns></returns>
        [OperationContract]
        string ChiTietDuAnReturnString(string maDonVi, long idDuAn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchProjectSetting"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [OperationContract]
        object[] TimKiemDuAn(SearchProjectSetting searchProjectSetting, int pageIndex = 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [OperationContract]
        object[] DanhSachDuAn(int pageIndex = 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maDonVi"></param>
        /// <param name="idDuAn"></param>
        /// <param name="nam"></param>
        /// <returns></returns>
        [OperationContract]
        string DanhSachGiaiDoanKHVReturnString(string maDonVi, long idDuAn, long nam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maDonVi"></param>
        /// <param name="idDuAn"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [OperationContract]
        string DanhSachGoiThauReturnString(string maDonVi, long idDuAn, int pageIndex = 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maDonVi"></param>
        /// <param name="idGoiThau"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [OperationContract]
        string DanhSachHopDongReturnString(string maDonVi, long idGoiThau, int pageIndex = 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maDonVi"></param>
        /// <param name="idDuAn"></param>
        /// <param name="loaiNguonVon"></param>
        /// <returns></returns>
        [OperationContract]
        ChangeResultSettings CapNhatLoaiNguonVon(string maDonVi, long idDuAn, long loaiNguonVon);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loaiGiamSat"></param>
        /// <param name="listGiamSat"></param>
        /// <returns></returns>
        [OperationContract]
        ChangeResultSettings GiamSat(long loaiGiamSat, List<GiamSatSetting> listGiamSat = null);
    }
}
