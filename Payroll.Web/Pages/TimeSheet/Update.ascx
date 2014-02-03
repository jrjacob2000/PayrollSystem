<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Update.ascx.cs" Inherits="Payroll.Web.Pages.TimeSheet.Update" %>

<%--<div id="dialog-form" title="Create new address">--%>
   <asp:HiddenField ID ="hiddenEmployeeId" runat ="server" /> 
    <asp:HiddenField ID ="hiddenId" runat ="server" /> 
<div style ="height :150px">
  <fieldset>
    <label for="txtDate">Reported Date</label>
    <input runat ="server" type="text" name="txtDate" ID="txtDate" value="" Class="datepicker"/>
    <label for="TxtDateIn">Date time In</label>
    <input runat ="server" type="text" name="TxtDateIn" ID="TxtDateIn" value="" Class="datepicker"/>
    <input runat ="server" id="TxtTimeIn" name="TxtTimeIn" style ="width:70px"  Class="spinnerTime" value="08:30 AM">

    <label for="TxtDateOut">Date time out </label>
    <input runat ="server" type="text" name="TxtDateOut" ID="TxtDateOut" value="" Class="datepicker"/>
    <input runat ="server" name="txtTimeOut" id="txtTimeOut" style ="width:70px"  Class="spinnerTime" value="05:30 PM" />
    
  </fieldset>
    </div>
  <div class="ui-dialog-buttonpane ui-widget-content ui-helper-clearfix" >
      <div class="ui-dialog-buttonset" >
          <button  type="button" id="btnSave" runat ="server" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" role="button" aria-disabled="false"  >
              <span class="ui-button-text">Save</span>
          </button>
          <button type="button" id="btnCancel" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" role="button" aria-disabled="false">
              <span class="ui-button-text">Cancel</span>
          </button>
      </div>
  </div>
<%--</div>--%>
<script language ="javascript" type ="text/javascript">
    $.widget("ui.timespinner", $.ui.spinner, {
        options: {
            // seconds
            step: 60 * 1000,
            // hours
            page: 60
        },

        _parse: function (value) {
            if (typeof value === "string") {
                // already a timestamp
                if (Number(value) == value) {
                    return Number(value);
                }
                return +Globalize.parseDate(value);
            }
            return value;
        },

        _format: function (value) {
            return Globalize.format(new Date(value), "t");
        }
    });

    $(".spinnerTime").timespinner();
    $(".datepicker").datepicker();

    $("#btnCancel").click(
        function () {
            $('#divDialog').dialog("close");
        }
    );
    

</script>
