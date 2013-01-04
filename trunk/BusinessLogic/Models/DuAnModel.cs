using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using UnitSettingLibrary;

namespace BusinessLogic.Models
{
    [DataContract]
    public class DuAnShortModel
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
        public long LoaiNguonVon { get; set; }

        [DataMember]
        public string LoaiPhanCap { get; set; }        

        [DataMember]
        public string NhomDuAn { get; set; }           

        [DataMember]
        public long NamBatDau { get; set; }

        [DataMember]
        public long NamKetThuc { get; set; }

        [DataMember]
        public long TongVonDauTu { get; set; }       
    }

    [DataContract]
    public class ListDuAnModelGridView
    {
        [DataMember]
        public List<DuAnShortModel> DuAnModelsGridView { get; set; }

        [DataMember]
        public long TotalRecords { get; set; }

        [DataMember]
        public long TotalPage { get; set; }
    }
}