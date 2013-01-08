using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
                LoadGrid();

            }
        }
        public string CapNhatLoaiNguonVon(string ma_don_vi, string so_id_don_vi, string trang_thai)
        {
            ChangeResultSettings result = giamsatService.CapNhatLoaiNguonVon("","","",ma_don_vi, Int64.Parse(so_id_don_vi), Int64.Parse(trang_thai));

            if (result.ChangeResult == ChangeResult.ThanhCong)
            {
                return "Cập nhật thành công";
            }
            else {
                return result.Message; 
            }
        }
        public void LoadGrid()
        {

            string madonvi = Request.QueryString["madonvi"];
            long idduan = Int64.Parse(Request.QueryString["idduan"]);
            var duAn = giamsatService.ChiTietDuAn("", "", "", madonvi, idduan);
            hfMaDonVi.Value = madonvi;
            hfSoIdDonVi.Value = idduan.ToString(CultureInfo.InvariantCulture);

            lbMaDuAn.InnerText = duAn.MaDuAn;
            lbLoaiDuAn.InnerText = duAn.TenLoaiDuAn;
            lbNhomDuAn.InnerText = EnumHelper.GetDescription(duAn.NhomDuAn);
            lbSoQuyetDinh.InnerText = duAn.SoQuyetDinh;
            lbPhanCap.InnerText = EnumHelper.GetDescription(duAn.LoaiPhanCap);
            lbDonViQuanLyDT.InnerText = duAn.TenDonViQuanLy;
            lbDonViChuDT.InnerText = duAn.TenDonViThucHien;
            lbTongVonDT.InnerText = duAn.TongVonDauTu.ToString(CultureInfo.InvariantCulture);
            lbThoiGianPhatSinh.InnerText = duAn.NamBatDau.ToString(CultureInfo.InvariantCulture);
            lbThoiGianKetThuc.InnerText = duAn.NamKetThuc.ToString(CultureInfo.InvariantCulture);


            var loainv = EnumHelper.GetDescriptionForBind(LoaiNguonVon.KhongXacDinh);
            ddlLoaiNguonVon.DataSource = loainv;
            ddlLoaiNguonVon.DataTextField = "ValueString";
            ddlLoaiNguonVon.DataValueField = "ValueInt";
            ddlLoaiNguonVon.SelectedValue = Convert.ToString((int)duAn.LoaiNguonVon);
            ddlLoaiNguonVon.DataBind();
        }
    }
}