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
        public int LoaiNguonVon { get; set; }

        [DataMember]
        public string LoaiNguonVonValue { get; set; }
        //{
        //    get
        //    {
        //        var enumValue = EnumHelper.GetDescriptionForBind(UnitSettingLibrary.LoaiNguonVon.KhongXacDinh);
        //        foreach (var e in enumValue)
        //        {
        //            if (LoaiNguonVon == e.ValueInt)
        //            {
        //                return e.ValueString;
        //            }
        //        }
        //        return "";
        //    }
        //}

        [DataMember]
        public string LoaiPhanCap { get; set; }        

        [DataMember]
        public string NhomDuAn { get; set; }           

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
            var enumValue = EnumHelper.GetDescriptionForBind(UnitSettingLibrary.LoaiNguonVon.KhongXacDinh);
            foreach (var e in enumValue)
            {
                if (LoaiNguonVon == e.ValueInt)
                {
                    LoaiNguonVonValue = e.ValueString;
                    break;
                }
            }            
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