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
        public LoaiNguonVon LoaiNguonVon { get; set; }

        [DataMember]
        public string TenLoaiNguonVon { get; set; }       

        [DataMember]
        public LoaiPhanCap LoaiPhanCap { get; set; }

        [DataMember]
        public string TenLoaiPhanCap { get; set; } 

        [DataMember]
        public NhomDuAn NhomDuAn { get; set; }

        [DataMember]
        public string TenNhomDuAn { get; set; } 

        [DataMember]
        public string MaLoaiDuAn { get; set; }

        [DataMember]
        public string TenLoaiDuAn { get; set; } 

        [DataMember]
        public int NamBatDau { get; set; }

        [DataMember]
        public int NamKetThuc { get; set; }

        [DataMember]
        public long TongVonDauTu { get; set; }  
     
        
        // extend properties for detail
        [DataMember]
        public string TenDonViThucHien { get; set; }

        [DataMember]
        public string TenDonViQuanLy { get; set; }

        [DataMember]
        public string SoQuyetDinh { get; set; }

        public DuAnShortModel()
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
        public List<DuAnShortModel> DuAnModelsGridView { get; set; }

        [DataMember]
        public long TotalRecords { get; set; }

        [DataMember]
        public long TotalPage { get; set; }
    }
}