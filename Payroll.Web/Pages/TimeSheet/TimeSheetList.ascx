<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TimeSheetList.ascx.cs" Inherits="Payroll.Web.Pages.TimeSheet.TimeSheetList" %>
<%@ Register TagPrefix="uc" Namespace="Payroll.Web.Controls" Assembly="Payroll.Web" %>

<uc:ExtendedGridview ID="grdTimeLog" runat ="server" DataKeyNames="Id" AutoGenerateColumns ="false"  EmptyDataText="No data available" EnableAlternating = "false" >
      <Columns>
          <%--<asp:BoundField DataField="Id" ItemStyle-CssClass ="Id" HeaderText ="Id" />--%>
          <asp:BoundField DataField="ReportedDate" ItemStyle-CssClass ="ReportedDate" HeaderText ="Reported date" dataformatstring="{0:MMMM d, yyyy}" htmlencode="false"/>
          <asp:BoundField DataField="DateTimeIn" HeaderText ="Time In" dataformatstring="{0:t}" htmlencode="false"/>
          <asp:BoundField DataField="DateTimeOut" HeaderText ="Time Out" dataformatstring="{0:t}" htmlencode="false"/>
          <asp:BoundField DataField ="Remarks" HeaderText ="Remarks" />
          <%--<asp:CommandField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width ="40px" ButtonType ="Image"  ShowEditButton="true"  />--%>
          <asp:TemplateField>
          <ItemTemplate>
            <a href ="#"  onclick ="OpenTimeSheetDialog('<%# Eval("Id") %>','<%# Eval("ReportedDate") %>');">Edit</a>             
          </ItemTemplate>
          </asp:TemplateField>
      </Columns>
  </uc:ExtendedGridview>