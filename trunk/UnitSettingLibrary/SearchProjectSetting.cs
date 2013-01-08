using System.Runtime.Serialization;

namespace UnitSettingLibrary
{
    [DataContract]
    public class SearchProjectSetting
    {
        [DataMember]
        public string MaDonViQuanLy { get; set; }
        [DataMember]
        public string MaDuAn { get; set; }
        [DataMember]
        public string LoaiDuAn { get; set; }
        [DataMember]
        public NhomDuAn NhomDuAn { get; set; }
        [DataMember]
        public LoaiNguonVon LoaiNguonVon { get; set; }
        [DataMember]
        public LoaiPhanCap PhanCap { get; set; }
        [DataMember]
        public string MaDonViThucHien { get; set; }
        [DataMember]
        public long TongVonDauTu { get; set; }
        [DataMember]
        public string TongVonDauTuToanTu { get; set; }
        [DataMember]
        public int NamBatDau { get; set; }
        [DataMember]
        public string NamBatDauToanTu { get; set; }
        [DataMember]
        public int NamKetThuc { get; set; }
        [DataMember]
        public string NamKetThucToanTu { get; set; }

        public SearchProjectSetting()
        {
            NhomDuAn = NhomDuAn.KhongXacDinh;
            LoaiNguonVon = LoaiNguonVon.KhongXacDinh;
            PhanCap = LoaiPhanCap.KhongXacDinh;
        }
    }
}