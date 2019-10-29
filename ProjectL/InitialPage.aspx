<%@ Page Theme="InitialPageTheme" Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InitialPage.aspx.cs" Inherits="ProjectL.InitialPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CenterContent" runat="server">
    <p>
        Login As:</p>
    <p>
        <asp:Button ID="BRecruiter" runat="server" Text="Recruiter" Width="100px" OnClick="BRecruiter_Click" />
    </p>
    <p>
        <asp:Button ID="BAdmin" runat="server" Text="Admin" Width="100px" OnClick="BAdmin_Click" />
    </p>
    <p>
        <asp:Button ID="BStudent" runat="server" Text="Student" Width="100px" OnClick="BStudent_Click" />
    </p>
</asp:Content>
