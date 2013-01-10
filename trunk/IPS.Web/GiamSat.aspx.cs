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
    public partial class GiamSat : VdcInc.vdcAJAXPage
    {
        GiamSatServiceReference.GiamSatServicesClient giamsatService = new GiamSatServiceReference.GiamSatServicesClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid1();
                //LoadGrid2();
                //LoadGrid3();
                LoadDropDownListLoaiNguonVon();
                //LoadDropDownListPhanCap();
            }
        }


        public void LoadGrid1()
        {
           // ListDuAnModelGridView result = GetValueSPS();
            var result = giamsatService.DanhSachGiaiDoanKHV("", "", "", "56", 20111118624371, 2011);

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
            //Grid1.DataSource = result.DuAnModelsGridView;
            //Grid1.DataBind();
        }

        //public void LoadGrid2()
        //{
        //    ListDuAnModelGridView result = GetValueSPS();
        //    Grid2.DataSource = result.DuAnModelsGridView;
        //    Grid2.DataBind();
        //}
        //public void LoadGrid3()
        //{
        //    ListDuAnModelGridView result = GetValueSPS();
        //    Grid3.DataSource = result.DuAnModelsGridView;
        //    Grid3.DataBind();
        //}
        public void LoadDropDownListLoaiNguonVon()
        {

            var nhomda = EnumHelper.GetDescriptionForBind(KetQuaGiamSat.ChamDoGPMB);
            ComboBoxEditor.DataSource = nhomda;
            ComboBoxEditor.DataTextField = "ValueString";
            ComboBoxEditor.DataValueField = "name";
            ComboBoxEditor.DataBind();
        }

        //public void LoadDropDownListPhanCap()
        //{
        //    var loaipc = EnumHelper.GetDescriptionForBind(LoaiPhanCap.KhongXacDinh);
        //    ComboBoxEditor1.DataSource = loaipc;
        //    ComboBoxEditor1.DataTextField = "ValueString";
        //    ComboBoxEditor1.DataValueField = "ValueInt";
        //    ComboBoxEditor1.DataBind();
        //}
        public ListDuAnModelGridView GetValueSPS()
        {
            SearchProjectSetting sps = new SearchProjectSetting();
            sps.MaDuAn = "";
            sps.LoaiDuAn = "";
            sps.NhomDuAn = NhomDuAn.KhongXacDinh;
            sps.LoaiNguonVon = LoaiNguonVon.KhongXacDinh;
            sps.PhanCap = LoaiPhanCap.KhongXacDinh;
            sps.MaDonViQuanLy = "";
            sps.MaDonViThucHien = "";
            sps.TongVonDauTuToanTu = ">";
            sps.TongVonDauTu = 0;
            sps.NamBatDauToanTu = ">";
            sps.NamBatDau = 2013;
            sps.NamKetThucToanTu = ">";
            sps.NamKetThuc = 2013;
            ListDuAnModelGridView result = giamsatService.TimKiemDuAn("", "", "", sps, 200,1);
            return result;
        }
    }
}