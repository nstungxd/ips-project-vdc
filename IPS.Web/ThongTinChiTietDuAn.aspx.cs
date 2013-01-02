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
    public partial class ThongTinChiTietDuAn : VdcInc.vdcAJAXPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsCallback) {
                Hashtable ht = GetEnumForBind(typeof(LoaiNguonVon));
                ddlLoaiNguonVon.DataSource = ht;
                ddlLoaiNguonVon.DataTextField = "value";
                ddlLoaiNguonVon.DataValueField = "key";
                ddlLoaiNguonVon.DataBind();

            }
        }
        public Hashtable GetEnumForBind(Type enumeration)
        {
            string[] names = Enum.GetNames(enumeration);
            Array values = Enum.GetValues(enumeration);
            Hashtable ht = new Hashtable();
            for (int i = 0; i < names.Length; i++)
            {
                ht.Add(Convert.ToInt32(values.GetValue(i)).ToString(), names[i]);
            }
            return ht;
        }
        public string CapNhatLoaiNguonVon(string text, string value)
        {
            return text + "#####" + value;
        }
    }
}