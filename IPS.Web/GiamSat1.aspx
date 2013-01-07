<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GiamSat1.aspx.cs" Inherits="IPS.Web.GiamSat1" %>

<%@ Register Assembly="vdc_Grid_NET" Namespace="Vdc.Grid" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <cc1:Grid ID="Grid1" runat="server" Serialize="false" FolderStyle="styles/grand_gray" >
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
    </cc1:Grid>
</asp:Content>
