using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using UnitSettingLibrary;

namespace BusinessLogic.Models
{
    [DataContract]
    public class KeHoachVonShortModel
    {
        [DataMember]
        public string MaDonVi { get; set; }

        [DataMember]
        public long IdDuAn { get; set; }

        [DataMember]
        public int NamKHV { get; set; }

        [DataMember]
        public int Dot { get; set; }

        [DataMember]
        public string SoQuyetDinh { get; set; }

        [DataMember]
        public long ThamDinhNoi { get; set; }

        [DataMember]
        public long ThamDinhNgoai { get; set; }

        [DataMember]
        public string TrangThaiThucHien { get; set; }

        [DataMember]
        public int TinhTrangXoa { get; set; }

        [DataMember]
        public long IdGiamSat { get; set; }

        [DataMember]
        public int GiaiDoanKHV { get; set; }

        [DataMember]
        public string GiaiDoanKHVValue { get; set; }      

        [DataMember]
        public int KetQuaGiamSat { get; set; }

        [DataMember]
        public string GhiChuGiamSat { get; set; }
       
    }
}