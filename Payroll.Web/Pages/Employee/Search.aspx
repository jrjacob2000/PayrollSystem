<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Payroll.Web.Pages.Employee.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div>
       
        <button id="btnCreate" runat="server" style=" width:120px" class="addButton" >New Employee</button>        
        <asp:GridView ID="grdEmployees" Width ="100%" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" EmptyDataText="No available" >
            <Columns>
                <asp:BoundField HeaderText="Employee Number" DataField="EmployeeNumber" />
                <asp:BoundField HeaderText="First Name" DataField="FirstName" />
                <asp:BoundField HeaderText="Last Name" DataField="LastName" />
                <asp:BoundField HeaderText="EmployeeStatus" DataField="EmployeeStatus" />
                <asp:CommandField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width ="100" ButtonType ="Image"  ShowEditButton="true" ShowDeleteButton ="true" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
