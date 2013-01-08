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
                        <td><cc2:VdcTextBox ID="txtMaDuAn" runat="server" FolderStyle="btstyles/premiere_blue/VdcTextBox">
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
                        <td><cc2:VdcDropDownList ID="ddlDonViQuanLyDT" runat="server" Height="150">
                            </cc2:VdcDropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><b>Đơn vị chủ đầu tư</b></td>
                        <td><cc2:VdcDropDownList ID="ddlDonViChuDT" runat="server" Height="150">
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
                                        <%--<cc2:VdcTextBox ID="txtThoiGianPhatSinh" runat="server">
                                        </cc2:VdcTextBox>--%>
                                        <cc2:VdcDropDownList ID="ddlThoiGianPhatSinh" runat="server">
                                        </cc2:VdcDropDownList>
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
                                        <cc2:VdcDropDownList ID="ddlThoiGianKetThuc" runat="server">
                                        </cc2:VdcDropDownList>
                                    </td>
                                </tr>
                            </table></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <cc2:VdcButton ID="btTimKiem" runat="server" Text="Tìm kiếm" OnClick="btTimKiem_Click" FolderStyle="btstyles/premiere_blue/VdcButton"></cc2:VdcButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <cc1:Grid ID="Grid1" runat="server" 
                    CallbackMode="True" 
                    Serialize="True" 
                    AllowAddingRecords="False" 
                    AllowPageSizeSelection="False" 
                    AllowRecordSelection="False" 
                    AllowSorting="False" 
                    AutoGenerateColumns="false"
                    FolderStyle="styles/premiere_blue">
<AddEditDeleteSettings AddLinksPosition="Bottom" NewRecordPosition="Bottom"></AddEditDeleteSettings>
<ExportingSettings Encoding="Default" ExportedFilesTargetWindow="Current"></ExportingSettings>
<FilteringSettings FilterLinksPosition="Bottom" FilterPosition="Bottom" InitialState="Hidden" MatchingType="AllFilters"></FilteringSettings>
<MasterDetailSettings LoadingMode="OnCallback" State="Collapsed"></MasterDetailSettings>
<PagingSettings PageSizeSelectorPosition="Bottom" Position="Bottom" ShowRecordsCount="False"></PagingSettings>
<ScrollingSettings FixedColumnsPosition="Left"></ScrollingSettings>
                    <Columns>
                        <cc1:Column DataField="MaDonVi" Visible="false" />
                        <cc1:Column DataField="IdDuAn" Visible="false" />
                        <cc1:Column DataField="TenDuAn" HeaderText="Tên dự án" />
                        <cc1:Column DataField="LoaiNguonVonValue" HeaderText="Loại nguồn vốn" />
                        <cc1:Column DataField="LoaiPhanCap" HeaderText="Phân cấp" />
                        <cc1:Column DataField="NhomDuAn" HeaderText="Nhóm" />
                        <cc1:Column DataField="NamBatDau" HeaderText="Ngày phát sinh" />
                        <cc1:Column DataField="NamKetThuc" HeaderText="Ngày kết thúc" />
                        <cc1:Column DataField="TongVonDauTu" HeaderText="Tổng vốn đầu tư" />
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
