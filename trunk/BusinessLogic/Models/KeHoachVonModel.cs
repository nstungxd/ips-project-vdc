using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using UnitSettingLibrary;

namespace BusinessLogic.Models
{
    // dung cho grid view
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
        public string TrangThaiThucHien { get; set; }

        [DataMember]
        public int TinhTrangXoa { get; set; }

        [DataMember]
        public long IdGiamSat { get; set; }

        [DataMember]
        public int GiaiDoanKHV { get; set; }

        [DataMember]
        public string TenGiaiDoan { get; set; }
       
        [DataMember]
        public int KetQuaGiamSat { get; set; }

        [DataMember]
        public string TenKetQuaGiamSat { get; set; }

        [DataMember]
        public string GhiChuGiamSat { get; set; }

        public KeHoachVonShortModel()
        {
            KetQuaGiamSat = -1;           
        }
       
    }

    // dung cho cac trang chi tiet
    [DataContract]
    public class KeHoachVonModel
    {
    }

}