<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ht_quanlynhomnguoidung.aspx.cs" Inherits="IPS.Web.Appforms.he_thong.ht_quanlynhomnguoidung" %>

<%@ Register Assembly="vdc_Interface" Namespace="Vdc.Interface" TagPrefix="cc2" %>
<%@ Register Assembly="vdc_Grid_NET" Namespace="Vdc.Grid" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="2" width="100%" class="data_tbl">
        <tr>
            <td valign="top" align="left" style="padding-top: 3px;">
                <h3 class="tbl_title">
                    <img align="absmiddle" height="21px" width="20px" src="../../images/vnpt_ico.png"
                        class="png" style="padding-top: 3px; padding-left: 4px;">
                    <span class="css_tieude">Quản lý nhóm người dùng</span>
                </h3>
            </td>
        </tr>
        <tr>
            <td align="left">
                <table cellpadding="0" cellspacing="1" width="100%">
                    <tr>
                        <td align="left" width="65%" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="1">
                                <tr>
                                    <td align="left" class="C_out">
                                        <table class="C_in" cellpadding="0" cellspacing="1" width="100%">
                                            <tr>
                                                <td align="left" class="css_gchu">Mã nhóm</td>
                                                <td align="left">
                                                    <cc2:VdcTextBox ID="txtMaNhom" runat="server" FolderStyle="btstyles/premiere_blue/VdcTextBox" Width="300px">
                                                    </cc2:VdcTextBox></td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="css_gchu">Tên nhóm</td>
                                                <td align="left">
                                                    <cc2:VdcTextBox ID="txtTenNhom" runat="server" FolderStyle="btstyles/premiere_blue/VdcTextBox" Width="300px">
                                                    </cc2:VdcTextBox></td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="css_gchu">Module</td>
                                                <td align="left">
                                                    <cc2:VdcDropDownList ID="ddlModule" runat="server" Width="300px">
                                                    </cc2:VdcDropDownList></td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="css_gchu">Mức độ truy cập</td>
                                                <td align="left">
                                                    <cc2:VdcDropDownList ID="dllMucDoTruyCap" runat="server" Width="300px">
                                                    </cc2:VdcDropDownList></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <cc1:Grid ID="GRLKe1" runat="server"
                                            CallbackMode="false"
                                            Serialize="false"
                                            AllowAddingRecords="False"
                                            AllowPageSizeSelection="False"
                                            AllowRecordSelection="False"
                                            AllowSorting="False"
                                            AutoGenerateColumns="false"
                                            FolderStyle="../../styles/premiere_blue">
                                            <AddEditDeleteSettings AddLinksPosition="Bottom" NewRecordPosition="Bottom"></AddEditDeleteSettings>
                                            <ExportingSettings Encoding="Default" ExportedFilesTargetWindow="Current"></ExportingSettings>
                                            <FilteringSettings FilterLinksPosition="Bottom" FilterPosition="Bottom" InitialState="Hidden" MatchingType="AllFilters"></FilteringSettings>
                                            <MasterDetailSettings LoadingMode="OnCallback" State="Collapsed"></MasterDetailSettings>
                                            <PagingSettings PageSizeSelectorPosition="Bottom" Position="Bottom" ShowRecordsCount="False"></PagingSettings>
                                            <ScrollingSettings FixedColumnsPosition="Left" ScrollWidth=""></ScrollingSettings>
                                            <Columns>

                                                <cc1:Column DataField="TenDuAn" HeaderText="Nghiệp vụ" Width="200px" />
                                                <cc1:Column DataField="LoaiNguonVonValue" HeaderText="Nhập SL" Width="90px" />
                                                <cc1:Column DataField="LoaiPhanCap" HeaderText="Xem SL" Width="90px" />
                                                <cc1:Column DataField="NhomDuAn" HeaderText="Q. Lý" Width="90px" />
                                            </Columns>
                                        </cc1:Grid>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table cellspacing="1" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <cc2:VdcButton ID="VdcButton1" runat="server" Text="Lưu" FolderStyle="btstyles/premiere_blue/VdcButton"></cc2:VdcButton></td>
                                                <td>
                                                    <cc2:VdcButton ID="VdcButton2" runat="server" Text="Xóa" FolderStyle="btstyles/premiere_blue/VdcButton"></cc2:VdcButton></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" width="35%" valign="top">
                            <cc1:Grid ID="Grid1" runat="server"
                                CallbackMode="false"
                                Serialize="false"
                                AllowAddingRecords="False"
                                AllowPageSizeSelection="False"
                                AllowRecordSelection="False"
                                AllowSorting="False"
                                AutoGenerateColumns="false"
                                FolderStyle="../../styles/premiere_blue" Width="">
                                <AddEditDeleteSettings AddLinksPosition="Bottom" NewRecordPosition="Bottom"></AddEditDeleteSettings>
                                <ExportingSettings Encoding="Default" ExportedFilesTargetWindow="Current"></ExportingSettings>
                                <FilteringSettings FilterLinksPosition="Bottom" FilterPosition="Bottom" InitialState="Hidden" MatchingType="AllFilters"></FilteringSettings>
                                <MasterDetailSettings LoadingMode="OnCallback" State="Collapsed"></MasterDetailSettings>
                                <PagingSettings PageSizeSelectorPosition="Bottom" Position="Bottom" ShowRecordsCount="False"></PagingSettings>
                                <ScrollingSettings FixedColumnsPosition="Left" ScrollWidth=""></ScrollingSettings>
                                <Columns>
                                    <cc1:Column DataField="MaDonVi" Visible="false" Width="" />
                                    <cc1:Column DataField="IdDuAn" Visible="false" Width="" />
                                    <cc1:Column DataField="TenDuAn" HeaderText="Nhóm" Width="100px" />
                                    <cc1:Column DataField="LoaiNguonVonValue" HeaderText="Tên" Width="200px" />
                                </Columns>

                            </cc1:Grid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
