<%@ Page Title="Create Reference" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Create.aspx.cs" Inherits="Payroll.Web.Pages.Administration.ReferenceManagement.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table class="tableForm">
            <tr>
                <th>
                    Reference Type:
                </th>
                <td>
                    <asp:DropDownList ID="ddlReferenceType" runat="server">
                    </asp:DropDownList>
            </tr>
            <tr>
                <th>
                    Code:
                </th>
                <td>
                    <asp:TextBox ID="txtRoleCode" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Description
                </th>
                <td>
                    <asp:TextBox ID="txtRoleDesc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <div style="text-align: right; width: 400px">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
            <asp:Button ID="btnSave" runat="server" Text="Save" />
        </div>
    </div>
</asp:Content>
