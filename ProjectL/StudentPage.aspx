<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="ProjectL.StudentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContent" runat="server">
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AutoGenerateSelectButton="true">
        <Columns>
            <asp:BoundField DataField="Company" HeaderText="Company" />
            <asp:BoundField DataField="Deadline" HeaderText="Deadline" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="Type" HeaderText="Type" />
        </Columns>
    </asp:GridView>
</asp:Content>
