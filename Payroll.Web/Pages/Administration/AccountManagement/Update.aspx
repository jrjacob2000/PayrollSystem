<%@ Page Title="Update Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Update.aspx.cs" Inherits="Payroll.Web.Pages.Administration.AccountManagement.Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div >
        <h3>User Profile</h3>        
    </div>
    <table>
        <tr>
            <th>
                Title:
            </th>
            <td>
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                First Name:
            </th>
            <td>
                <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Last Name:
            </th>
            <td>
                <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Job Title:
            </th>
            <td>
                <asp:TextBox ID="txtJobTitle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Sex:
            </th>
            <td>
                <asp:DropDownList ID="ddlSex" runat="server">
                    <asp:ListItem Value="" Text=""></asp:ListItem>
                    <asp:ListItem Value="true" Text="Male"></asp:ListItem>
                    <asp:ListItem Value="false" Text="Female"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <div >
        <h3>Account Info</h3>
        
    </div>
    <table>
        <tr>
            <th>
                User Name:
            </th>
            <td>
                <asp:Label ID="lblUserName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                Email:
            </th>
            <td>
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <div >
        <h3>Roles</h3>
        
    </div>
    <div>
        <asp:CheckBoxList ID="chkRoles" CssClass="CheckboxList" runat="server" Height="16px">
        </asp:CheckBoxList>
    </div>
</asp:Content>
