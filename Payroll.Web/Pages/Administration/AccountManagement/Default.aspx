<%@ Page Title="Account Management" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Payroll.Web.Pages.Administration.AccountManagement.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <button id="btnNewAccount" runat="server" style=" width:120px" class="addButton" >New Account</button>        
        <asp:GridView ID="grdAccounts" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" >
            <Columns>
                <asp:BoundField HeaderText="User Name" DataField="UserName" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="30px" >
                    <ItemTemplate>
                        <asp:ImageButton ID="EditButton" runat="server" ImageUrl="~/Resources/Images/edit.jpg"
                                                CommandName="Edit" AlternateText="Edit" ToolTip ="Edit" CommandArgument='<%# Container.DataItemIndex %>' />
                        <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="~/Resources/Images/delete.jpg"
                            CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this user?');"
                            AlternateText="Delete" ToolTip="Delete" CommandArgument='<%# Container.DataItemIndex %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
