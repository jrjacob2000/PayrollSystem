<%@ Page Title="Time Sheet" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Payroll.Web.Pages.TimeSheet.Default" %>

<%@ Register TagPrefix="uc" Namespace="Payroll.Web.Controls" Assembly="Payroll.Web" %>
<%@ Register TagPrefix="uc" TagName="CreateTimeSheet" Src="~/Pages/TimeSheet/CreateTimeLog.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
    <div>
        <h3>Select Employee</h3>
        <asp:DropDownList ID="ddlEmployee" AutoPostBack ="true" runat ="server"></asp:DropDownList>
        <button id="btnGo" runat ="server">Go</button> 
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <uc:CreateTimeSheet ID="dialogTimeSheet"  runat ="server" />
  <uc:ExtendedGridview ID="grdTimeLog" runat ="server" DataKeyNames="Id" AutoGenerateColumns ="false"  EmptyDataText="No data available">
      <Columns>
          <asp:BoundField DataField="ReportedDate" HeaderText ="Reported date" />
          <asp:BoundField DataField="DateTimeIn" HeaderText ="Time In"/>
          <asp:BoundField DataField="DateTimeOut" HeaderText ="Time Out" />
          <asp:CommandField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width ="40px" ButtonType ="Image"  ShowEditButton="true" ShowDeleteButton ="true" />
      </Columns>
  </uc:ExtendedGridview>
    <asp:Calendar ID="Calendar1" runat="server" EnableTheming="True" ShowGridLines="True"></asp:Calendar>
</asp:Content>
