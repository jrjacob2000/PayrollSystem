<%@ Page Title="Account Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Payroll.Web.Pages.Administration.AccountManagement.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
         <asp:LinkButton ID="lbCreate" runat="server">New Account</asp:LinkButton>
        <asp:GridView ID="grdAccounts" runat="server" DataKeyNames="Id" AutoGenerateColumns ="false">
            <Columns>
                <asp:BoundField HeaderText ="User Name" DataField="UserName" />
                <asp:BoundField HeaderText ="Email" DataField="Email" />
                <asp:BoundField HeaderText ="Deleted" DataField="IsDeleted" />
                <%--<asp:CommandField ButtonType ="Link" ShowEditButton="true" />--%>
                <asp:ButtonField ButtonType="Link" CommandName ="Edit" Text ="Edit" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
