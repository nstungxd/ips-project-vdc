using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using UnitSettingLibrary;


namespace BusinessLogic.Interfaces
{
    [ServiceContract]
    public interface IGiamSatServices
    {
        [OperationContract]
        DataTable ChiTietKeHoachVon(string maDonVi, long namKHV, long idDuAn);

        [OperationContract]
        DataTable ChiTietMoiThau(string maDonVi, long idGoiThau);

        [OperationContract]
        DataTable ChiTietMoThau(string maDonVi, long idGoiThau);

        [OperationContract]
        DataTable ChiTietXetThau(string maDonVi, long idGoiThau);

        [OperationContract]
        string ChiTietGoiThauReturnString(string maDonVi, long idGoiThau);

        [OperationContract]
        string ChiTietHopDongReturnString(string maDonVi, long idHopDong);

        [OperationContract]
        string ChiTietDuAnReturnString(string maDonVi, long idDuAn);

        [OperationContract]
        object[] TimKiemDuAn(SearchProjectSetting searchProjectSetting, int pageIndex = 1);

        [OperationContract]
        object[] DanhSachDuAn(int pageIndex = 1);

        [OperationContract]
        string DanhSachGiaiDoanKHVReturnString(string maDonVi, long idDuAn, long nam);

        [OperationContract]
        string DanhSachGoiThauReturnString(string maDonVi, long idDuAn, int pageIndex = 1);

        [OperationContract]
        string DanhSachHopDongReturnString(string maDonVi, long idGoiThau, int pageIndex = 1);

        [OperationContract]
        ChangeResultSettings CapNhatLoaiNguonVon(string maDonVi, long idDuAn, long loaiNguonVon);

        [OperationContract]
        ChangeResultSettings GiamSat(long loaiGiamSat, List<GiamSatSetting> listGiamSat = null);
    }
}
