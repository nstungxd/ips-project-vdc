using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using UnitSettingLibrary;

namespace BusinessLogic.Models
{
    [DataContract]
    public class HopDongShortModel
    {
        [DataMember]
        public string MaDonVi { get; set; }

        [DataMember]
        public long IdGoiThau { get; set; }

        [DataMember]
        public long IdHopDong { get; set; }

        [DataMember]
        public string TenHopDong { get; set; }

        [DataMember]
        public string BenA { get; set; }

        [DataMember]
        public string BenB { get; set; }

        [DataMember]
        public long TienNoiTe { get; set; }

        [DataMember]
        public long TienNgoaiTe { get; set; }

        [DataMember]
        public string TinhTrangHopDong { get; set; }

        [DataMember]
        public TinhTrangXoa TinhTrangXoa { get; set; }

        [DataMember]
        public long IdGiamSat { get; set; }

        [DataMember]
        public KetQuaGiamSat KetQuaGiamSat { get; set; }

        [DataMember]
        public string TenKetQuaGiamSat { get; set; }

        [DataMember]
        public string GhiChuGiamSat { get; set; }

        public HopDongShortModel()
        {
            KetQuaGiamSat = KetQuaGiamSat.KhongXacDinh;
            TinhTrangXoa = TinhTrangXoa.ChuaXoa;            
        }
    }

    [DataContract]
    public class ListHopDongModelGridView
    {
        [DataMember]
        public List<HopDongShortModel> HopDongModelsGridView { get; set; }

        [DataMember]
        public long TotalRecords { get; set; }

        [DataMember]
        public long TotalPage { get; set; }
    }

    // dung cho trang chi tiet
    [DataContract]
    public class HopDongModel
    {
    }
}