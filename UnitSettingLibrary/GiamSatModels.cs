namespace UnitSettingLibrary
{
    public class GiamSatSetting
    {
        public string MaDonVi { get; set; }
        public long GiamSatID { get; set; }
        public long DuAnID { get; set; }
        public long GoiThauID { get; set; }
        public long HopDongID { get; set; }
        public string MaNguoiNhap { get; set; }
        public long KeHoachVonID { get; set; }
        public long DotKHV { get; set; }
        public long NamKHV { get; set; }
        public string SoQD { get; set; }
        //public GiaiDoanKHV GiaiDoanKHV { get; set; }
        //public KetQuaGiamSat KetQuaGiamSat { get; set; }
        //public GiaiDoanChonNhaThau GiaiDoanChonNhaThau { get; set; }
        public long GiaiDoanKHV { get; set; }
        public long KetQuaGiamSat { get; set; }
        public long GiaiDoanChonNhaThau { get; set; }
        public string GhiChu { get; set; }

        public GiamSatSetting()
        {
            //GiaiDoanKHV = GiaiDoanKHV.KhongXacDinh;
            //KetQuaGiamSat = KetQuaGiamSat.KhongXacDinh;
            //GiaiDoanChonNhaThau = GiaiDoanChonNhaThau.KhongXacDinh; 
            GiaiDoanKHV = -1;
            KetQuaGiamSat = -1;
            GiaiDoanChonNhaThau = -1;
        }
    }
}