<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhSachDuAn.aspx.cs" Inherits="IPS.Web.DanhSachDuAn" %>

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
                    <span class="css_tieude">Danh sách dự án</span>
                </h3>
            </td>
        </tr>
        <tr>
            <td align="left" class="C_out">
                <table cellpadding="0" cellspacing="1" width="100%" class="C_in">
                    <tr>
                        <td align="left">
                            <table cellpadding="0" cellspacing="1">
                                <tr>
                                    <td align="left" class="css_gchu">Mã dự án</td>
                                    <td align="left">
                                        <cc2:VdcTextBox ID="txtMaDuAn" runat="server" FolderStyle="btstyles/premiere_blue/VdcTextBox" Width="300px">
                                        </cc2:VdcTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="css_gchu">Loại dự án</td>
                                    <td align="left">
                                        <cc2:VdcDropDownList ID="ddlLoaiDuAn" runat="server" Width="300px">
                                        </cc2:VdcDropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="css_gchu">Nhóm dự án</td>
                                    <td align="left">
                                        <cc2:VdcDropDownList ID="ddlNhomDuAn" runat="server" Width="300px">
                                        </cc2:VdcDropDownList></td>
                                </tr>
                                <tr>
                                    <td align="left" class="css_gchu">Loại nguồn vốn</td>
                                    <td align="left">
                                        <cc2:VdcDropDownList ID="ddlLoaiNguonVon" runat="server" Width="300px">
                                        </cc2:VdcDropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="css_gchu">Phân cấp</td>
                                    <td align="left">
                                        <cc2:VdcDropDownList ID="ddlPhanCap" runat="server" Width="300px">
                                        </cc2:VdcDropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left">
                            <table>
                                <tr>
                                    <td align="left" class="css_gchu">Đơn vị quản lý ĐT</td>
                                    <td align="left">
                                        <cc2:VdcDropDownList ID="ddlDonViQuanLyDT" runat="server" Width="300px">
                                        </cc2:VdcDropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="css_gchu">Đơn vị chủ đầu tư</td>
                                    <td align="left">
                                        <cc2:VdcDropDownList ID="ddlDonViChuDT" runat="server" Width="300px">
                                        </cc2:VdcDropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="css_gchu">Tổng vốn đầu tư</td>
                                    <td align="left">
                                        <cc2:VdcDropDownList ID="ddlTTTongVonDT" runat="server" Width="100px">
                                        </cc2:VdcDropDownList>
                                        <cc2:VdcTextBox ID="txtTongVonDT" runat="server" Width="200px">
                                        </cc2:VdcTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="css_gchu">Thời gian phát sinh</td>
                                    <td align="left">
                                        <cc2:VdcDropDownList ID="ddlTTThoiGianPhatSinh" runat="server" Width="100px">
                                        </cc2:VdcDropDownList>
                                        <cc2:VdcDropDownList ID="ddlThoiGianPhatSinh" runat="server" Width="200px">
                                        </cc2:VdcDropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="css_gchu">Thời gian kết thúc</td>
                                    <td>
                                        <cc2:VdcDropDownList ID="ddlTTThoiGianKetThuc" runat="server" Width="100px">
                                        </cc2:VdcDropDownList>
                                        <cc2:VdcDropDownList ID="ddlThoiGianKetThuc" runat="server" Width="200px">
                                        </cc2:VdcDropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">&nbsp;</td>
                                    <td align="left">
                                        <cc2:VdcButton ID="btTimKiem" runat="server" Text="Tìm kiếm" OnClick="btTimKiem_Click" FolderStyle="btstyles/premiere_blue/VdcButton"></cc2:VdcButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left">
                <cc1:Grid ID="Grid1" runat="server"
                    CallbackMode="false"
                    Serialize="false"
                    AllowAddingRecords="False"
                    AllowPageSizeSelection="False"
                    AllowRecordSelection="False"
                    AllowSorting="False"
                    AutoGenerateColumns="false"
                    FolderStyle="styles/premiere_blue" Width="990px">
                    <AddEditDeleteSettings AddLinksPosition="Bottom" NewRecordPosition="Bottom"></AddEditDeleteSettings>
                    <ExportingSettings Encoding="Default" ExportedFilesTargetWindow="Current"></ExportingSettings>
                    <FilteringSettings FilterLinksPosition="Bottom" FilterPosition="Bottom" InitialState="Hidden" MatchingType="AllFilters"></FilteringSettings>
                    <MasterDetailSettings LoadingMode="OnCallback" State="Collapsed"></MasterDetailSettings>
                    <PagingSettings PageSizeSelectorPosition="Bottom" Position="Bottom" ShowRecordsCount="False"></PagingSettings>
                    <ScrollingSettings FixedColumnsPosition="Left" ScrollWidth="990px"></ScrollingSettings>
                    <Columns>
                        <cc1:Column DataField="MaDonVi" Visible="false" Width="" />
                        <cc1:Column DataField="IdDuAn" Visible="false" Width="" />
                        <cc1:Column DataField="TenDuAn" HeaderText="Tên dự án" Width="" />
                        <cc1:Column DataField="TenLoaiNguonVon" HeaderText="Loại nguồn vốn" Width="" />
                        <cc1:Column DataField="TenLoaiPhanCap" HeaderText="Phân cấp" Width="80px" />
                        <cc1:Column DataField="TenNhomDuAn" HeaderText="Nhóm" Width="80px" />
                        <cc1:Column DataField="NamBatDau" HeaderText="Ngày phát sinh" Width="90px" />
                        <cc1:Column DataField="NamKetThuc" HeaderText="Ngày kết thúc" Width="90px" />
                        <cc1:Column DataField="TongVonDauTu" HeaderText="Tổng vốn đầu tư" Width="" />
                        <cc1:Column HeaderText="Giám sát tình trạng">
                            <TemplateSettings TemplateId="GiamSatTinhTrang" />
                        </cc1:Column>
                    </Columns>
                    <Templates>
                        <cc1:GridTemplate runat="server" ID="GiamSatTinhTrang">
                            <Template>
                                <a href="ThongTinChiTietDuAn.aspx?madonvi=<%# Container.DataItem["MaDonVi"] %>&idduan=<%# Container.DataItem["IdDuAn"] %>">Thông tin chi tiết</a>
                            </Template>
                        </cc1:GridTemplate>
                    </Templates>
                </cc1:Grid>
            </td>
        </tr>
    </table>
</asp:Content>
