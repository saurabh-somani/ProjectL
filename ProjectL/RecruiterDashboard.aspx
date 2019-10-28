<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RecruiterDashboard.aspx.cs" Inherits="ProjectL.RecruiterDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 500px;
    }
    .auto-style2 {
        width: 100px;
    }
    .auto-style3 {
        width: 212px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContent" runat="server">
    <p>
    Recruiter Dashboard:</p>
<p>
    &nbsp;</p>
<table class="auto-style1">
    <tr>
        <td class="auto-style2">Company:</td>
        <td class="auto-style3">
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Company" DataValueField="Company" Width="126px">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PlacementDBConnectionString %>" SelectCommand="SELECT DISTINCT [Company] FROM [Company] ORDER BY [Company]" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">SubType:</td>
        <td class="auto-style3">
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">E-mail ID:</td>
        <td class="auto-style3">
            <asp:TextBox ID="TextBox3" runat="server" TextMode="Email"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">Phone:</td>
        <td class="auto-style3">
            <asp:TextBox ID="TextBox4" runat="server" TextMode="Number"></asp:TextBox>
        </td>
        <td>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox4" ErrorMessage="RangeValidator" MaximumValue="9999999999" MinimumValue="1000000000" Type="Double"></asp:RangeValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
<br />
<asp:Button ID="Update" runat="server" Text="Update" OnClick="Update_Click" />
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
