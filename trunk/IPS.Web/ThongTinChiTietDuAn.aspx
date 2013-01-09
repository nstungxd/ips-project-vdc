<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ThongTinChiTietDuAn.aspx.cs" Inherits="IPS.Web.ThongTinChiTietDuAn" %>

<%@ Register Assembly="vdc_Grid_NET" Namespace="Vdc.Grid" TagPrefix="cc1" %>

<%@ Register Assembly="vdc_AJAXPage" Namespace="VdcInc" TagPrefix="vajax" %>

<%@ Register Assembly="vdc_Interface" Namespace="Vdc.Interface" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="JavaScript">
        function CapNhatLoaiNguonVon() {
            var value = $("input[id$='ddlLoaiNguonVon']").val();
            var hfMadv = $("input[id$='hfMaDonVi']").val();
            var hfSoIdDv = $("input[id$='hfSoIdDonVi']").val();
            ob_post.AddParam('ma_don_vi', hfMadv);
            ob_post.AddParam('so_id_don_vi', hfSoIdDv);
            ob_post.AddParam('trang_thai', value);
            ob_post.post(null, "CapNhatLoaiNguonVon", ResultCapNhat);
        }
        function ResultCapNhat(result, ex) {
            alert(result);
        }


        function MyFunction(a, b) {
            ob_post.AddParam('MaDonVi', a);
            ob_post.AddParam('SoIdGoiThau', b);
            ob_post.post(null, "AddDonVi", EndLoadHopDong);

        }
        function EndLoadHopDong() {
        }
        function ddlNamKeHoachOnChange(sender, index) {
            ob_post.AddParam('Nam', sender.options[index].text);
            ob_post.post(null, "AddKeHoachVon", EndLoadKHV);
        }
        function EndLoadKHV() {
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
                            <cc2:VdcDropDownList ID="ddlLoaiNguonVon" runat="server"></cc2:VdcDropDownList>
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
                        <td><cc2:VdcButton ID="VdcButton1" runat="server" Text="Cập nhật" OnClientClick="CapNhatLoaiNguonVon(); return false;"></cc2:VdcButton></td>
                        <td>
                            <asp:HiddenField ID="hfMaDonVi" runat="server"/>
                            <asp:HiddenField ID="hfSoIdDonVi" runat="server"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <br />
    <br />
    <br />
    <br />
    <br />
    <cc2:VdcDropDownList runat="server" ID="ddlNamKeHoach">
        <ClientSideEvents OnSelectedIndexChanged="ddlNamKeHoachOnChange" />
    </cc2:VdcDropDownList>
    <cc2:VdcButton ID="btCapNhatKHV" runat="server" Text="Cập nhật"></cc2:VdcButton>
    <br />
    <br />
    <vajax:CallbackPanel ID="CallbackPanel2" runat="server">
        <Content>
    <cc1:Grid ID="gridNamKeHoach" runat="server" CallbackMode="true" Serialize="false"
        AllowAddingRecords="False"
        AllowPageSizeSelection="False"
        AllowRecordSelection="False"
        AllowSorting="False"
        AutoGenerateColumns="false"
        FolderStyle="styles/premiere_blue" PageSize="-1" ShowFooter="false">
        <AddEditDeleteSettings AddLinksPosition="Bottom" NewRecordPosition="Bottom"></AddEditDeleteSettings>
        <ExportingSettings Encoding="Default" ExportedFilesTargetWindow="Current"></ExportingSettings>
        <FilteringSettings FilterLinksPosition="Bottom" FilterPosition="Bottom" InitialState="Hidden" MatchingType="AllFilters"></FilteringSettings>
        <MasterDetailSettings LoadingMode="OnCallback" State="Collapsed"></MasterDetailSettings>
        <PagingSettings PageSizeSelectorPosition="Bottom" Position="Bottom" ShowRecordsCount="False"></PagingSettings>
        <ScrollingSettings FixedColumnsPosition="Left"></ScrollingSettings>
        <Columns>
            <cc1:Column DataField="TenGiaiDoan" HeaderText="Tiến trình"></cc1:Column>
            <cc1:Column DataField="TrangThaiThucHien" HeaderText="Trạng thái thực hiện"></cc1:Column>
            <cc1:Column DataField="TenKetQuaGiamSat" HeaderText="Trạng thái giám sát"></cc1:Column>
            <cc1:Column DataField="GhiChuGiamSat" HeaderText="Ghi chú"></cc1:Column>
        </Columns>
    </cc1:Grid>
            </Content>
        </vajax:CallbackPanel>
    <br />
    <br />
    <br />
    <br />
    <cc2:VdcButton ID="btCapNhatNhaThau" runat="server" Text="Cập nhật"></cc2:VdcButton>
    <br />
    <br />
    <cc1:Grid ID="gridNhaThau" runat="server" CallbackMode="true" Serialize="false"
        AllowAddingRecords="False"
        AllowPageSizeSelection="False"
        AllowRecordSelection="false"
        AllowSorting="False"
        AutoGenerateColumns="false"
        FolderStyle="styles/premiere_blue" PageSize="7" AllowMultiRecordSelection="False">
        <AddEditDeleteSettings AddLinksPosition="Bottom" NewRecordPosition="Bottom"></AddEditDeleteSettings>
        <ExportingSettings Encoding="Default" ExportedFilesTargetWindow="Current"></ExportingSettings>
        <FilteringSettings FilterLinksPosition="Bottom" FilterPosition="Bottom" InitialState="Hidden" MatchingType="AllFilters"></FilteringSettings>
        <MasterDetailSettings LoadingMode="OnCallback" State="Collapsed"></MasterDetailSettings>
        <PagingSettings PageSizeSelectorPosition="Bottom" Position="Bottom" ShowRecordsCount="False"></PagingSettings>
        <ScrollingSettings FixedColumnsPosition="Left"></ScrollingSettings>
        <Columns>
            <cc1:Column DataField="MaDonVi" Visible="false"></cc1:Column>
            <cc1:Column DataField="IdGoiThau" Visible="false"></cc1:Column>
            <cc1:Column DataField="TenGoiThau" HeaderText="Gói thầu">
                <TemplateSettings TemplateId="LinkTenGoiThau"/>
            </cc1:Column>
            <cc1:Column DataField="HinhThucDauThau" HeaderText="Hình thức đấu thầu"></cc1:Column>
            <cc1:Column DataField="TenGiaiDoan" HeaderText="Tiến trình"></cc1:Column>
            <cc1:Column DataField="TrangThaiThucHien" HeaderText="Trạng thái thực hiện"></cc1:Column>
            <cc1:Column DataField="TenKetQuaGiamSat" HeaderText="Trạng thái giám sát"></cc1:Column>
            <cc1:Column DataField="GhiChuGiamSat" HeaderText="Ghi chú"></cc1:Column>
        </Columns>
        <Templates>
                        <cc1:GridTemplate runat="server" ID="LinkTenGoiThau">
                            <Template>
                                <a id="myLink" href="#" onclick="MyFunction('<%# Container.DataItem["MaDonVi"] %>','<%# Container.DataItem["IdGoiThau"] %>');return false;"><%# Container.DataItem["TenGoiThau"] %></a>
                            </Template>
                        </cc1:GridTemplate>
                    </Templates>
    </cc1:Grid>
    <br />
    <br />
    <br />
    <cc2:VdcButton ID="btCapNhatHopDong" runat="server" Text="Cập nhật"></cc2:VdcButton>
    <br />
    <br />
    <vajax:CallbackPanel ID="CallbackPanel1" runat="server">
        <Content>
    <cc1:Grid ID="gridHopDong" runat="server" CallbackMode="true" Serialize="false"
        AllowAddingRecords="False"
        AllowPageSizeSelection="False"
        AllowRecordSelection="False"
        AllowSorting="False"
        AutoGenerateColumns="false"
        FolderStyle="styles/premiere_blue" PageSize="7">
        <AddEditDeleteSettings AddLinksPosition="Bottom" NewRecordPosition="Bottom"></AddEditDeleteSettings>
        <ExportingSettings Encoding="Default" ExportedFilesTargetWindow="Current"></ExportingSettings>
        <FilteringSettings FilterLinksPosition="Bottom" FilterPosition="Bottom" InitialState="Hidden" MatchingType="AllFilters"></FilteringSettings>
        <MasterDetailSettings LoadingMode="OnCallback" State="Collapsed"></MasterDetailSettings>
        <PagingSettings PageSizeSelectorPosition="Bottom" Position="Bottom" ShowRecordsCount="False"></PagingSettings>
        <ScrollingSettings FixedColumnsPosition="Left"></ScrollingSettings>
        <Columns>
            <cc1:Column DataField="TenHopDong" HeaderText="Tên hợp đồng"></cc1:Column>
            <cc1:Column DataField="BenA" HeaderText="Bên A"></cc1:Column>
            <cc1:Column DataField="BenB" HeaderText="Bên B"></cc1:Column>
            <cc1:Column DataField="TienNoiTe" HeaderText="Tiền nội tệ"></cc1:Column>
            <cc1:Column DataField="TienNgoaiTe" HeaderText="Tiền ngoại tệ"></cc1:Column>
            <cc1:Column DataField="TinhTrangHopDong" HeaderText="Trạng thái thực hiện"></cc1:Column>
            <cc1:Column DataField="TenKetQuaGiamSat" HeaderText="Trạng thái giám sát"></cc1:Column>
            <cc1:Column DataField="GhiChuGiamSat" HeaderText="Ghi chú"></cc1:Column>
        </Columns>
    </cc1:Grid>
            </Content>
     </vajax:CallbackPanel>
</asp:Content>
