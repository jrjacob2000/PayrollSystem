<%@ Page Title="Time Sheet" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Payroll.Web.Pages.TimeSheet.Default" %>

<%@ Register TagPrefix="uc" Namespace="Payroll.Web.Controls" Assembly="Payroll.Web" %>
<%@ Register TagPrefix="uc" TagName="TimeSheetList" Src="~/Pages/TimeSheet/TimeSheetList.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <script type="text/javascript">
     $(function () {

         $("#divDialog").dialog({
             autoOpen: false,
             resizable: false,
             title: 'Update DTR',
             height: 260,
             width: 350,
             modal: true
            
         });

         //$("#btnNext").click(GetTimeSheetList);
     });


     function Save(id, employeeId, reportedDate, dateInClientId,dateOutClientId,timeInClientId,timeOutClientId)
     {
         var dateIn = $("#" + dateInClientId).val();
         var dateOut = $("#" + dateOutClientId).val();
         var timeIn = $("#" + timeInClientId).val();
         var timeOut = $("#" + timeOutClientId).val();

         var dtoData = new Object();
         dtoData.Id = id;
         dtoData.EmpId = employeeId;
         dtoData.Date = reportedDate;
         dtoData.DateTimeIn = dateIn + ' ' + timeIn;
         dtoData.DateTimeOut = dateOut + ' ' + timeOut;

         dto = { 'request': dtoData };

         $.ajax({
             type: "POST",
             url: "../../WebServices/PayrollWebService.asmx/UpdateTimeSheet",
             data: JSON.stringify(dto),
             contentType: "application/json; charset=utf-8",
             dataType: "json",
             success: function (msg) {
                 $("#divGridTimesheetContainer").empty();
                 $("#divGridTimesheetContainer").append(msg.d);

                 $('#divDialog').dialog("close");
             },
             error: function (msg) {
                 alert('error' + msg.responseText);
             }
         });
         
         $('#divDialog').dialog("close");
     };
                
    
     function OpenTimeSheetDialog(id, reportedDate) {

         var employeeId = $("#<%=ddlEmployee.ClientID %>").val();
         //var id = $(".Id", $(this).closest("tr")).html();
         //var reportedDate = $(".ReportedDate ", $(this).closest("tr")).html();
 
         var dtoData = new Object();
         dtoData.Id = id;
         dtoData.EmpId = employeeId;
         dtoData.ReportedDate = reportedDate;

         dto = { 'request': dtoData };

         $.ajax({
             type: "POST",
             url: "../../WebServices/PayrollWebService.asmx/GetTimeSheet",
             data: JSON.stringify(dto),
             contentType: "application/json; charset=utf-8",
             dataType: "json",
             success: function (msg) {
                 $("#divDialog").empty();
                 $("#divDialog").append(msg.d);
             },
             error: function (msg) {
                 alert('error' + msg.responseText);
             }
         });
         $("#divDialog").dialog("open");
     }

     function GetTimeSheetList()
     {
         var employeeId = $("#<%=ddlEmployee.ClientID %>").val();        

         var dtoData = new Object();
         dtoData.Id = '';
         dtoData.EmpId = employeeId;
         dtoData.ReportedDate = '';

         dto = { 'request': dtoData };

         $.ajax({
             type: "POST",
             url: "../../WebServices/PayrollWebService.asmx/GetTimeSheetList",
             data:   JSON.stringify(dto) ,
             contentType: "application/json; charset=utf-8",
             dataType: "json",
             success: function (msg) {
                 $("#divGridTimesheetContainer").empty();
                 $("#divGridTimesheetContainer").append(msg.d);

                 return false;
             },
             error: function (msg) {
                 alert('error' + msg.responseText);
             }
         });

         return false;
     }
   
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
 
  
  <div>

  <button id="btnPrev" runat ="server" >Previous</button>
  <button id="btnNext" runat ="server">Next</button> 
  </div>
    <div id="divGridTimesheetContainer">
   <uc:TimeSheetList ID="grdTimeSheet"  runat ="server" />
</div>

  <div id='divDialog'>
  </div>
</asp:Content>

