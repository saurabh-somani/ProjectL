<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RecruiterSearch.aspx.cs" Inherits="ProjectL.RecruiterSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContent" runat="server">
    <p>
        Recruiter Search:</p>
    <p>
        &nbsp;</p>
    <table class="auto-style1">
        <tr>
            <td>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Skill" DataValueField="Skill">
                </asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=&quot;C:\Users\Mahe\Desktop\7th Sem\IT_LAB\Codes\Project\repo\ProjectL\ProjectL\PlacementDB.mdf&quot;;Initial Catalog=PlacementDB;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT [Skill] FROM [SkillSet] ORDER BY [Skill]"></asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
    <asp:Button ID="Show" runat="server" OnClick="Show_Click" Text="Show" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="List of Students:" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="StudentID" HeaderText="StudentID" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Branch" HeaderText="Branch" />
            <asp:BoundField DataField="CGPA" HeaderText="CGPA" />
        </Columns>
    </asp:GridView>
</asp:Content>
