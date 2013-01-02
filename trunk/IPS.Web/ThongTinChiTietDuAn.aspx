<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ThongTinChiTietDuAn.aspx.cs" Inherits="IPS.Web.ThongTinChiTietDuAn" %>

<%@ Register Assembly="vdc_AJAXPage" Namespace="VdcInc" TagPrefix="vajax" %>

<%@ Register Assembly="vdc_Interface" Namespace="Vdc.Interface" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="JavaScript">
        function CapNhatLoaiNguonVon() {
            //var dropdown = $("select[id$='ddlLoaiNguonVon'] option:selected");
            //var text = dropdown.text();
            //var value = dropdown.val();
            var drop = ddlLoaiNguonVon;
            var text = ddlLoaiNguonVon._text;
            var value = ddlLoaiNguonVon._value;
            ob_post.AddParam('text', text);
            ob_post.AddParam('value', value);
            ob_post.post(null, "CapNhatLoaiNguonVon", ResultCapNhat);
        }
        function ResultCapNhat(result, ex) {
            alert(result);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <table>
                    <tr>
                        <td><b>Mã dự án</b></td>
                        <td><label runat="server" id="lbMaDuAn"></label></td>
                    </tr>
                    <tr>
                        <td><b>Loại dự án</b></td>
                        <td><label runat="server" id="lbLoaiDuAn"></label></td>
                    </tr>
                    <tr>
                        <td><b>Nhóm dự án</b></td>
                        <td><label runat="server" id="lbNhomDuAn"></label></td>
                    </tr>
                    <tr>
                        <td><b>Số quyết định</b></td>
                        <td><label runat="server" id="lbSoQuyetDinh"></label></td>
                    </tr>
                    <tr>
                        <td><b>Phân cấp</b></td>
                        <td><label runat="server" id="lbPhanCap"></label></td>
                    </tr>
                    <tr>
                        <td><b>Loại nguồn vốn</b></td>
                        <td>
                            <cc1:VdcDropDownList ID="ddlLoaiNguonVon" runat="server"></cc1:VdcDropDownList>
                            <%--<asp:DropDownList ID="ddlLoaiNguonVon" runat="server"></asp:DropDownList>--%>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table>
                    <tr>
                        <td><b>Đơn vị quản lý ĐT</b></td>
                        <td><label runat="server" id="lbDonViQuanLyDT"></label></td>
                    </tr>
                    <tr>
                        <td><b>Đơn vị chủ đầu tư</b></td>
                        <td><label runat="server" id="lbDonViChuDT"></label></td>
                    </tr>
                    <tr>
                        <td><b>Tổng vốn đầu tư</b></td>
                        <td><label runat="server" id="lbTongVonDT"></label></td>
                    <tr>
                        <td><b>Thời gian phát sinh</b></td>
                        <td><label runat="server" id="lbThoiGianPhatSinh"></label></td>
                    </tr>
                    <tr>
                        <td><b>Thời gian kết thúc</b></td>
                        <td><label runat="server" id="lbThoiGianKetThuc"></label></td>
                    </tr>
                    <tr>
                        <td><cc1:VdcButton ID="VdcButton1" runat="server" Text="Cập nhật" OnClientClick="CapNhatLoaiNguonVon(); return false;"></cc1:VdcButton></td>
                        <td></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
