<%@ Page Title="Account Management" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Payroll.Web.Pages.Administration.AccountManagement.Default" %>

<%@ Register TagPrefix="uc" Namespace="Payroll.Web.Controls" Assembly="Payroll.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div >       
        <button id="btnNewAccount" runat="server" style=" width:120px" class="addButton" >New Account</button>        
        <uc:ExtendedGridview ID="grdAccounts" runat="server" DataKeyNames="Id" AutoGenerateColumns="false"  >
            <Columns>
                <asp:BoundField HeaderText="User Name" DataField="UserName" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:CommandField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width ="30px" ButtonType ="Image"  ShowEditButton="true" ShowDeleteButton ="true" />
            </Columns>
        </uc:ExtendedGridview>
    </div>
</asp:Content>
