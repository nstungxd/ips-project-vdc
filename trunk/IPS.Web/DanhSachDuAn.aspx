<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhSachDuAn.aspx.cs" Inherits="IPS.Web.DanhSachDuAn" %>

<%@ Register Assembly="vdc_Interface" Namespace="Vdc.Interface" TagPrefix="cc2" %>

<%@ Register Assembly="vdc_Grid_NET" Namespace="Vdc.Grid" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <table>
                    <tr>
                        <td><b>Mã dự án</b></td>
                        <td><cc2:VdcTextBox ID="txtMaDuAn" runat="server">
                            </cc2:VdcTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><b>Loại dự án</b></td>
                        <td>
                            <cc2:VdcDropDownList ID="ddlLoaiDuAn" runat="server">
                            </cc2:VdcDropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><b>Nhóm dự án</b></td>
                        <td><cc2:VdcDropDownList ID="ddlNhomDuAn" runat="server">
                            </cc2:VdcDropDownList></td>
                    </tr>
                    <tr>
                        <td><b>Loại nguồn vốn</b></td>
                        <td><cc2:VdcDropDownList ID="ddlLoaiNguonVon" runat="server">
                            </cc2:VdcDropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><b>Phân cấp</b></td>
                        <td><cc2:VdcDropDownList ID="ddlPhanCap" runat="server">
                            </cc2:VdcDropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
            </td>
            <td>
                <table>
                    <tr>
                        <td><b>Đơn vị quản lý ĐT</b></td>
                        <td><cc2:VdcDropDownList ID="ddlDonViQuanLyDT" runat="server">
                            </cc2:VdcDropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><b>Đơn vị chủ đầu tư</b></td>
                        <td><cc2:VdcDropDownList ID="ddlDonViChuDT" runat="server">
                            </cc2:VdcDropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><b>Tổng vốn đầu tư</b></td>
                        <td>
                            <table>
                                <tr>
                                    <td><cc2:VdcDropDownList ID="ddlTTTongVonDT" runat="server">
                                        </cc2:VdcDropDownList>
                                    </td>
                                    <td>
                                        <cc2:VdcTextBox ID="txtTongVonDT" runat="server">
                                        </cc2:VdcTextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td><b>Thời gian phát sinh</b></td>
                        <td>
                            <table>
                                <tr>
                                    <td><cc2:VdcDropDownList ID="ddlTTThoiGianPhatSinh" runat="server">
                                        </cc2:VdcDropDownList>
                                    </td>
                                    <td>
                                        <cc2:VdcTextBox ID="txtThoiGianPhatSinh" runat="server">
                                        </cc2:VdcTextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td><b>Thời gian kết thúc</b></td>
                        <td><table>
                                <tr>
                                    <td><cc2:VdcDropDownList ID="ddlTTThoiGianKetThuc" runat="server">
                                        </cc2:VdcDropDownList>
                                    </td>
                                    <td>
                                        <cc2:VdcTextBox ID="txtThoiGianKetThuc" runat="server">
                                        </cc2:VdcTextBox>
                                    </td>
                                </tr>
                            </table></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <cc2:VdcButton ID="btTimKiem" runat="server" Text="Tìm kiếm"></cc2:VdcButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <cc1:Grid ID="Grid1" runat="server"></cc1:Grid>
            </td>
        </tr>
    </table>
</asp:Content>
