<%@ Page Title="Update Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Update.aspx.cs" Inherits="Payroll.Web.Pages.Administration.AccountManagement.Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        User Profile</h2>
    <table class="tableForm">
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
    <h2>
        Account Info</h2>
    <table class="tableForm">
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
        <h2>
            Roles</h2>
    <div>
        <asp:CheckBoxList ID="chkRoles" CssClass="CheckboxList" runat="server" Height="16px">
        </asp:CheckBoxList>
    </div>
    <div style="padding-top :20px; text-align:right; width :400px">
        <asp:Button ID="btnSave" runat ="server" Text ="Save" />
        <asp:Button ID="btnCancel" runat ="server" Text="Cancel" />
    </div>
</asp:Content>
