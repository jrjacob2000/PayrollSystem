<%@ Page Title="View Reference" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Payroll.Web.Pages.Administration.ReferenceManagement.View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th>
                <asp:Label ID="lblRefCode" Text ="Code:" runat ="server"/>
            </th>
            <td>
                 <asp:Label  CssClass="readOnly"  ID="lblRefCodeValue"  runat ="server"/>
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lblRefDesc" Text ="Description:" runat ="server"/>
            </th>
            <td>
                <asp:Label CssClass="readOnly" ID="lblRefDescValue" Text ="Description:" runat ="server"/>
            </td>
        </tr>
         <tr>
                <td>
                    
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" />
                </td>
            </tr>
    </table>

</asp:Content>
