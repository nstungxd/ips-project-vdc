using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BusinessLogic.Models
{
    [DataContract]
    public class GoiThauShortModel
    {
        [DataMember]
        public string MaDonVi { get; set; }

        [DataMember]
        public long IdDuAn { get; set; }

        [DataMember]
        public long IdGoiThau { get; set; }

        [DataMember]
        public string HinhThucDauThau { get; set; }

        [DataMember]
        public string TrangThaiThucHien { get; set; }

        [DataMember]
        public int TinhTrangXoa { get; set; }

        [DataMember]
        public long IdGiamSat { get; set; }

        [DataMember]
        public int GiaiDoanDauThau { get; set; }       

        [DataMember]
        public int KetQuaGiamSat { get; set; }

        [DataMember]
        public string GhiChuGiamSat { get; set; }
    }

    [DataContract]
    public class ListGoiThauModelGridView
    {
        [DataMember]
        public List<GoiThauShortModel> GoiThauModelsGridView { get; set; }

        [DataMember]
        public long TotalRecords { get; set; }

        [DataMember]
        public long TotalPage { get; set; }
    }
}