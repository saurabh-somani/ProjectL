<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InfoPage.aspx.cs" Inherits="ProjectL.InfoPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 600px;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            width: 143px;
        }
        .auto-style4 {
            height: 23px;
            width: 143px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContent" runat="server">
    <h2><asp:Label ID="LCompany" runat="server" Text="Label"></asp:Label></h2>
    <br />
    <br />
    <br />
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">OfferID:</td>
            <td>
                <asp:Label ID="LOfferID" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Role:</td>
            <td class="auto-style2">
                <asp:Label ID="LRole" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Type:</td>
            <td>
                <asp:Label ID="LType" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Description:</td>
            <td>
                <asp:Label ID="LDescription" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Compensation:</td>
            <td>
                <asp:Label ID="LCompensation" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Deadline:</td>
            <td>
                <asp:Label ID="LDeadline" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Button ID="Apply" runat="server" Text="Apply" OnClick="Apply_Click" />
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
</asp:Content>
