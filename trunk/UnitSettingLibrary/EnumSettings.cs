using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
namespace UnitSettingLibrary
{
    public class EnumHelper
    {        
        public static string GetDescription<TEnum>(TEnum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }
       
        public static T GetEnumValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();
            FieldInfo[] fields = type.GetFields();
            var field = fields.SelectMany(f => f.GetCustomAttributes(typeof(DescriptionAttribute), false), (f, a) => new { Field = f, Att = a })
                .SingleOrDefault(a => ((DescriptionAttribute)a.Att).Description == description);
            if(field != null) return (T)field.Field.GetRawConstantValue();
            throw new Exception("Không tồn tai enum có mô tả là " + description);
        }
        
        public static Hashtable GetEnumForBind(Type enumeration)
        {
            string[] names = Enum.GetNames(enumeration);
            Array values = Enum.GetValues(enumeration);
            var ht = new Hashtable();
            for (int i = 0; i < names.Length; i++)
            {
                ht.Add(Convert.ToInt32(values.GetValue(i)).ToString(CultureInfo.InvariantCulture), names[i]);
            }
            return ht;
        }
        
        public static IEnumerable<UnitShortModel> GetDescriptionForBind<TEnum>(TEnum enumValue)
        {
            if (!typeof(TEnum).IsEnum) return null;

            var a = (from TEnum e in Enum.GetValues(typeof(TEnum))
                     select new UnitShortModel()
                     {
                         Name = e.ToString(),
                         ValueInt = Convert.ToInt32(e),
                         ValueString = GetDescription(e)
                     }).OrderBy(x => x.ValueInt);
            return a;
        }
    }

    public enum NameDatabase
    {
        GiamSat = 0,
        DauTu = 1
    }

    public enum ChangeResult
    {
        // the hien truong hop that bai, hoac sai
        ThatBai = 0,
        // the hien truong hop thanh cong hoac dung
        ThanhCong = 1
    }   

    public enum LoaiGiamSat
    {
        KhongXacDinh = -1,
        GiamSatKHV = 0,
        GiamSatChonNhaThau = 1,
        GiamSatHopDong = 2,
    }    

    public enum GiaiDoanKHV
    {
        [Description("Không xác định")]
        KhongXacDinh = -1,
        [Description("Đăng ký kế hoạch vốn")]
        DangKyKHV = 0,
        [Description("Thẩm định kế hoạch")]
        ThamDinhKHV = 1,
        [Description("Phê duyệt kế hoạch")]
        PheDuyetKHV = 2
    }

    public enum GiaiDoanChonNhaThau
    {
        [Description("Không xác định")]
        KhongXacDinh = -1,
        [Description("Mời thầu")]
        MoiThau = 0,
        [Description("Mở thầu")]
        MoThau = 1,
        [Description("Xét thầu")]
        XetThau = 2
    }    

    public enum LoaiNguonVon
    {
        [Description("--Chọn giá trị--")]
        KhongXacDinh = -1,
        [Description("Chưa cập nhật loại nguồn vốn")]
        ChuaCapNhat = 0,
        [Description("Trên 30% vốn nhà nước")]
        VonNhaNuoc30 = 1,
        [Description("Vốn khác")]
        VonKhac = 2
    }

    public enum NhomDuAn
    {
        [Description("--Chọn giá trị--")]
        KhongXacDinh = -1,
        [Description("Nhóm A")]
        A = 0,
        [Description("Nhóm B")]
        B = 1,
        [Description("Nhóm C")]
        C = 2
    }

    public enum LoaiPhanCap
    {
        [Description("--Chọn giá trị--")]
        KhongXacDinh = -1,
        [Description("Dự án phân cấp")]
        P = 0,
        [Description("Dự án tập trung")]
        T = 1
    }

    public enum TinhTrangGiamSat
    {
        KhongXacDinh = -1,
        ChuaGiamSat = 0,
        ThucHienKiemTra = 1,
        ThuchienGiamSat = 2,
        ThucHienDanhGia = 3,
        BaoCaoGiamSat = 4
    }

    public enum KetQuaGiamSat
    {
        [Description("--Chọn giá trị--")]
        KhongXacDinh = -1,

        [Description("Vi phạm thủ tục quy hoạch")]
        VpThuTucQuyHoach = 0,
        [Description("Vi phạm thẩm quyền phê duyệt")]
        VpThuTucThamQuyenPheDuyet = 1,
        [Description("Vi phạm thủ tục trình tự thẩm định")]
        VpThuTucTrinhTuThamDinh = 2,
        [Description("Vi phạm quản lý chất lượng")]
        VpQuanLyChatLuong = 3,
        [Description("Vi phạm đấu thầu")]
        VpDauThau = 4,
        [Description("Vi phạm ký hợp đồng")]
        VpKyHd = 5,
        [Description("Vi phạm quản lý đầu tư")]
        VpQuanLyDauTu = 6,
        [Description("Vi phạm bảo vệ môi trường")]
        VpBaoVeMoiTruong = 7,
        [Description("Vi phạm sử dụng đất đai")]
        VpSuDungDatDai = 8,
        [Description("Vi phạm quản lý tài nguyên")]
        VpQuanLyTaiNguyen = 9,

        [Description("Chậm tiến độ do thủ tục")]
        ChamDoThuTuc = 100,
        [Description("Chậm tiến độ do giải phóng mặt bằng")]
        ChamDoGPMB = 101,
        [Description("Chậm tiến độ do năng lực")]
        ChamDoNangLuc = 102,
        [Description("Chậm tiến độ do vốn")]
        ChamDoVon = 103,
        [Description("Chậm tiến độ do lý do khác")]
        ChamDoKhac = 104,

        [Description("Thất thoát lãng phí")]
        ThatThoatLangPhi = 200,
        [Description("Sử dụng không hiệu quả")]
        SuDungKoHieuQua = 201
    }

    public enum TinhTrangXoa
    {
        ChuaXoa = 0,
        DaXoa = 1,
        HuyThongBaoXoa = 2
    }


    public enum BangDauTuCoLichSu
    {
        // cac bang co key simple
        BDT_QLDT_QDDT_DA,
        BDT_QLDT_GTH_CT,
        BDT_QLDT_QDDT_HANG,

        // cac bang co key complex
        BDT_QLDT_KHDT_TR,
        BDT_QLDT_QDDT_TINH
    }

    public enum BangDauTuKoLichSu
    {
        // cac bang co key simple
        // danh sach bang thong tin
        //HOA_MA,
        BDT_QLDT_CTRINH,
        BDT_QLDT_GTH_XET,
        BDT_QLDT_GTH_MOI,
        BDT_QLDT_GTH_MO,
        BDT_QLDT_HDO_CT,
        BDT_QLDT_HDO_TT,
        BDT_QLDT_KHVON_TH,
        BDT_QLDT_KHVON_GN,

        // cac bang co key simple
        // danh sach bang ma
        TT_MA_NT,
        BDT_QLDT_MA_LCTR,
        BDT_QLDT_MA_NGUON,
        BDT_QLDT_MA_NHTH,
        BDT_QLDT_MA_HT,
        BDT_QLDT_HDO_MA_TTH,
        BDT_QLDT_HDO_MA_HTH,
        BDT_QLDT_GTH_MA_HTT,
        BDT_QLDT_GTH_MA_PTT,
        BDT_QLDT_GTH_MA_LOT,
        BDT_QLDT_GTH_MA_CHL,
        BDT_QLDT_GTH_MA_TTH,
        BDT_QLDT_GTH_MA_HTH,
        //HT_MA_DVI,
        BDT_QLDT_MA_HTTK,
        BDT_QLDT_MA_MC,
        BDT_QLDT_MA_MUC,
        BDT_QLDT_MA_CP,

        // cac bang co key complex
        BDT_QLDT_KHDT_TD,
        BDT_QLDT_GTH_MOI_NHA,
        BDT_QLDT_GTH_MO_NHA,
        BDT_QLDT_GTH_XET_NHA,
        BDT_QLDT_GTH_MOI_TO,
        BDT_QLDT_GTH_XET_TBI,
        BDT_QLDT_GTH_TO_CGIA,
        BDT_QLDT_GTH_TBI,
        BDT_QLDT_QTOAN,
        BDT_QLDT_HTHANH
    }

    public enum ColumnKeyName
    {
        MA_DVI,
        SO_ID,
        MA,
        SO_QD,
        BT,
        HANG,
        MA_HT,
        NAM,
        DOT,
        NHA
    }

}