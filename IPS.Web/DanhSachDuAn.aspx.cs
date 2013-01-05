using IPS.Web.GiamSatServiceReference;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnitSettingLibrary;

namespace IPS.Web
{
    public partial class DanhSachDuAn : System.Web.UI.Page
    {
        GiamSatServiceReference.GiamSatServicesClient giamsatService = new GiamSatServiceReference.GiamSatServicesClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            LoadDropDownList();

        }
        public void LoadDropDownList()
        {
            var loaida = EnumHelper.GetDescriptionForBind(LoaiDuAn.KhongXacDinh);
            ddlLoaiDuAn.DataSource = loaida;
            ddlLoaiDuAn.DataTextField = "ValueString";
            ddlLoaiDuAn.DataValueField = "name";
            ddlLoaiDuAn.DataBind();

            var nhomda = EnumHelper.GetDescriptionForBind(NhomDuAn.KhongXacDinh);
            ddlNhomDuAn.DataSource = nhomda;
            ddlNhomDuAn.DataTextField = "ValueString";
            ddlNhomDuAn.DataValueField = "name";
            ddlNhomDuAn.DataBind();

            var loainv = EnumHelper.GetDescriptionForBind(LoaiNguonVon.KhongXacDinh);
            ddlLoaiNguonVon.DataSource = loainv;
            ddlLoaiNguonVon.DataTextField = "ValueString";
            ddlLoaiNguonVon.DataValueField = "ValueInt";
            ddlLoaiNguonVon.DataBind();

            var phancap = EnumHelper.GetDescriptionForBind(LoaiPhanCap.KhongXacDinh);
            ddlPhanCap.DataSource = phancap;
            ddlPhanCap.DataTextField = "ValueString";
            ddlPhanCap.DataValueField = "name";
            ddlPhanCap.DataBind();

            ddlDonViChuDT.DataSource = giamsatService.DanhSachDonVi("", "", ""); ;
            ddlDonViChuDT.DataTextField = "TenDonVi";
            ddlDonViChuDT.DataValueField = "MaDonVi";
            ddlDonViChuDT.DataBind();

            ddlDonViQuanLyDT.DataSource = giamsatService.DanhSachDonVi("", "", "");
            ddlDonViQuanLyDT.DataTextField = "TenDonVi";
            ddlDonViQuanLyDT.DataValueField = "MaDonVi";
            ddlDonViQuanLyDT.DataBind(); 

            ////load dropdownlist toán tử
            //var dicToanTu = Common.ToanTuSoSanh();
            //ddlTTTongVonDT.DataSource = dicToanTu;
            //ddlTTTongVonDT.DataTextField = "Value";
            //ddlTTTongVonDT.DataValueField = "Key";
            //ddlTTTongVonDT.DataBind();

            //ddlTTThoiGianPhatSinh.DataSource = dicToanTu;
            //ddlTTThoiGianPhatSinh.DataTextField = "Value";
            //ddlTTThoiGianPhatSinh.DataValueField = "Key";
            //ddlTTThoiGianPhatSinh.DataBind();

            //ddlTTThoiGianKetThuc.DataSource = dicToanTu;
            //ddlTTThoiGianKetThuc.DataTextField = "Value";
            //ddlTTThoiGianKetThuc.DataValueField = "Key";
            //ddlTTThoiGianKetThuc.DataBind();

            // hoathan
            var listToanTu = Common.ToanTuSoSanh();
            foreach (string name in listToanTu)
            {
                ddlTTTongVonDT.Items.Add(new ListItem(name));
                ddlTTThoiGianPhatSinh.Items.Add(new ListItem(name));
                ddlTTThoiGianKetThuc.Items.Add(new ListItem(name));
            }
            
        }
        public void LoadGrid()
        { 
        }

        protected void btTimKiem_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                SearchProjectSetting sps = new SearchProjectSetting();
                sps.MaDuAn = txtMaDuAn.Text;
                sps.LoaiDuAn = ddlLoaiDuAn.SelectedValue == LoaiDuAn.KhongXacDinh.ToString() ? "" : ddlLoaiDuAn.SelectedValue;
                sps.NhomDuAn = ddlNhomDuAn.SelectedValue == NhomDuAn.KhongXacDinh.ToString() ? "" : ddlNhomDuAn.SelectedValue;
                sps.LoaiNguonVon = Int64.Parse(ddlLoaiNguonVon.SelectedValue);
                sps.PhanCap = ddlPhanCap.SelectedValue == LoaiPhanCap.KhongXacDinh.ToString() ? "" : ddlPhanCap.SelectedValue;
                sps.MaDonViQuanLy = ddlDonViQuanLyDT.SelectedValue;
                sps.MaDonViThucHien = ddlDonViChuDT.SelectedValue;
                sps.TongVonDauTuToanTu = ddlTTTongVonDT.SelectedValue;
                sps.TongVonDauTu = Int64.Parse(txtTongVonDT.Text == "" ? "0" : txtTongVonDT.Text);
                sps.NamBatDauToanTu = ddlTTThoiGianPhatSinh.SelectedValue;
                sps.NamBatDau = Int64.Parse(txtThoiGianPhatSinh.Text == "" ? "0" : txtThoiGianPhatSinh.Text);
                sps.NamKetThucToanTu = ddlTTThoiGianKetThuc.SelectedValue;
                sps.NamKetThuc = Int64.Parse(txtThoiGianKetThuc.Text == "" ? "0" : txtThoiGianKetThuc.Text);
                ListDuAnModelGridView result =  giamsatService.TimKiemDuAn("", "", "", sps, 1);
                Grid1.DataSource = result.DuAnModelsGridView;
                Grid1.DataBind();

            }
        }
        public bool Validate() {
            return true;
        }
    }
}