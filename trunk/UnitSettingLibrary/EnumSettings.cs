namespace UnitSettingLibrary
{    
    public enum NameDatabase
    {
        GiamSat = 0,
        DauTu = 1
    }

    public enum ChangeResult
    {
        ThatBai = 0,
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
        KhongXacDinh = -1,
        DangKyKHV = 0,
        ThamDinhKHV = 1,
        PheDuyetKHV = 2
    }

    public enum GiaiDoanChonNhaThau
    {
        KhongXacDinh = -1,
        MoiThau = 0,
        MoThau = 1,
        XetThau = 2
    }

    public enum LoaiDuAn
    {
        KhongXacDinh = -1
    }

    public enum LoaiNguonVon
    {
        KhongXacDinh = -1,
        ChuaCapNhat = 0,
        VonNhaNuoc30 = 1,
        VonKhac = 2
    }

    public enum NhomDuAn
    {
        KhongXacDinh = -1,
        NhomA = 0,
        NhomB = 1,
        NhomC = 2
    }

    public enum LoaiPhanCap
    {
        KhongXacDinh = -1,
        PhanCap = 0,
        TapTrung = 1
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
        KhongXacDinh = -1,

        VpThuTucQuyHoach = 0,
        VpThuTucThamQuyenPheDuyet = 1,
        VpThuTucTrinhTuThamDinh = 2,
        VpQuanLyChatLuong = 3,
        VpDauThau = 4,
        VpKyHd = 5,
        VpQuanLyDauTu = 6,
        VpBaoVeMoiTruong = 7,
        VpSuDungDatDai = 8,
        VpQuanLyTaiNguyen = 9,

        ChamDoThuTuc = 100,
        ChamDoGPMB = 101,
        ChamDoNangLuc = 102,
        ChamDoVon = 103,
        ChamDoKhac = 104,

        ThatThoatLangPhi = 200,
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