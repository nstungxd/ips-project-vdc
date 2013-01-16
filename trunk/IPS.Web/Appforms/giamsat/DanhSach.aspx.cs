using IPS.Web.GiamSatSrv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnitSettingLibrary;

namespace IPS.Web.Appforms.giamsat
{
    public partial class DanhSach : System.Web.UI.Page
    {
        GiamSatSrv.GiamSatServicesClient giamsatService = new GiamSatSrv.GiamSatServicesClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropDownList();
            }
        }
        public void LoadDropDownList()
        {
            var loaida = giamsatService.DanhSachLoaiDuAn("", "", "", "--Chọn giá trị--");
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

            ddlDonViChuDT.DataSource = giamsatService.DanhSachDonVi("", "", "", "--Chọn giá trị--"); ;
            ddlDonViChuDT.DataTextField = "TenDonVi";
            ddlDonViChuDT.DataValueField = "MaDonVi";
            ddlDonViChuDT.DataBind();

            ddlDonViQuanLyDT.DataSource = giamsatService.DanhSachDonVi("", "", "", "--Chọn giá trị--");
            ddlDonViQuanLyDT.DataTextField = "TenDonVi";
            ddlDonViQuanLyDT.DataValueField = "MaDonVi";
            ddlDonViQuanLyDT.DataBind();

            var listNam = Common.DanhSachNam(1990, 2020);
            foreach (int nam in listNam)
            {
                ddlThoiGianKetThuc.Items.Add(new ListItem(nam.ToString()));
                ddlThoiGianPhatSinh.Items.Add(new ListItem(nam.ToString()));
            }
            ddlThoiGianKetThuc.SelectedValue = DateTime.Now.Year.ToString();
            ddlThoiGianPhatSinh.SelectedValue = DateTime.Now.Year.ToString();
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
                var pageSize = 200;
                var sps = new SearchProjectSetting();
                sps.MaDuAn = txtMaDuAn.Text;
                sps.LoaiDuAn = ddlLoaiDuAn.SelectedValue;
                sps.NhomDuAn = (NhomDuAn)Enum.Parse(typeof(NhomDuAn), ddlNhomDuAn.SelectedValue);
                sps.LoaiNguonVon = (LoaiNguonVon)Enum.Parse(typeof(LoaiNguonVon), ddlLoaiNguonVon.SelectedValue);
                sps.PhanCap = (LoaiPhanCap)Enum.Parse(typeof(LoaiPhanCap), ddlPhanCap.SelectedValue);
                sps.MaDonViQuanLy = ddlDonViQuanLyDT.SelectedValue;
                sps.MaDonViThucHien = ddlDonViChuDT.SelectedValue;
                sps.TongVonDauTuToanTu = ddlTTTongVonDT.SelectedValue;
                sps.TongVonDauTu = Int64.Parse(txtTongVonDT.Text == "" ? "0" : txtTongVonDT.Text);
                sps.NamBatDauToanTu = ddlTTThoiGianPhatSinh.SelectedValue;
                sps.NamBatDau = Int32.Parse(ddlThoiGianPhatSinh.SelectedValue);// Int32.Parse(txtThoiGianPhatSinh.Text == "" ? "0" : txtThoiGianPhatSinh.Text);
                sps.NamKetThucToanTu = ddlTTThoiGianKetThuc.SelectedValue;
                sps.NamKetThuc = Int32.Parse(ddlThoiGianKetThuc.SelectedValue);
                ListDuAnModelGridView result = giamsatService.TimKiemDuAn("", "", "", sps, pageSize, 1);
                //if (result.DuAnModelsGridView != null)
                //{
                //    foreach (var item in result.DuAnModelsGridView)
                //    {
                //        string a = "";
                //        item.TongVonDauTu = Common.GetValueFormatNumber(a);
                //    }
                //}
                Grid1.DataSource = result.DuAnModelsGridView;
                Grid1.DataBind();

            }
        }
        public bool Validate()
        {
            return true;
        }
    }
}