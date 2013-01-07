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
    public partial class GiamSat1 : System.Web.UI.Page
    {
        GiamSatServiceReference.GiamSatServicesClient giamsatService = new GiamSatServiceReference.GiamSatServicesClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid1();
            }
        }
        public void LoadGrid1()
        {
            ListDuAnModelGridView result = GetValueSPS();
            Grid1.DataSource = result.DuAnModelsGridView;
            Grid1.DataBind();
        }
        public ListDuAnModelGridView GetValueSPS()
        {
            SearchProjectSetting sps = new SearchProjectSetting();
            sps.MaDuAn = "";
            sps.LoaiDuAn = "";
            sps.NhomDuAn = "";
            sps.LoaiNguonVon = -1;
            sps.PhanCap = "";
            sps.MaDonViQuanLy = "";
            sps.MaDonViThucHien = "";
            sps.TongVonDauTuToanTu = ">";
            sps.TongVonDauTu = 0;
            sps.NamBatDauToanTu = ">";
            sps.NamBatDau = 2013;
            sps.NamKetThucToanTu = ">";
            sps.NamKetThuc = 2013;
            ListDuAnModelGridView result = giamsatService.TimKiemDuAn("", "", "", sps, 1);
            return result;
        }
    }
}