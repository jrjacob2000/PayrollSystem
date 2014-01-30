<%@ Page Title="Time Sheet" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Payroll.Web.Pages.TimeSheet.Default" %>

<%@ Register TagPrefix="uc" Namespace="Payroll.Web.Controls" Assembly="Payroll.Web" %>
<%@ Register TagPrefix="uc" TagName="CreateTimeSheet" Src="~/Pages/TimeSheet/CreateTimeLog.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <script type="text/javascript">

     $(document).ready(
                $(function () {

                    var test = $("#<%=ddlEmployee.ClientID %>")
                    $("#<%=grdTimeLog.ClientID %> a").bind('click', function () {
                        var date = $(".ReportedDate", $(this).closest("tr")).html();
                        alert(test.val() + ' ' + date);
                    });

                })

       );
    </script>
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
  <div>
  <button id="btnPrev" runat ="server">Previous</button>
  <button id="btnNext" runat ="server">Next</button> 
  </div>
  <uc:ExtendedGridview ID="grdTimeLog" runat ="server" DataKeyNames="Id" AutoGenerateColumns ="false"  EmptyDataText="No data available" EnableAlternating = "false" >
      <Columns>
          <asp:BoundField DataField="ReportedDate" ItemStyle-CssClass ="ReportedDate" HeaderText ="Reported date" dataformatstring="{0:MMMM d, yyyy}" htmlencode="false"/>
          <asp:BoundField DataField="DateTimeIn" HeaderText ="Time In" dataformatstring="{0:t}" htmlencode="false"/>
          <asp:BoundField DataField="DateTimeOut" HeaderText ="Time Out" dataformatstring="{0:t}" htmlencode="false"/>
          <asp:BoundField DataField ="Remarks" HeaderText ="Remarks" />
          <%--<asp:CommandField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width ="40px" ButtonType ="Image"  ShowEditButton="true"  />--%>
          <asp:TemplateField>
          <ItemTemplate>
            <a href ="#">Edit</a>
          </ItemTemplate>
          </asp:TemplateField>
      </Columns>
  </uc:ExtendedGridview>
</asp:Content>

