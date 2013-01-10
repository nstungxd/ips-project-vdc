<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GiamSat.aspx.cs" Inherits="IPS.Web.GiamSat" %>

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
    <asp:HiddenField runat="server" ID="gridNamKeHoachExcelDeletedIds" />
    <asp:HiddenField runat="server" ID="gridNamKeHoachExcelData" />
    <vajax:CallbackPanel ID="CallbackPanel1" runat="server">
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
    <script src="Script/excel-style.js" type="text/javascript"></script>
</asp:Content>
