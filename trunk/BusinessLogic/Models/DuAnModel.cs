using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using UnitSettingLibrary;

namespace BusinessLogic.Models
{
    [DataContract]
    public class DuAnModelGridView
    {
        [DataMember]
        public string MaDonVi { get; set; }

        [DataMember]
        public long IdDuAn { get; set; }

        [DataMember]
        public string MaDuAn { get; set; }

        [DataMember]
        public string TenDuAn { get; set; }

        [DataMember]
        public LoaiNguonVon LoaiNguonVon { get; set; }

        [DataMember]
        public LoaiPhanCap LoaiPhanCap { get; set; }

        [DataMember]
        public NhomDuAn NhomDuAn { get; set; }

        [DataMember]
        public long NamBatDau { get; set; }

        [DataMember]
        public long NamKetThuc { get; set; }

        [DataMember]
        public long TongVonDauTu { get; set; }

        public DuAnModelGridView()
        {
            LoaiNguonVon = LoaiNguonVon.KhongXacDinh;
            LoaiPhanCap = LoaiPhanCap.KhongXacDinh;
            NhomDuAn = NhomDuAn.KhongXacDinh;
        }
    }

    [DataContract]
    public class ListDuAnModelGridView
    {
        [DataMember]
        public List<DuAnModelGridView> DuAnModelGridView { get; set; }

        [DataMember]
        public long TotalRecords { get; set; }

        [DataMember]
        public long TotalPage { get; set; }
    }
}