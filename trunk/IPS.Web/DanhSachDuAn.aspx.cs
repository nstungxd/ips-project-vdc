using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnitSettingLibrary;

namespace IPS.Web
{
    public partial class DanhSachDuAn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            loadGrid();

        }
        public void loadGrid()
        {

            Hashtable loaida = Common.GetEnumForBind(typeof(LoaiDuAn));
            ddlLoaiDuAn.DataSource = loaida;
            ddlLoaiDuAn.DataTextField = "value";
            ddlLoaiDuAn.DataValueField = "key";
            ddlLoaiDuAn.DataBind();

            Hashtable nhomda = Common.GetEnumForBind(typeof(NhomDuAn));
            ddlNhomDuAn.DataSource = nhomda;
            ddlNhomDuAn.DataTextField = "value";
            ddlNhomDuAn.DataValueField = "key";
            ddlNhomDuAn.DataBind();

            Hashtable loainv = Common.GetEnumForBind(typeof(LoaiNguonVon));
            ddlLoaiNguonVon.DataSource = loainv;
            ddlLoaiNguonVon.DataTextField = "value";
            ddlLoaiNguonVon.DataValueField = "key";
            ddlLoaiNguonVon.DataBind();

            Hashtable phancap = Common.GetEnumForBind(typeof(LoaiPhanCap));
            ddlPhanCap.DataSource = phancap;
            ddlPhanCap.DataTextField = "value";
            ddlPhanCap.DataValueField = "key";
            ddlPhanCap.DataBind();



            //load dropdownlist toán tử
            var dicToanTu = Common.ToanTuSoSanh();
            ddlTTTongVonDT.DataSource = dicToanTu;
            ddlTTTongVonDT.DataTextField = "Value";
            ddlTTTongVonDT.DataValueField = "Key";
            ddlTTTongVonDT.DataBind();

            ddlTTThoiGianPhatSinh.DataSource = dicToanTu;
            ddlTTThoiGianPhatSinh.DataTextField = "Value";
            ddlTTThoiGianPhatSinh.DataValueField = "Key";
            ddlTTThoiGianPhatSinh.DataBind();

            ddlTTThoiGianKetThuc.DataSource = dicToanTu;
            ddlTTThoiGianKetThuc.DataTextField = "Value";
            ddlTTThoiGianKetThuc.DataValueField = "Key";
            ddlTTThoiGianKetThuc.DataBind();


            
        }
    }
}