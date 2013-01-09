using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitSettingLibrary
{
    public class NguoiDungModel
    {
        public string MaDonVi { get; set; }

        public long UserId { get; set; }

        public string TenTruyCap { get; set; }

        public string HoTen { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string SoDienThoai { get; set; }

        public List<NghiepVuModel> ListNghiepVuModel { get; set; }

        public List<NhomNguoiDungModel> ListNhomNguoiDungModel { get; set; } 
    }

    public class NhomNguoiDungModel
    {
        public int ModuleId { get; set; }

        public string MaDonVi { get; set; }

        public long NhomId { get; set; }

        public string MaNhom { get; set; }

        public string TenNhom { get; set; }

        public List<NghiepVuModel> ListNghiepVuModel { get; set; }       

    }

    public class NghiepVuModel
    {
        public int ModuleId { get; set; }      

        public string MaNghiepVu { get; set; }

        public string TenNghiepVu { get; set; }

        public string Quyen { get; set; }
    }

}
