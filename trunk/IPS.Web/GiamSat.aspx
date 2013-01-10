<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GiamSat.aspx.cs" Inherits="IPS.Web.GiamSat" %>

<%@ Register Assembly="vdc_AJAXPage" Namespace="VdcInc" TagPrefix="vajax" %>

<%@ Register Assembly="vdc_ComboBox" Namespace="Vdc.ComboBox" TagPrefix="cc3" %>

<%@ Register Assembly="vdc_Interface" Namespace="Vdc.Interface" TagPrefix="cc2" %>

<%@ Register Assembly="vdc_Grid_NET" Namespace="Vdc.Grid" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        window.onload = function () {
            Grid1.convertToExcel(
                ['ReadOnly', 'ReadOnly', 'MultiLineTextBox', 'DropDownList'],
                '<%=Grid1ExcelData.ClientID %>',
                '<%=Grid1ExcelDeletedIds.ClientID %>'
                );

        }
        function CapNhatGrid1() {
            var gr = $("input[id$='Grid1ExcelData']").val();
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Content/CSS/excel-style.css" type="text/css"rel="Stylesheet" />
    <cc2:VdcButton ID="VdcButton1" runat="server" OnClientClick="Grid1.saveExcelChanges(); CapNhatGrid1();" Text="Cập nhật"></cc2:VdcButton>
    <br />
    <br />
    <asp:HiddenField runat="server" ID="Grid1ExcelDeletedIds" />
    <asp:HiddenField runat="server" ID="Grid1ExcelData" />
    <vajax:CallbackPanel ID="CallbackPanel1" runat="server">
    <Content>
    <cc1:Grid ID="Grid1" runat="server" CallbackMode="true" Serialize="true" AllowAddingRecords="False" AllowPageSizeSelection="False" AllowRecordSelection="False" AllowSorting="False" AutoGenerateColumns="false">
        <AddEditDeleteSettings AddLinksPosition="Bottom" NewRecordPosition="Bottom"></AddEditDeleteSettings>
        <ExportingSettings Encoding="Default" ExportedFilesTargetWindow="Current"></ExportingSettings>
        <FilteringSettings FilterLinksPosition="Bottom" FilterPosition="Bottom" InitialState="Hidden" MatchingType="AllFilters"></FilteringSettings>
        <MasterDetailSettings LoadingMode="OnCallback" State="Collapsed"></MasterDetailSettings>
        <PagingSettings PageSizeSelectorPosition="Bottom" Position="Bottom" ShowRecordsCount="False"></PagingSettings>
        <ScrollingSettings FixedColumnsPosition="Left"></ScrollingSettings>
        <Columns>
            <cc1:Column DataField="MaDonVi" Visible="false" >
                <TemplateSettings TemplateId="ReadOnlyTemplate" />
            </cc1:Column>
            <cc1:Column DataField="IdDuAn" Visible="false" >
                <TemplateSettings TemplateId="ReadOnlyTemplate" />
            </cc1:Column>
            <cc1:Column DataField="TenDuAn" HeaderText="Tên dự án" >
                <TemplateSettings TemplateId="MultiLineTextBoxEditTemplate" />
            </cc1:Column>
            <cc1:Column DataField="LoaiNguonVonValue" HeaderText="Loại nguồn vốn" >
                <TemplateSettings TemplateId="ComboBoxEditTemplate" />
            </cc1:Column>
            <cc1:Column DataField="LoaiPhanCap" HeaderText="Phân cấp" >
                <TemplateSettings TemplateId="ReadOnlyTemplate" />
            </cc1:Column>
            <cc1:Column DataField="NhomDuAn" HeaderText="Nhóm" >
                <TemplateSettings TemplateId="ReadOnlyTemplate" />
            </cc1:Column>
            <cc1:Column DataField="NamBatDau" HeaderText="Ngày phát sinh" >
                <TemplateSettings TemplateId="ReadOnlyTemplate" />
            </cc1:Column>
            <cc1:Column DataField="NamKetThuc" HeaderText="Ngày kết thúc" >
                <TemplateSettings TemplateId="ReadOnlyTemplate" />
            </cc1:Column>
            <cc1:Column DataField="TongVonDauTu" HeaderText="Tổng vốn đầu tư" >
                <TemplateSettings TemplateId="ReadOnlyTemplate" />
            </cc1:Column>
        </Columns>
        <Templates>
            <cc1:GridTemplate runat="server" ID="ReadOnlyTemplate">
                <Template>
                    <input type="text" name="TextBox1" class="excel-textbox" value='<%# Container.Value %>' readonly="readonly" />
                </Template>
            </cc1:GridTemplate>
            <cc1:GridTemplate runat="server" ID="MultiLineTextBoxEditTemplate">
                <Template>
                    <input type="text" name="TextBox1" class="excel-textbox" value='<%# Container.Value %>' readonly="readonly"
                        onfocus="Grid1.editWithMultiLineTextBox(this)" />
                </Template>
            </cc1:GridTemplate>
            <cc1:GridTemplate runat="server" ID="ComboBoxEditTemplate">
                <Template>
                    <input type="text" name="TextBox1" class="excel-textbox" value='<%# Container.Value %>' readonly="readonly"
                        onfocus="Grid1.editWithComboBox(this,'ComboBoxEditor')" />
                </Template>
            </cc1:GridTemplate>
        </Templates>
    </cc1:Grid>
            </Content>
        </vajax:CallbackPanel>
    <br />
    <br />
    <br />
    <asp:HiddenField runat="server" ID="Grid2ExcelDeletedIds" />
    <asp:HiddenField runat="server" ID="Grid2ExcelData" />
    <cc1:Grid ID="Grid2" runat="server" CallbackMode="true" Serialize="true" AllowAddingRecords="False" AllowPageSizeSelection="False" AllowRecordSelection="False" AllowSorting="False" AutoGenerateColumns="false">
        <AddEditDeleteSettings AddLinksPosition="Bottom" NewRecordPosition="Bottom"></AddEditDeleteSettings>
        <ExportingSettings Encoding="Default" ExportedFilesTargetWindow="Current"></ExportingSettings>
        <FilteringSettings FilterLinksPosition="Bottom" FilterPosition="Bottom" InitialState="Hidden" MatchingType="AllFilters"></FilteringSettings>
        <MasterDetailSettings LoadingMode="OnCallback" State="Collapsed"></MasterDetailSettings>
        <PagingSettings PageSizeSelectorPosition="Bottom" Position="Bottom" ShowRecordsCount="False"></PagingSettings>
        <ScrollingSettings FixedColumnsPosition="Left"></ScrollingSettings>
        <Columns>
            <cc1:Column DataField="MaDonVi" Visible="false" >
                <TemplateSettings TemplateId="ReadOnlyTemplateGrid2" />
            </cc1:Column>
            <cc1:Column DataField="IdDuAn" Visible="false" >
                <TemplateSettings TemplateId="ReadOnlyTemplateGrid2" />
            </cc1:Column>
            <cc1:Column DataField="TenDuAn" HeaderText="Tên dự án" ></cc1:Column>
            <cc1:Column DataField="LoaiNguonVonValue" HeaderText="Loại nguồn vốn" ></cc1:Column>
            <cc1:Column DataField="LoaiPhanCap" HeaderText="Phân cấp" >
                <TemplateSettings TemplateId="ComboBoxEditTemplateGrid2" />
            </cc1:Column>
            <cc1:Column DataField="NhomDuAn" HeaderText="Nhóm" ></cc1:Column>
            <cc1:Column DataField="NamBatDau" HeaderText="Ngày phát sinh" >
                <TemplateSettings TemplateId="MultiLineTextBoxEditTemplateGrid2" />
            </cc1:Column>
            <cc1:Column DataField="NamKetThuc" HeaderText="Ngày kết thúc" ></cc1:Column>
            <cc1:Column DataField="TongVonDauTu" HeaderText="Tổng vốn đầu tư" ></cc1:Column>
        </Columns>
        <Templates>
            <cc1:GridTemplate runat="server" ID="ReadOnlyTemplateGrid2">
                <Template>
                    <input type="text" name="TextBox1" class="excel-textbox" value='<%# Container.Value %>' readonly="readonly" />
                </Template>
            </cc1:GridTemplate>
            <cc1:GridTemplate runat="server" ID="MultiLineTextBoxEditTemplateGrid2">
                <Template>
                    <input type="text" name="TextBox1" class="excel-textbox" value='<%# Container.Value %>' readonly="readonly"
                        onfocus="Grid2.editWithMultiLineTextBox(this)" />
                </Template>
            </cc1:GridTemplate>
            <cc1:GridTemplate runat="server" ID="ComboBoxEditTemplateGrid2">
                <Template>
                    <input type="text" name="TextBox1" class="excel-textbox" value='<%# Container.Value %>' readonly="readonly"
                        onfocus="Grid2.editWithComboBox(this,'ComboBoxEditor1')" />
                </Template>
            </cc1:GridTemplate>
        </Templates>
    </cc1:Grid>


    <br />
    <br />
    <br />

    <cc1:Grid ID="Grid3" runat="server" CallbackMode="true" Serialize="true" AllowAddingRecords="False" AllowPageSizeSelection="False" AllowRecordSelection="False" AllowSorting="False" AutoGenerateColumns="false">
        <AddEditDeleteSettings AddLinksPosition="Bottom" NewRecordPosition="Bottom"></AddEditDeleteSettings>
        <ExportingSettings Encoding="Default" ExportedFilesTargetWindow="Current"></ExportingSettings>
        <FilteringSettings FilterLinksPosition="Bottom" FilterPosition="Bottom" InitialState="Hidden" MatchingType="AllFilters"></FilteringSettings>
        <MasterDetailSettings LoadingMode="OnCallback" State="Collapsed"></MasterDetailSettings>
        <PagingSettings PageSizeSelectorPosition="Bottom" Position="Bottom" ShowRecordsCount="False"></PagingSettings>
        <ScrollingSettings FixedColumnsPosition="Left"></ScrollingSettings>
        <Columns>
            <cc1:Column DataField="MaDonVi" Visible="false" ></cc1:Column>
            <cc1:Column DataField="IdDuAn" Visible="false" ></cc1:Column>
            <cc1:Column DataField="TenDuAn" HeaderText="Tên dự án" ></cc1:Column>
            <cc1:Column DataField="LoaiNguonVonValue" HeaderText="Loại nguồn vốn" ></cc1:Column>
            <cc1:Column DataField="LoaiPhanCap" HeaderText="Phân cấp" ></cc1:Column>
            <cc1:Column DataField="NhomDuAn" HeaderText="Nhóm" ></cc1:Column>
            <cc1:Column DataField="NamBatDau" HeaderText="Ngày phát sinh" ></cc1:Column>
            <cc1:Column DataField="NamKetThuc" HeaderText="Ngày kết thúc" ></cc1:Column>
            <cc1:Column DataField="TongVonDauTu" HeaderText="Tổng vốn đầu tư" ></cc1:Column>
        </Columns>
    </cc1:Grid>


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
            <div id="ComboBoxEditor1Container" style="width: 100%">
                <cc3:ComboBox runat="server" ID="ComboBoxEditor1" Width="100%" Height="150" MenuWidth="175" AllowEdit = "false" OpenOnFocus="false">
                    <ClientSideEvents OnBlur="persistFieldValue" OnOpen="ComboBox_Open" />    
                </cc3:ComboBox>
            </div>
    </div>
    <script src="Script/excel-style2.js" type="text/javascript"></script>
</asp:Content>
