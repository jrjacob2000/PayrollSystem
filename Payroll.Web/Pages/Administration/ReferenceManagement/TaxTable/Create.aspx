<%@ Page Title="Create Tax Excemption" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Payroll.Web.Pages.Administration.ReferenceManagement.TaxTable.Create" %>
<%@ Register TagPrefix="uc" TagName="TextBox" Src="~/Controls/ExtendedTextBox.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Tax Maintenance</h2>
        <table class="tableForm">
            <tr>
                <th>TaxCode</th>
                <td>
                    <uc:TextBox ID="txtTaxCode" runat ="server" Required ="true"/>
                </td>
            </tr>
             <tr>
                <th>Description</th>
                <td><uc:TextBox ID="txtDescription" runat ="server" /></td>
            </tr>
             <tr>
                <th>Excemption</th>
                <td><uc:TextBox id="txtExcemption" runat ="server" Required="true" /></td>
            </tr>
            
        </table>
    </div>
     <div style="text-align: right; width: 400px; padding-top :10px">
            <asp:Button ID="btnCancel" runat="server" CssClass="ui-button-text-only" Text="Cancel" />
            <asp:Button ID="btnSave" runat="server" Text="Save" />
        </div>
</asp:Content>
