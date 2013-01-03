using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnitSettingLibrary;

namespace IPS.Web
{
    public partial class ThongTinChiTietDuAn : VdcInc.vdcAJAXPage
    {
        GiamSatServiceReference.GiamSatServicesClient giamsatService = new GiamSatServiceReference.GiamSatServicesClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsCallback) {
                loadGrid();

            }
        }
        public string CapNhatLoaiNguonVon(string ma_don_vi, string so_id_don_vi, string trang_thai)
        {
            ChangeResultSettings result = giamsatService.CapNhatLoaiNguonVon(ma_don_vi, Int64.Parse(so_id_don_vi), Int64.Parse(trang_thai));

            if (result.ChangeResult == ChangeResult.ThanhCong)
            {
                return "Cập nhật thành công";
            }
            else {
                return result.Message; 
            }
        }
        public void loadGrid()
        {
            string result = giamsatService.ChiTietDuAnReturnString("29", 20120925648670);
            hfMaDonVi.Value = "29";
            hfSoIdDonVi.Value = "20120925648670";
            
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var d = jss.Deserialize<dynamic>(result);
            lbMaDuAn.InnerText = (string)d[0]["MA"];
            lbLoaiDuAn.InnerText = (string)d[0]["LOAI"];
            lbNhomDuAn.InnerText = (string)d[0]["NHOM_DA"];
            lbSoQuyetDinh.InnerText = (string)d[0]["SO_QD"];
            lbPhanCap.InnerText = (string)d[0]["PHAN_CAP"];
            lbDonViQuanLyDT.InnerText = (string)d[0]["TEN_DONVI_QUANLY"];
            lbDonViChuDT.InnerText = (string)d[0]["TEN_DONVI_THUCHIEN"];
            lbTongVonDT.InnerText = (string)d[0]["TIEN_QD"];
            lbThoiGianPhatSinh.InnerText = (string)d[0]["NAM_BD"];
            lbThoiGianKetThuc.InnerText = (string)d[0]["NAM_KT"];

            Hashtable ht = Common.GetEnumForBind(typeof(LoaiNguonVon));
            ddlLoaiNguonVon.DataSource = ht;
            ddlLoaiNguonVon.DataTextField = "value";
            ddlLoaiNguonVon.DataValueField = "key";
            ddlLoaiNguonVon.SelectedValue = (string)d[0]["LOAI_NGUON_VON"];
            ddlLoaiNguonVon.DataBind();

        }
    }
}