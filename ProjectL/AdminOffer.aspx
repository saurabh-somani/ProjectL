<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminOffer.aspx.cs" Inherits="ProjectL.AdminOffer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 500px;
            margin-right: 0px;
        }
        .auto-style2 {
            width: 49px;
        }
        .auto-style4 {
            width: 126px;
        }
        .auto-style5 {
            width: 167px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContent" runat="server">
    <p>
        Offers:</p>
    <p>
        &nbsp;</p>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Company:</td>
            <td class="auto-style5">
                <asp:TextBox ID="CompanyTB" runat="server" Width="160px"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CompanyTB" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Role:</td>
            <td class="auto-style5">
                <asp:TextBox ID="RoleTB" runat="server" Width="160px"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="RoleTB" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Type:</td>
            <td class="auto-style5">
                <asp:DropDownList ID="TypeDDL" runat="server" Width="160px">
                    <asp:ListItem>P+I</asp:ListItem>
                    <asp:ListItem>P</asp:ListItem>
                    <asp:ListItem>I</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TypeDDL" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Description:</td>
            <td class="auto-style5">
                <asp:TextBox ID="DescriptionTB" runat="server" Width="160px"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DescriptionTB" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Compensation:</td>
            <td class="auto-style5">
                <asp:TextBox ID="CompensationTB" runat="server" Width="160px" TextMode="Number"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="CompensationTB" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Deadline:</td>
            <td class="auto-style5">
                <asp:TextBox ID="DeadlineTB" runat="server" TextMode="Date" Width="160px"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DeadlineTB" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Button ID="Apply" runat="server" Text="Apply" OnClick="Apply_Click" />
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Text="Applied Successfully" Visible="False"></asp:Label>
    <br />
    <br />
    List of Offers:<br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="OfferID" HeaderText="OfferID" />
            <asp:BoundField DataField="Company" HeaderText="Company" />
            <asp:BoundField DataField="Role" HeaderText="Role" />
            <asp:BoundField DataField="Type" HeaderText="Type" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="Compensation" HeaderText="Compensation" />
            <asp:BoundField DataField="Deadline" DataFormatString="{0: dd/MM/yyyy}" HeaderText="Deadline" />
        </Columns>
    </asp:GridView>
</asp:Content>
