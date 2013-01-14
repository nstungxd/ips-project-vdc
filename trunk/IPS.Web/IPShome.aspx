<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IPShome.aspx.cs" Inherits="IPS.Web.IPShome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trang chủ hệ thống tổng hợp, giám sát đầu tư VNPT</title>
    <link href="css/s_font.css" rel="stylesheet" type="text/css" />
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <link href="css/style_vnpt.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <table style="height: 100%; width: 100%;" id="container" cellpadding="0" cellspacing="0">
        <tr>
            <td valign="top">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="top" align="center">
                            <div id="header_2">
                                <div class="banner">
                                    <h2>
                                        HỆ THỐNG TỔNG HỢP, GIÁM SÁT ĐẦU TƯ VNPT</h2>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <div id="nav">
                                <div class="menu_area">
                                    <div class="menu">
                                        <ul>
                                            <li><a href="#">Trang chủ</a></li>
                                            <li><a href="#">Trợ giúp</a></li>
                                            <li><a href="#">Danh mục</a></li>
                                            <li><a href="#">Hệ thống</a></li>
                                            <li><a href="#">Báo cáo</a></li>
                                            <li><a href="#">Thoát</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <div class="IPS_content">
                    <div class="IPS_wrap">
                        <div class="slide" align="center" style="padding:15px 39px 0 39px;"><img src="images/IPS_slide.png" width="870px" height="292px" /></div>
                        <div class="function">
                            <ul>
                                <li class="ls_selected"><a href="#">PHÂN TÍCH VÀ QUẢN LÝ DỮ LIỆU KẾ HOẠCH</a></li>
                                <li><a href="DanhSachDuAn.aspx">TỔNG HỢP, GIÁM SÁT THÔNG TIN DỰ ÁN ĐẦU TƯ</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td align="left" id="footer">
                <div class="menu_area" style="padding:5px 5px 5px 150px;"><b>Copyrights 2012 by VNPT</b></div>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
