using IPS.Web.GiamSatServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnitSettingLibrary;

namespace IPS.Web
{
    public partial class GiamSatDuAn : VdcInc.vdcAJAXPage
    {
        GiamSatServiceReference.GiamSatServicesClient giamsatService = new GiamSatServiceReference.GiamSatServicesClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadddlKeHoachVon();
            LoadKeHoachVon();
            LoadGridNhaThau();
            LoadGridHopDong();
        }
        public void LoadddlKeHoachVon()
        {
            var namKHV = giamsatService.NamKeHoachVon("56", 20111118624371);
            if (namKHV != null && namKHV.Any())
            {
                ddlNamKeHoach.DataSource = namKHV;
                ddlNamKeHoach.DataBind();
            }
        }
        public void LoadKeHoachVon()
        {
            string Nam = (string)Session["Nam"];
            var namKHV = giamsatService.NamKeHoachVon("56", 20111118624371);
            var namInt = namKHV.First();
            if (Nam != null) namInt = Int32.Parse(Nam);
            var result = giamsatService.DanhSachGiaiDoanKHV("", "", "", "56", 20111118624371, namInt);
            //if (Nam != null)
            //{
            //    result = giamsatService.DanhSachGiaiDoanKHV("", "", "", "56", 20111118624371, Int32.Parse(Nam));
            //}
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
            var result = giamsatService.DanhSachGoiThau("", "", "", "56", 20111118624371, 1);
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
                var result = giamsatService.DanhSachHopDong("", "", "", MaDonVi, Int64.Parse(SoIdGoiThau), 1);
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