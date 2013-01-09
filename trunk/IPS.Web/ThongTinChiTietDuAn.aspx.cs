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
                LoadddlKeHoachVon();
                LoadKeHoachVon();
                LoadGridNhaThau();
                LoadGridHopDong();
            }
        }
        public string CapNhatLoaiNguonVon(string ma_don_vi, string so_id_don_vi, string trang_thai)
        {
            ChangeResultSettings result = giamsatService.CapNhatLoaiNguonVon("","","",ma_don_vi, Int64.Parse(so_id_don_vi), Int32.Parse(trang_thai));

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


        public void LoadddlKeHoachVon()
        {

            string madonvi = Request.QueryString["madonvi"];
            long idduan = Int64.Parse(Request.QueryString["idduan"]);
            var namKHV = giamsatService.NamKeHoachVon("", "", "", madonvi, idduan);
            //var namKHV = giamsatService.NamKeHoachVon("56", 20111118624371);
            if (namKHV != null && namKHV.Any())
            {
                ddlNamKeHoach.DataSource = namKHV;
                ddlNamKeHoach.DataBind();
            }
        }
        public void LoadKeHoachVon()
        {
            string madonvi = Request.QueryString["madonvi"];
            long idduan = Int64.Parse(Request.QueryString["idduan"]);
            string Nam = (string)Session["Nam"];
            var namKHV = giamsatService.NamKeHoachVon("", "", "", madonvi, idduan);

            //var namKHV = giamsatService.NamKeHoachVon("56", 20111118624371);
            var namInt = namKHV.First();
            if (Nam != null) namInt = Int32.Parse(Nam);
            //var result = giamsatService.DanhSachGiaiDoanKHV("", "", "", "56", 20111118624371, namInt);

            var result = giamsatService.DanhSachGiaiDoanKHV("", "", "", madonvi, idduan, namInt);
            if (result != null)
            {
                foreach (var item in result)
                {
                    item.TenKetQuaGiamSat = EnumHelper.GetDescription(item.KetQuaGiamSat);
                    if (item.GiaiDoanKHV != GiaiDoanKHV.KhongXacDinh)
                        item.TenGiaiDoan = EnumHelper.GetDescription(item.GiaiDoanKHV) + " đợt " + item.Dot;

                }
            }
            gridNamKeHoach.DataSource = result;
            gridNamKeHoach.DataBind();
            UpdatePanel("CallbackPanel2");
            Session["Nam"] = null;

        }
        public void LoadGridNhaThau()
        {
            string madonvi = Request.QueryString["madonvi"];
            long idduan = Int64.Parse(Request.QueryString["idduan"]);
            var result = giamsatService.DanhSachGoiThau("", "", "", madonvi, idduan, 200,1);
            //var result = giamsatService.DanhSachGoiThau("", "", "", "56", 20111118624371, 1);
            if (result.GoiThauModelsGridView != null)
            {
                foreach (var item in result.GoiThauModelsGridView)
                {
                    item.TenGiaiDoan = EnumHelper.GetDescription(item.GiaiDoanDauThau);
                    item.TenKetQuaGiamSat = EnumHelper.GetDescription(item.KetQuaGiamSat);
                }
            }
            gridNhaThau.DataSource = result.GoiThauModelsGridView;
            gridNhaThau.DataBind();
        }

        public void LoadGridHopDong()
        {
            string MaDonVi = (string)Session["MaDonVi"];
            string SoIdGoiThau = (string)Session["SoIdGoiThau"];

            if (MaDonVi != null && SoIdGoiThau != null)
            {
                var result = giamsatService.DanhSachHopDong("", "", "", MaDonVi, Int64.Parse(SoIdGoiThau),200, 1);
                // var result = giamsatService.DanhSachHopDong("", "", "", "51", 20120921644556, 1);
                if (result.HopDongModelsGridView != null)
                {
                    var listDes = EnumHelper.GetDescriptionForBind(KetQuaGiamSat.ChamDoGPMB);
                    foreach (var item in result.HopDongModelsGridView)
                    {
                        item.TenKetQuaGiamSat = EnumHelper.GetDescription(item.KetQuaGiamSat);
                    }
                }
                gridHopDong.DataSource = result.HopDongModelsGridView;
                gridHopDong.DataBind();
            }
            else
            {
                gridHopDong.DataSource = null;
                gridHopDong.DataBind();
            }
            UpdatePanel("CallbackPanel1");
            Session["MaDonVi"] = null;
            Session["SoIdGoiThau"] = null;
        }
        public void AddDonVi(string MaDonVi, string SoIdGoiThau)
        {
            Session["MaDonVi"] = MaDonVi;
            Session["SoIdGoiThau"] = SoIdGoiThau;
            LoadGridHopDong();
        }

        public void AddKeHoachVon(string Nam)
        {
            Session["Nam"] = Nam;
            LoadKeHoachVon();
        }
    }
}