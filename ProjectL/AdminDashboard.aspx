<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="ProjectL.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
    <asp:Button ID="Button2" runat="server" Text="Manage Students" OnClick="Button2_Click" />
<br />
<br />
<asp:Button ID="Button3" runat="server" Text="Manage Companies" />
<br />
<br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContent" runat="server">
    <h2>Welcome Admin</h2>
<p>&nbsp;</p>
<p>&nbsp;</p>

</asp:Content>
