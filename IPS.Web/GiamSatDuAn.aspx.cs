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
            var result = giamsatService.DanhSachGiaiDoanKHV("", "", "", "56", 20111118624371, namKHV.First());
            if (Nam != null)
            {
                result = giamsatService.DanhSachGiaiDoanKHV("", "", "", "56", 20111118624371, Int32.Parse(Nam));
            }
            if (result != null)
            {
                var listDes = EnumHelper.GetDescriptionForBind(KetQuaGiamSat.ChamDoGPMB);
                foreach (var item in result)
                {
                    foreach (var des in listDes)
                    {
                        if (item.KetQuaGiamSat == des.ValueInt)
                        {
                            item.TenKetQuaGiamSat = des.ValueString;
                            break;
                        }

                    }

                }
            }
            Grid3.DataSource = result;
            Grid3.DataBind();
            UpdatePanel("CallbackPanel2");
            Session["Nam"] = null;

        }
        public void LoadGridNhaThau()
        {
            var result = giamsatService.DanhSachGoiThau("", "", "", "56", 20111118624371, 1);
            if (result.GoiThauModelsGridView != null)
            {
                var listDes = EnumHelper.GetDescriptionForBind(KetQuaGiamSat.ChamDoGPMB);
                foreach (var item in result.GoiThauModelsGridView)
                {
                    foreach (var des in listDes)
                    {
                        if (item.KetQuaGiamSat == des.ValueInt)
                        {
                            item.TenKetQuaGiamSat = des.ValueString;
                            break;
                        }

                    }

                }
            }
            Grid1.DataSource = result.GoiThauModelsGridView;
            Grid1.DataBind();
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
                        foreach (var des in listDes)
                        {
                            if (item.KetQuaGiamSat == des.ValueInt)
                            {
                                item.TenKetQuaGiamSat = des.ValueString;
                                break;
                            }

                        }

                    }
                }
                Grid2.DataSource = result.HopDongModelsGridView;
                Grid2.DataBind();
            }
            else
            {
                Grid2.DataSource = null;
                Grid2.DataBind();
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