<%@ Page Title="Create Reference" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Payroll.Web.Pages.Administration.ReferenceManagement.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <div>
        <table>
             <tr>
                <td>Reference Type:</td>
                <td>
                    <asp:DropDownList ID="ddlReferenceType" runat="server"></asp:DropDownList>
            </tr>
            <tr>
                <td>Code:</td>
                <td>
                    <asp:TextBox ID="txtRoleCode" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Description</td>
                <td>
                    <asp:TextBox ID="txtRoleDesc" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                    <asp:Button ID="btnSave" runat="server" Text="Save" />
                </td>
            </tr>
        </table>
    </div>
   
</asp:Content>

