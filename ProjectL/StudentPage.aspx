<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="ProjectL.StudentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
    <asp:Button ID="Button2" runat="server" Text="Applied" Width="100px" OnClick="Applied" />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Companies" Width="100px" OnClick="Companies" />
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContent" runat="server">
    <br />
    List of Companies:<br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowSorting="true" OnSelectedIndexChanged ="Info">
        <Columns>
            <asp:CommandField ShowSelectButton="True"/>
            <asp:BoundField DataField ="OfferID" HeaderText ="OfferID" SortExpression ="OfferID" />
            <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company" />
            <asp:BoundField DataField="Deadline" HeaderText="Deadline" SortExpression="Deadline" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
        </Columns>
    </asp:GridView>
    <br />
<br />
</asp:Content>
