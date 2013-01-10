using IPS.Web.GiamSatServiceReference;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                LoadGrid();
                LoadKeHoachVon();
                LoadGridNhaThau();
                LoadGridHopDong();
                LoadddlKetQuaGiamSat();
                LoadddlKeHoachVon();
            }
        }
        public void LoadddlKeHoachVon()
        {

            //string madonvi = Request.QueryString["madonvi"];
            //long idduan = Int64.Parse(Request.QueryString["idduan"]);
            //var namKHV = giamsatService.NamKeHoachVon("", "", "", madonvi, idduan);
            var namKHV = giamsatService.NamKeHoachVon("", "", "", "56", 20111118624371);
            if (namKHV != null && namKHV.Any())
            {
                ddlNamKeHoach.DataSource = namKHV;
                ddlNamKeHoach.DataBind();
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
            UpdatePanel("CallbackPanel2");
            Session["Nam"] = null;
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
        public string CapNhatKeHoachVon(string stringGridKHV,string Nam)
        {
            string madonvi = "56";
            long idduan =20111118624371;
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
                string Dot = dataCells[5];
                string SoQuyetDinh = dataCells[6];
                string GiaiDoanKHV = dataCells[7];

                if(GiamSatId != "0"){
                    GiamSatSetting[] subjects = new GiamSatSetting[1];
                    GiamSatSetting gss = new GiamSatSetting();
                    gss.GiamSatID = Int64.Parse(GiamSatId);
                    gss.MaDonVi = madonvi;
                    gss.DuAnID = idduan;
                    gss.NamKHV = Int32.Parse(Nam);
                    gss.GiaiDoanKHV = (GiaiDoanKHV)Convert.ToInt32(GiaiDoanKHV);
                    gss.SoQD = SoQuyetDinh;
                    gss.DotKHV = Convert.ToInt32(Dot);
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
                else a += " khong insert";
            }
            return a;
        }

        public string CapNhatHopDong(string stringGridHopDong)
        {
            string excelData = stringGridHopDong;
            string[] rowSeparator = new string[] { "|*row*|" };
            string[] cellSeparator = new string[] { "|*cell*|" };
            string[] dataRows = excelData.Split(rowSeparator, StringSplitOptions.None);
            string a = "";
            for (int i = 0; i < dataRows.Length; i++)
            {
                string[] dataCells = dataRows[i].Split(cellSeparator, StringSplitOptions.None);


                string TenHopDong = dataCells[0];
                string BenA = dataCells[1];
                string BenB = dataCells[2];
                string TienNo = dataCells[3];
                string TienNgoai = dataCells[4];
                string Ttthuchien = dataCells[5];
                string Ttgiamsat = dataCells[6];
                string Ghichu = dataCells[7];
                string GiamSatId = dataCells[8];

                if (GiamSatId != "0")
                {
                    GiamSatSetting[] subjects = new GiamSatSetting[1];
                    GiamSatSetting gss = new GiamSatSetting();
                    gss.GiamSatID = Int64.Parse(GiamSatId);
                    gss.GhiChu = Ghichu;
                    subjects[0] = gss;
                    ChangeResultSettings result = giamsatService.GiamSat("", "", "", (int)LoaiGiamSat.GiamSatHopDong, subjects);
                    if (result.ChangeResult == ChangeResult.ThanhCong)
                    {
                        a += "Cập nhật thành công |";
                    }
                    else
                    {
                        a += result.Message + " |";
                    }
                }
                else a += "khong insert |";
            }
            return a;
        }

        public string CapNhatNhaThau(string stringGridNhaThau)
        {
            ShowAlert(stringGridNhaThau);
            return stringGridNhaThau;
            //string excelData = stringGridNhaThau;
            //string[] rowSeparator = new string[] { "|*row*|" };
            //string[] cellSeparator = new string[] { "|*cell*|" };
            //string[] dataRows = excelData.Split(rowSeparator, StringSplitOptions.None);
            //string a = "";
            //for (int i = 0; i < dataRows.Length; i++)
            //{
            //    string[] dataCells = dataRows[i].Split(cellSeparator, StringSplitOptions.None);

            //    string TenHopDong = dataCells[0];
            //    string BenA = dataCells[1];
            //    string BenB = dataCells[2];
            //    string GiamSatId = dataCells[3];
            //    string Ghichu = dataCells[7];

            //    if (GiamSatId != "0")
            //    {
            //        GiamSatSetting[] subjects = new GiamSatSetting[1];
            //        GiamSatSetting gss = new GiamSatSetting();
            //        gss.GiamSatID = Int64.Parse(GiamSatId);
            //        gss.GhiChu = Ghichu;
            //        subjects[0] = gss;
            //        ChangeResultSettings result = giamsatService.GiamSat("", "", "", (int)LoaiGiamSat.GiamSatHopDong, subjects);
            //        if (result.ChangeResult == ChangeResult.ThanhCong)
            //        {
            //            a += "Cập nhật thành công |";
            //        }
            //        else
            //        {
            //            a += result.Message + " |";
            //        }
            //    }
            //    else a += "khong insert |";
            //}
            //return a;
        }
        public void AddKeHoachVon(string Nam)
        {
            Session["Nam"] = Nam;
            LoadKeHoachVon();
        }

        public string CapNhatLoaiNguonVon(string ma_don_vi, string so_id_don_vi, string trang_thai)
        {
            ChangeResultSettings result = giamsatService.CapNhatLoaiNguonVon("", "", "", ma_don_vi, Int64.Parse(so_id_don_vi), Int32.Parse(trang_thai));

            if (result.ChangeResult == ChangeResult.ThanhCong)
            {
                return "Cập nhật thành công";
            }
            else
            {
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