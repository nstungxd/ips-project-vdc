using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using UnitSettingLibrary;

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
        public string TenGoiThau { get; set; }

        [DataMember]
        public string HinhThucDauThau { get; set; }

        [DataMember]
        public string TenGiaiDoan { get; set; }

        [DataMember]
        public string TrangThaiThucHien { get; set; }

        [DataMember]
        public TinhTrangXoa TinhTrangXoa { get; set; }

        [DataMember]
        public long IdGiamSat { get; set; }

        [DataMember]
        public GiaiDoanChonNhaThau GiaiDoanDauThau { get; set; }       

        [DataMember]
        public KetQuaGiamSat KetQuaGiamSat { get; set; }

        [DataMember]
        public string TenKetQuaGiamSat { get; set; }

        [DataMember]
        public string GhiChuGiamSat { get; set; }

        public GoiThauShortModel()
        {
            KetQuaGiamSat = KetQuaGiamSat.KhongXacDinh;
            TinhTrangXoa = TinhTrangXoa.ChuaXoa;
            GiaiDoanDauThau = GiaiDoanChonNhaThau.KhongXacDinh;            
        }
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

    // dung cho trang chi tiet
    [DataContract]
    public class GoiThauModel
    {
    }

    // dung cho trang chi tiet
    [DataContract]
    public class ThongTinMoiThauModel
    {
    }

    // dung cho trang chi tiet
    [DataContract]
    public class ThongTinMoThauModel
    {
    }

    // dung cho trang chi tiet
    [DataContract]
    public class ThongTinXetThauModel
    {
    }
}