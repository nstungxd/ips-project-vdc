<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IPS.Web.Login" %>

<%@ Register Assembly="vdc_Interface" Namespace="Vdc.Interface" TagPrefix="cc2" %>
<%--<%@ Register Assembly="vdc_Interface" Namespace="Vdc.Interface" TagPrefix="cc2" %>

<%@ Register Assembly="vdc_Grid_NET" Namespace="Vdc.Grid" TagPrefix="cc1" %>--%>
<!DOCTYPE html>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Đăng nhập</title>
    <link href="css/s_font.css" rel="stylesheet" type="text/css" />
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <link href="css/style_vnpt.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
</head>
<body style="background-color: #ffffff; width: 100%; height: 100%; clip: rect(auto auto auto auto);
    margin-top: 0px; margin-left: 0px; background-image: url(images/cell.jpg);">
    <form id="form1" runat="server">
        
    <div>
        <table id="login_wrap" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <div align="center" style="margin-top: 200px;">
                    </div>
                    <div id="lg_block">
                        <div id="lg_content">
                            <div align="center" id="lg_vnptlogo">
                                <img alt="" src="images/login_chung.jpg" width="80" height="82" /></div>
                            <div>
                                <table id="UPa_ct" runat="server" width="90%" align="center" cellspacing="0" cellpadding="0"
                                    class="login_tbl">
                                    <tr>
                                        <td colspan="2" align="left">
                                            <asp:Label ID="loi_login" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label3" runat="server" CssClass="field_td" Text="Mã đơn vị" Width="64px"></asp:Label>
                                        </td>
                                        <td class="form_element" align="left">
                                            <cc2:VdcTextBox ID="txtmadonvi" runat="server" FolderStyle="btstyles/premiere_blue/VdcTextBox">
                            </cc2:VdcTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label2" runat="server" CssClass="field_td" Text="Mã NSD" />
                                        </td>
                                        <td class="form_element" align="left">
                                            <cc2:VdcTextBox ID="txtmansd" runat="server" FolderStyle="btstyles/premiere_blue/VdcTextBox">
                            </cc2:VdcTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label8" runat="server" CssClass="field_td" Text="Mật khẩu" />
                                        </td>
                                        <td class="form_element" align="left">
                                            <cc2:VdcTextBox ID="password" TextMode="Password" runat="server" FolderStyle="btstyles/premiere_blue/VdcTextBox">
                            </cc2:VdcTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td align="left" valign="top" class="form_element">
                                            <div id="lg_button">
                                                <cc2:VdcButton ID="VdcButton1" runat="server" Text="Đăng nhập" OnClick="VdcButton1_Click"></cc2:VdcButton>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

