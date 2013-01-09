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
    public partial class GiamSat1 : VdcInc.vdcAJAXPage
    {
        GiamSatServiceReference.GiamSatServicesClient giamsatService = new GiamSatServiceReference.GiamSatServicesClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadKeHoachVon();
                LoadGridNhaThau();
                LoadGridHopDong();
                LoadddlKetQuaGiamSat();
            }
        }
        public void LoadKeHoachVon()
        {
            //string madonvi = Request.QueryString["madonvi"];
            //long idduan = Int64.Parse(Request.QueryString["idduan"]);
            string Nam = (string)Session["Nam"];
            //var namKHV = giamsatService.NamKeHoachVon("","","",madonvi, idduan);

            var namKHV = giamsatService.NamKeHoachVon("", "", "", "56", 20111118624371);
            var namInt = namKHV.First();
            if (Nam != null) namInt = Int32.Parse(Nam);
            var result = giamsatService.DanhSachGiaiDoanKHV("", "", "", "56", 20111118624371, namInt);

            //var result = giamsatService.DanhSachGiaiDoanKHV("", "", "", madonvi, idduan, namInt);
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
        }
        public void LoadGridNhaThau()
        {
            //string madonvi = Request.QueryString["madonvi"];
            //long idduan = Int64.Parse(Request.QueryString["idduan"]);
            //var result = giamsatService.DanhSachGoiThau("", "", "", madonvi, idduan, 200,1);
           var result = giamsatService.DanhSachGoiThau("", "", "", "56", 20111118624371,200, 1);
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

            //if (MaDonVi != null && SoIdGoiThau != null)
            //{
                //var result = giamsatService.DanhSachHopDong("", "", "", MaDonVi, Int64.Parse(SoIdGoiThau),200, 1);
                 var result = giamsatService.DanhSachHopDong("", "", "", "51", 20120921644556,200, 1);
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
            //}
            //else
            //{
            //    gridHopDong.DataSource = null;
            //    gridHopDong.DataBind();
            //}
        }



        public void LoadddlKetQuaGiamSat()
        {
            var nhomda = EnumHelper.GetDescriptionForBind(KetQuaGiamSat.ChamDoGPMB);
            ComboBoxEditor.DataSource = nhomda;
            ComboBoxEditor.DataTextField = "ValueString";
            ComboBoxEditor.DataValueField = "name";
            ComboBoxEditor.DataBind();
        }
        public string CapNhatKeHoachVon(string stringGridKHV)
        {
            string excelData = stringGridKHV;
            string[] rowSeparator = new string[] { "|*row*|" };
            string[] cellSeparator = new string[] { "|*cell*|" };
            string[] dataRows = excelData.Split(rowSeparator, StringSplitOptions.None);
            string a = "";
            for (int i = 0; i < dataRows.Length; i++)
            {
                string[] dataCells = dataRows[i].Split(cellSeparator, StringSplitOptions.None);

               
                string TenGiaiDoan = dataCells[0];
                string TrangThaiThucHien = dataCells[1];
                string TenKetQuaGiamSat = dataCells[2];
                string GhiChu = dataCells[3];
                string GiamSatId = dataCells[4];
                
                
                    //GiamSatSetting[] lstGiamsat = null;
                    //foreach (var gs in lstGiamsat)
                    //{
                    //    gs.GiamSatID = Int64.Parse(GiamSatId);
                    //    gs.GhiChu = GhiChu;

                    //}
                    GiamSatSetting[] subjects = new GiamSatSetting[1];
                    GiamSatSetting gss = new GiamSatSetting();
                    gss.GiamSatID = Int64.Parse(GiamSatId);
                    gss.GhiChu = GhiChu;
                    subjects[0] = gss;
                    ChangeResultSettings result = giamsatService.GiamSat("", "", "", (int)LoaiGiamSat.GiamSatKHV, subjects);
                    if (result.ChangeResult == ChangeResult.ThanhCong)
                    {
                        a += "Cập nhật thành công |";
                    }
                    else
                    {
                        a += result.Message + " |";
                    }
            }
            return a;
        }
    }
}