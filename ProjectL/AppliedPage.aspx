<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AppliedPage.aspx.cs" Inherits="ProjectL.AppliedPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
    <asp:Button ID="Button2" runat="server" Text="Companies" onclick="Companies"/>
    <br />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AutoGenerateSelectButton="true" OnSelectedIndexChanged="info">
        <Columns>
            <asp:BoundField DataField="OfferID" HeaderText ="OfferID" />
            <asp:BoundField DataField ="Company" HeaderText ="Company" />
            <asp:BoundField DataField ="Role" HeaderText="Role" />
        </Columns>

    </asp:GridView>
</asp:Content>
