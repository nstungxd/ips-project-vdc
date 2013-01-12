<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GiamSat1.aspx.cs" Inherits="IPS.Web.GiamSat1" %>

<%@ Register Assembly="vdc_AJAXPage" Namespace="VdcInc" TagPrefix="vajax" %>

<%@ Register Assembly="vdc_ComboBox" Namespace="Vdc.ComboBox" TagPrefix="cc3" %>

<%@ Register Assembly="vdc_Interface" Namespace="Vdc.Interface" TagPrefix="cc2" %>

<%@ Register Assembly="vdc_Grid_NET" Namespace="Vdc.Grid" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        window.onload = function () {
            gridNamKeHoach.convertToExcel(
                    ['ReadOnly', 'ReadOnly', 'DropDownList', 'MultiLineTextBox', 'ReadOnly', 'ReadOnly', 'ReadOnly', 'ReadOnly'],
                    '<%=gridNamKeHoachExcelData.ClientID %>',
                '<%=gridNamKeHoachExcelDeletedIds.ClientID %>'
                );
            gridHopDong.convertToExcel(
                    ['ReadOnly', 'ReadOnly', 'ReadOnly', 'ReadOnly', 'ReadOnly', 'ReadOnly', 'DropDownList', 'MultiLineTextBox', 'ReadOnly'],
                    '<%=gridHopDongExcelData.ClientID %>',
                '<%=gridHopDongExcelDeletedIds.ClientID %>'
                );
            gridNhaThau.convertToExcel(
                ['ReadOnly', 'ReadOnly', 'ReadOnly', 'ReadOnly', 'ReadOnly', 'ReadOnly', 'DropDownList', 'MultiLineTextBox', 'ReadOnly'],
                '<%=gridNhaThauExcelData.ClientID %>',
                '<%=gridNhaThauExcelDeletedIds.ClientID %>'
                );
        }
        function saveGridKHV() {
            gridNamKeHoach.saveExcelChanges('<%=gridNamKeHoachExcelData.ClientID %>');
        }
        function saveGridHopDong() {
            gridHopDong.saveExcelChanges('<%=gridHopDongExcelData.ClientID %>');
        }
        function saveGridNhaThau() {
            gridNhaThau.saveExcelNhaThauChanges('<%=gridNhaThauExcelData.ClientID %>');
        }
        //function ddlNamKeHoachOnChange(sender, index) {
        //    ob_post.AddParam('Nam', sender.options[index].text);
        //    ob_post.post(null, "AddKeHoachVon", EndLoadKHV);
        //}
        function ddlNamKeHoachOnChange(ddlId) {
            var ControlName = document.getElementById(ddlId.id);
            ob_post.AddParam('Nam', ControlName.value);
            ob_post.post(null, "AddKeHoachVon", EndLoadKHV);
        }

        function EndLoadKHV() {
            gridNamKeHoach.convertToExcel(
                ['ReadOnly', 'ReadOnly', 'DropDownList', 'MultiLineTextBox', 'ReadOnly', 'ReadOnly', 'ReadOnly', 'ReadOnly'],
                '<%=gridNamKeHoachExcelData.ClientID %>',
                '<%=gridNamKeHoachExcelDeletedIds.ClientID %>'
                );
        }
        function CapNhatGridKHV() {
            var gr = $("input[id$='gridNamKeHoachExcelData']").val();
            var valueNam = $("select[id$='ddlNamKeHoach'] option:selected").val();
            ob_post.AddParam('stringGridKHV', gr);
            ob_post.AddParam('Nam', valueNam);
            ob_post.post(null, "CapNhatKeHoachVon", ResultCapNhatKHV);
        }
        function CapNhatGridHopDong() {
            var gr = $("input[id$='gridHopDongExcelData']").val();
            ob_post.AddParam('stringGridHopDong', gr);
            ob_post.post(null, "CapNhatHopDong", ResultCapNhatHopDong);
        }
        function CapNhatGridNhaThau() {
            var gr = $("input[id$='gridNhaThauExcelData']").val();
            ob_post.AddParam('stringGridNhaThau', gr);
            ob_post.post(null, "CapNhatNhaThau", ResultCapNhatNhaThau);
        }
        function ResultCapNhatKHV(result, ex) {
            //ob_post.UpdatePanel("CallbackPanel2");
            alert(result);
        }
        function ResultCapNhatHopDong(result, ex) {
            alert(result);
        }
        function ResultCapNhatNhaThau(result, ex) {
            alert(result);
        }
        function ComboBox_Open(sender) {
            focusedGrid._keyNavigationIsEnabled = false;
        }
        function navigateThroughCells(sender, key, forced) {
            if (forced && focusedGrid != null) {
                focusedGrid._keyNavigationIsEnabled = true;
            }

            if (focusedGrid._keyNavigationIsEnabled || forced) {
                var currentCell = focusedGrid._lastEditedField.parentNode.parentNode.parentNode;
                var currentCellIndex = 0;
                var tempCell = currentCell.previousSibling;
                while (tempCell) {
                    currentCellIndex++;
                    tempCell = tempCell.previousSibling;
                }
                var newCell = null;
                switch (key) {
                    case 37:
                        if (currentCell.previousSibling) {
                            newCell = currentCell.previousSibling;
                        }
                        break;
                    case 38:
                        if (currentCell.parentNode.previousSibling) {
                            newCell = currentCell.parentNode.previousSibling.childNodes[currentCellIndex];
                        }
                        break;
                    case 39:
                        if (currentCell.nextSibling) {
                            newCell = currentCell.nextSibling;
                        }
                        break;
                    case 40:
                        if (currentCell.parentNode.nextSibling) {
                            newCell = currentCell.parentNode.nextSibling.childNodes[currentCellIndex];
                        }
                        break;
                    default:
                        focusedGrid._keyNavigationIsEnabled = false;
                        if (key == 13 || key == 27 || key == 113) {
                            if (focusedGrid._lastEditedFieldEditor.type == 'text' || focusedGrid._lastEditedFieldEditor.type == 'textarea') {
                                var previousValue = focusedGrid._lastEditedFieldEditor.value;
                                focusedGrid._lastEditedFieldEditor.value = '';
                                focusedGrid._lastEditedFieldEditor.value = previousValue;
                            }
                        }
                        break;
                }

                if (newCell) {
                    var textboxes = newCell.firstChild.firstChild.getElementsByTagName('INPUT');
                    if (textboxes.length) {
                        textboxes[0].focus();
                    }
                }
            } else {
                if (key == 13 || key == 27) {
                    focusedGrid._keyNavigationIsEnabled = true;
                    focusedGrid.selectLastFieldEditor();

                    if (key == 13) {
                        if (focusedGrid._lastEditedFieldEditor.type == 'text' || focusedGrid._lastEditedFieldEditor.type == 'textarea') {
                            focusedGrid._lastEditedFieldEditorValue = focusedGrid._lastEditedFieldEditor.value;
                        } else {
                            focusedGrid._lastEditedFieldEditorValue = focusedGrid._lastEditedFieldEditor.checked();
                        }
                    } else if (focusedGrid != null && focusedGrid._lastEditedFieldEditorValue != null) {
                        window.setTimeout(function () { focusedGrid.restoreEditorValue(); }, 10);
                    }
                }
            }

            if (key == 13 || key == 27) {
                return false;
            }

            return true;
        }
        function persistFieldValue(field) {
            if (focusedGrid != null && focusedGrid._lastEditedField != null) {
                if (focusedGrid._lastEditedFieldEditor.type == 'text' || focusedGrid._lastEditedFieldEditor.type == 'textarea') {
                    focusedGrid._lastEditedField.value = focusedGrid._lastEditedFieldEditor.value;
                } else {
                    focusedGrid._lastEditedField.value = focusedGrid._lastEditedFieldEditor.checked ? 'yes' : 'no';

                }
                var a = document.getElementById(focusedGrid._editorid + 'Container');
                var b = document.getElementById('FieldEditorsContainer');
                b.appendChild(a);
                focusedGrid._lastEditedField.style.display = '';

                focusedGrid._lastEditedField = null;
                focusedGrid._lastEditedFieldEditor = null;
            }
        }
        function CapNhatLoaiNguonVon() {
            var value = $("select[id$='ddlLoaiNguonVon'] option:selected").val();
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Content/CSS/excel-style.css" type="text/css" rel="Stylesheet" />
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
                            <asp:DropDownList ID="ddlLoaiNguonVon" runat="server"></asp:DropDownList>
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

    <%--<cc2:VdcDropDownList runat="server" ID="ddlNamKeHoach">
        <ClientSideEvents OnSelectedIndexChanged="ddlNamKeHoachOnChange" />
    </cc2:VdcDropDownList>--%>
    <asp:DropDownList runat="server" ID="ddlNamKeHoach" onchange="ddlNamKeHoachOnChange(this);"></asp:DropDownList>
    <cc2:VdcButton ID="btCapNhatKHV" runat="server" OnClientClick="saveGridKHV();CapNhatGridKHV(); return false;" Text="Cập nhật"></cc2:VdcButton>
    <asp:HiddenField runat="server" ID="gridNamKeHoachExcelDeletedIds" />
    <asp:HiddenField runat="server" ID="gridNamKeHoachExcelData" />

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

                    <cc1:Column DataField="TenGiaiDoan" HeaderText="Tiến trình">
                        <TemplateSettings TemplateId="ReadOnlyTemplateGrid1" />
                    </cc1:Column>
                    <cc1:Column DataField="TrangThaiThucHien" HeaderText="Trạng thái thực hiện">
                        <TemplateSettings TemplateId="ReadOnlyTemplateGrid1" />
                    </cc1:Column>
                    <cc1:Column DataField="TenKetQuaGiamSat" HeaderText="Trạng thái giám sát">
                        <TemplateSettings TemplateId="ComboBoxEditTemplateGrid1" />
                    </cc1:Column>
                    <cc1:Column DataField="GhiChuGiamSat" HeaderText="Ghi chú">
                        <TemplateSettings TemplateId="MultiLineTextBoxEditTemplateGrid1" />
                    </cc1:Column>
                    <cc1:Column DataField="IdGiamSat" HeaderText="IdGiamSat" Visible="false">
                        <TemplateSettings TemplateId="ReadOnlyTemplateGrid1" />
                    </cc1:Column>
                    <cc1:Column DataField="Dot" HeaderText="Dot" Visible="false">
                        <TemplateSettings TemplateId="ReadOnlyTemplateGrid1" />
                    </cc1:Column>
                    <cc1:Column DataField="SoQuyetDinh" HeaderText="SoQuyetDinh" Visible="false">
                        <TemplateSettings TemplateId="ReadOnlyTemplateGrid1" />
                    </cc1:Column>
                    <cc1:Column DataField="GiaiDoanKHV" HeaderText="GiaiDoanKHV" Visible="false">
                        <TemplateSettings TemplateId="ReadOnlyTemplateGrid1" />
                    </cc1:Column>
                </Columns>
                <Templates>
                    <cc1:GridTemplate runat="server" ID="ReadOnlyTemplateGrid1">
                        <Template>
                            <input type="text" name="TextBox1" class="excel-textbox" value='<%# Container.Value %>' readonly="readonly" />
                        </Template>
                    </cc1:GridTemplate>
                    <cc1:GridTemplate runat="server" ID="MultiLineTextBoxEditTemplateGrid1">
                        <Template>
                            <input type="text" name="TextBox1" class="excel-textbox" value='<%# Container.Value %>' readonly="readonly"
                                onfocus="gridNamKeHoach.editWithMultiLineTextBox(this)" />
                        </Template>
                    </cc1:GridTemplate>
                    <cc1:GridTemplate runat="server" ID="ComboBoxEditTemplateGrid1">
                        <Template>
                            <input type="text" name="TextBox1" class="excel-textbox" value='<%# Container.Value %>' readonly="readonly"
                                onfocus="gridNamKeHoach.editWithComboBox(this,'ComboBoxEditor')" />
                        </Template>
                    </cc1:GridTemplate>
                </Templates>
            </cc1:Grid>
        </Content>
    </vajax:CallbackPanel>
    <br />
    <br />
    <br />
    <br />
    <cc2:VdcButton ID="btCapNhatNhaThau" runat="server" OnClientClick="saveGridNhaThau();CapNhatGridNhaThau(); return false;" Text="Cập nhật"></cc2:VdcButton>
    <asp:HiddenField runat="server" ID="gridNhaThauExcelDeletedIds" />
    <asp:HiddenField runat="server" ID="gridNhaThauExcelData" />
    <cc1:Grid ID="gridNhaThau" runat="server" CallbackMode="true" Serialize="true"
        AllowAddingRecords="False"
        AllowPageSizeSelection="False"
        AllowRecordSelection="false"
        AllowSorting="False"
        AutoGenerateColumns="false"
        FolderStyle="styles/premiere_blue" PageSize="3" AllowMultiRecordSelection="False">
        <AddEditDeleteSettings AddLinksPosition="Bottom" NewRecordPosition="Bottom"></AddEditDeleteSettings>
        <ExportingSettings Encoding="Default" ExportedFilesTargetWindow="Current"></ExportingSettings>
        <FilteringSettings FilterLinksPosition="Bottom" FilterPosition="Bottom" InitialState="Hidden" MatchingType="AllFilters"></FilteringSettings>
        <MasterDetailSettings LoadingMode="OnCallback" State="Collapsed"></MasterDetailSettings>
        <PagingSettings PageSizeSelectorPosition="Bottom" Position="Bottom" ShowRecordsCount="False"></PagingSettings>
        <ScrollingSettings FixedColumnsPosition="Left"></ScrollingSettings>
        <Columns>
            <cc1:Column DataField="MaDonVi" Visible="false">
                <TemplateSettings TemplateId="ReadOnlyTemplateGrid2" />
            </cc1:Column>
            <cc1:Column DataField="IdGoiThau" Visible="false">
                <TemplateSettings TemplateId="ReadOnlyTemplateGrid2" />
            </cc1:Column>
            <cc1:Column DataField="TenGoiThau" HeaderText="Gói thầu">
                <TemplateSettings TemplateId="LinkTenGoiThau" />
            </cc1:Column>
            <cc1:Column DataField="HinhThucDauThau" HeaderText="Hình thức đấu thầu">
                <TemplateSettings TemplateId="ReadOnlyTemplateGrid2" />
            </cc1:Column>
            <cc1:Column DataField="TenGiaiDoan" HeaderText="Tiến trình">
                <TemplateSettings TemplateId="ReadOnlyTemplateGrid2" />
            </cc1:Column>
            <cc1:Column DataField="TrangThaiThucHien" HeaderText="Trạng thái thực hiện">
                <TemplateSettings TemplateId="ReadOnlyTemplateGrid2" />
            </cc1:Column>
            <cc1:Column DataField="TenKetQuaGiamSat" HeaderText="Trạng thái giám sát">
                <TemplateSettings TemplateId="ComboBoxEditTemplateGrid2" />
            </cc1:Column>
            <cc1:Column DataField="GhiChuGiamSat" HeaderText="Ghi chú">
                <TemplateSettings TemplateId="MultiLineTextBoxEditTemplateGrid2" />
            </cc1:Column>
            <cc1:Column DataField="IdGiamSat" HeaderText="IdGiamSat" Visible="false">
                <TemplateSettings TemplateId="ReadOnlyTemplateGrid2" />
            </cc1:Column>
        </Columns>
        <Templates>
            <cc1:GridTemplate runat="server" ID="LinkTenGoiThau">
                <Template>
                    <a id="myLink" href="#" onclick="MyFunction('<%# Container.DataItem["MaDonVi"] %>','<%# Container.DataItem["IdGoiThau"] %>');return false;"><%# Container.DataItem["TenGoiThau"] %></a>
                </Template>
            </cc1:GridTemplate>
            <cc1:GridTemplate runat="server" ID="ReadOnlyTemplateGrid2">
                <Template>
                    <input type="text" name="TextBox1" class="excel-textbox" value='<%# Container.Value %>' readonly="readonly" />
                </Template>
            </cc1:GridTemplate>
            <cc1:GridTemplate runat="server" ID="MultiLineTextBoxEditTemplateGrid2">
                <Template>
                    <input type="text" name="TextBox1" class="excel-textbox" value='<%# Container.Value %>' readonly="readonly"
                        onfocus="gridNhaThau.editWithMultiLineTextBox(this)" />
                </Template>
            </cc1:GridTemplate>
            <cc1:GridTemplate runat="server" ID="ComboBoxEditTemplateGrid2">
                <Template>
                    <input type="text" name="TextBox1" class="excel-textbox" value='<%# Container.Value %>' readonly="readonly"
                        onfocus="gridNhaThau.editWithComboBox(this,'ComboBoxEditor')" />
                </Template>
            </cc1:GridTemplate>
        </Templates>
    </cc1:Grid>

    <br />
    <br />
    <br />
    <br />
    <cc2:VdcButton ID="btCapNhatHopDong" runat="server" OnClientClick="saveGridHopDong();CapNhatGridHopDong(); return false;" Text="Cập nhật"></cc2:VdcButton>
    <asp:HiddenField runat="server" ID="gridHopDongExcelDeletedIds" />
    <asp:HiddenField runat="server" ID="gridHopDongExcelData" />
    <vajax:CallbackPanel ID="CallbackPanel1" runat="server">
        <Content>
    <cc1:Grid ID="gridHopDong" runat="server" CallbackMode="true" Serialize="false"
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
            <cc1:Column DataField="TenHopDong" HeaderText="Tên hợp đồng">
                <TemplateSettings TemplateId="ReadOnlyTemplateGrid3" />
            </cc1:Column>
            <cc1:Column DataField="BenA" HeaderText="Bên A">
                <TemplateSettings TemplateId="ReadOnlyTemplateGrid3" />
            </cc1:Column>
            <cc1:Column DataField="BenB" HeaderText="Bên B">
                <TemplateSettings TemplateId="ReadOnlyTemplateGrid3" />
            </cc1:Column>
            <cc1:Column DataField="TienNoiTe" HeaderText="Tiền nội tệ">
                <TemplateSettings TemplateId="ReadOnlyTemplateGrid3" />
            </cc1:Column>
            <cc1:Column DataField="TienNgoaiTe" HeaderText="Tiền ngoại tệ">
                <TemplateSettings TemplateId="ReadOnlyTemplateGrid3" />
            </cc1:Column>
            <cc1:Column DataField="TinhTrangHopDong" HeaderText="Trạng thái thực hiện">
                <TemplateSettings TemplateId="ReadOnlyTemplateGrid3" />
            </cc1:Column>
            <cc1:Column DataField="TenKetQuaGiamSat" HeaderText="Trạng thái giám sát">
                <TemplateSettings TemplateId="ComboBoxEditTemplateGrid3" />
            </cc1:Column>
            <cc1:Column DataField="GhiChuGiamSat" HeaderText="Ghi chú">
                <TemplateSettings TemplateId="MultiLineTextBoxEditTemplateGrid3" />
            </cc1:Column>
            <cc1:Column DataField="IdGiamSat" HeaderText="IdGiamSat" Visible="false">
                <TemplateSettings TemplateId="ReadOnlyTemplateGrid3" />
            </cc1:Column>
            <cc1:Column DataField="IdHopDong" HeaderText="IdHopDong" Visible="false">
                <TemplateSettings TemplateId="ReadOnlyTemplateGrid3" />
            </cc1:Column>
            <cc1:Column DataField="IdGoiThau" HeaderText="IdGoiThau" Visible="false">
                <TemplateSettings TemplateId="ReadOnlyTemplateGrid3" />
            </cc1:Column>
        </Columns>
        <Templates>
            <cc1:GridTemplate runat="server" ID="ReadOnlyTemplateGrid3">
                <Template>
                    <input type="text" name="TextBox1" class="excel-textbox" value='<%# Container.Value %>' readonly="readonly" />
                </Template>
            </cc1:GridTemplate>
            <cc1:GridTemplate runat="server" ID="MultiLineTextBoxEditTemplateGrid3">
                <Template>
                    <input type="text" name="TextBox1" class="excel-textbox" value='<%# Container.Value %>' readonly="readonly"
                        onfocus="gridHopDong.editWithMultiLineTextBox(this)" />
                </Template>
            </cc1:GridTemplate>
            <cc1:GridTemplate runat="server" ID="ComboBoxEditTemplateGrid3">
                <Template>
                    <input type="text" name="TextBox1" class="excel-textbox" value='<%# Container.Value %>' readonly="readonly"
                        onfocus="gridHopDong.editWithComboBox(this,'ComboBoxEditor')" />
                </Template>
            </cc1:GridTemplate>
        </Templates>
    </cc1:Grid>
            </Content>
        </vajax:CallbackPanel>


    <div style="display: none;" id="FieldEditorsContainer">
        <div id="MultiLineTextBoxEditorContainer" style="width: 100%">
            <cc2:VdcTextBox runat="server" ID="MultiLineTextBoxEditor" TextMode="MultiLine" Width="100%" Height="40" AutoCompleteType="None">
                    <ClientSideEvents OnKeyDown="navigateThroughCells" />
            </cc2:VdcTextBox>
        </div>
        <div id="ComboBoxEditorContainer" style="width: 100%">
            <cc3:ComboBox runat="server" ID="ComboBoxEditor" Width="100%" Height="150" MenuWidth="175" AllowEdit = "false" OpenOnFocus="false">
                    <ClientSideEvents OnBlur="persistFieldValue" OnOpen="ComboBox_Open" />    
                </cc3:ComboBox>
        </div>
    </div>
    <script src="Script/excel3.js" type="text/javascript"></script>
</asp:Content>
