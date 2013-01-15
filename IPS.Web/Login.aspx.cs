using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IPS.Web.UserServiceReference;
using UnitSettingLibrary;

namespace IPS.Web
{
    public partial class Login : System.Web.UI.Page
    {        
         
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            txtmadonvi.Focus();   
        }

        protected void VdcButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtmadonvi.Text) || string.IsNullOrEmpty(txtmansd.Text) || string.IsNullOrEmpty(password.Text))
                {
                    loi_login.Text = "Thông tin nhâp vào không đầy đủ!";
                    return;
                }
                using (var userService = new UserServicesClient())
                {
                    var result = userService.Login(txtmadonvi.Text, txtmansd.Text, Common.Md5Encrypte(password.Text));
                    if (result.ChangeResult == ChangeResult.ThanhCong)
                    {
                        var nguoidung = new NguoiDungModel() { MaDonVi = txtmadonvi.Text, TenTruyCap = txtmansd.Text };
                        Session["nsd"] = nguoidung;
                        Response.Redirect("~/Appforms/giamsat/DanhSach.aspx");
                    }
                    else
                    {
                        if(!string.IsNullOrEmpty(result.Message))
                            loi_login.Text = result.Message;
                        else
                        {
                            loi_login.Text = "Tên hoặc mật khẩu không chính xác!";
                        }
                    }
                }
                using (var userSrv = new UserSrv.UserServicesClient())
                {
                    var result = userSrv.Login(txtmadonvi.Text, txtmansd.Text, Common.Md5Encrypte(password.Text));
                    if (result.ChangeResult == ChangeResult.ThanhCong)
                    {
                        var nguoidung = new NguoiDungModel() { MaDonVi = txtmadonvi.Text, TenTruyCap = txtmansd.Text };
                        Session["nsd"] = nguoidung;
                        Response.Redirect("~/Appforms/giamsat/DanhSach.aspx");
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(result.Message))
                            loi_login.Text = result.Message;
                        else
                        {
                            loi_login.Text = "Tên hoặc mật khẩu không chính xác!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                loi_login.Text = ex.Message;
            }            
        }
    }
}