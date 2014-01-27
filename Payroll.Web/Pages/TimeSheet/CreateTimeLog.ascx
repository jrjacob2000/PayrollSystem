<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateTimeLog.ascx.cs" Inherits="Payroll.Web.Pages.TimeSheet.CreateTimeLog" %>
<%@ Register TagPrefix="uc" TagName="TextBox" Src="~/Controls/ExtendedTextBox.ascx" %>
<%@ Register TagPrefix="uc" TagName="DropDownReference" Src="~/Controls/ReferenceDropDown.ascx" %>
<button id="btnCreateTimeLog"  >Add New TimeLog</button>
<div id="dialog-form" title="Create new address">
<p class="validateTips"></p>
<form name="createAddressForm" >

  <fieldset>
    <label for="txtDate">Reported Date</label>
    <input type="text" name="txtDate" ID="txtDate" value="" Class="datepicker"/>
    <label for="TxtDateIn">Date time In</label>
    <input type="text" name="TxtDateIn" ID="TxtDateIn" value="" Class="datepicker"/>
    <input id="TxtTimeIn" name="TxtTimeIn"  Class="spinnerTime" value="08:30 AM">

    <label for="TxtDateOut">Date time out </label>
    <input type="text" name="TxtDateOut" ID="TxtDateOut" value="" Class="datepicker"/>
    <input name="txtTimeOut" id="txtTimeOut"  Class="spinnerTime" value="05:30 PM" />
    
  </fieldset>
  </form>
</div>

<div id='divOverlayContent'>
</div>

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



    $(function () {

      var date = $("#txtDate"),
      dateTimein = $("#TxtDateIn"),
      timein = $("#TxtTimeIn"),
      dateTimeout = $("#TxtDateOut"),
      timeout = $("#txtTimeOut"),
      empId = "<%= EmployeeId %>",
      allFields = $([]).add(date).add(dateTimein).add(dateTimeout),
      tips = $(".validateTips");

        function updateTips(t) {
            tips
        .text(t)
        .addClass("ui-state-highlight");
            setTimeout(function () {
                tips.removeClass("ui-state-highlight", 1500);
            }, 500);
        }

        function checkLength(o, n) {
            if (o.val().length < 1) {
                o.addClass("ui-state-error");
                updateTips(n + " is required. ");
                return false;
            } else {
                return true;
            }
        }
        
        $("#dialog-form").dialog({
            autoOpen: false,
            height: 350,
            width: 350,
            modal: true,
            buttons: {
                "Save": function () {

                    var bValid = true;
                    allFields.removeClass("ui-state-error");

                    bValid = bValid && checkLength(date, "Date");
                    bValid = bValid && checkLength(dateTimein, "Date Time In");
                    bValid = bValid && checkLength(timein, "Time In");
                    bValid = bValid && checkLength(dateTimeout, "Date Time Out");
                    bValid = bValid && checkLength(timeout, "Time In");

                    var dtoData = new Object();
                    dtoData.EmpId = empId;
                    dtoData.Date = date.val();
                    dtoData.DateTimeIn = dateTimein.val() + " " + timein.val();
                    dtoData.DateTimeOut = dateTimeout.val() + " " + timeout.val();

                    dto = { 'request': dtoData };
       

                    if (bValid) {

                        $.ajax({
                            type: "POST",
                            url: "../../WebServices/PayrollWebService.asmx/CreateTimeSheet",
                            data: JSON.stringify(dto),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (msg) {
                                alert(msg.d);
                                //$("#divOverlayContent").empty();
                                //$("#divOverlayContent").append(msg.d);
                            },
                            error: function (msg) {
                                alert('error' + msg.responseText);
                            }
                        });

                        $(this).dialog("close");
                    }
                },
                Cancel: function () {
                    $(this).dialog("close");
                }
            },
            close: function () {
                allFields.val("").removeClass("ui-state-error");
            }
        });


        $("#btnCreateTimeLog")
      .button()
      .click(function () {
          allFields.val("");
          $("#dialog-form").dialog("open");
          return false;
      });

        $(".spinnerTime").timespinner();

    });


</script>

