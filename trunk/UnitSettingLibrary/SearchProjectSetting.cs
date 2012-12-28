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
        public string NhomDuAn { get; set; }
        [DataMember]
        public long LoaiNguonVon { get; set; }
        [DataMember]
        public string PhanCap { get; set; }
        [DataMember]
        public string MaDonViThucHien { get; set; }
        [DataMember]
        public long TongVonDauTu { get; set; }
        [DataMember]
        public string TongVonDauTuToanTu { get; set; }
        [DataMember]
        public long NamBatDau { get; set; }
        [DataMember]
        public string NamBatDauToanTu { get; set; }
        [DataMember]
        public long NamKetThuc { get; set; }
        [DataMember]
        public string NamKetThucToanTu { get; set; }
    }
}