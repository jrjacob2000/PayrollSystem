<%@ Page Title="Reference Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Payroll.Web.Pages.Administration.ReferenceManagement.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:LinkButton ID="lbCreate" runat="server">New Reference</asp:LinkButton>
        <asp:GridView ID="grdRoles"  runat="server" AutoGenerateColumns="False" DataKeyNames ="Id" AllowCustomPaging="True" OnRowDeleting="grdRoles_RowDeleting">
            <Columns>
                <asp:HyperLinkField DataTextField ="ReferenceTypeCode" HeaderText ="Reference Type" DataNavigateUrlFormatString="~/Pages/Administration/ReferenceManagement/view.aspx?id={0}"  DataNavigateUrlFields="id" />
                <asp:BoundField DataField ="ReferenceValue" HeaderText ="Description"/>
                <asp:CommandField  DeleteText ="Delete" ShowDeleteButton ="true" />
            </Columns>
            
        </asp:GridView>
    </div>
</asp:Content>
