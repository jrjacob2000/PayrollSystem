<%@ Page Title="Update Reference" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Payroll.Web.Pages.Administration.ReferenceManagement.Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th>
                <asp:Label ID="lblRefCode" Text ="Code:" runat ="server"/>
            </th>
            <td>
                <asp:TextBox ID="txtCode" runat="server" ReadOnly="true" />
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lblRefDesc" Text ="Description:" runat ="server"/>
            </th>
            <td>
                <asp:TextBox ID="txtDesc" runat="server" />
            </td>
        </tr>
         <tr>
                <td>
                    
                </td>
                <td style ="padding-top :10px">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                    <asp:Button ID="btnSave" runat="server" Text="Save" />
                </td>
            </tr>
    </table>

</asp:Content>
