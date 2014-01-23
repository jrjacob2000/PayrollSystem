<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateAddress.ascx.cs" Inherits="Payroll.Web.Pages.Employee.Address.CreateAddress" %>
<%@ Register TagPrefix="uc" TagName="TextBox" Src="~/Controls/ExtendedTextBox.ascx" %>
<%@ Register TagPrefix="uc" TagName="DropDownReference" Src="~/Controls/ReferenceDropDown.ascx" %>
<button id="btnCreateAddress"  >Add New Address</button>
<div id="dialog-form" title="Create new address">
<p class="validateTips"></p>
<form name="createAddressForm" >

  <fieldset>
    <label for="txtAddress">Address</label>
    <input type="text" name="txtAddress" ID="txtAddress"  class="text ui-widget-content ui-corner-all"/>
    <label for="TxtCityMun">City/Mun</label>
    <input type="text" name="TxtCityMun" id="TxtCityMun" value="" class="text ui-widget-content ui-corner-all" />
    <label for="txtProvState">Prov/State</label>
    <input type="text" name="txtProvState" id="txtProvState" value="" class="text ui-widget-content ui-corner-all" />
    <label for="ddlCountry">Country</label>
    <uc:DropDownReference runat ="server" ReferenceType ="Country"  ID="ddlCountry" />
    <label for="txtZipCode">Zipcode</label>
    <input type="text" name="txtZipCode" id="txtZipCode" value="" class="text ui-widget-content ui-corner-all" />
  </fieldset>
  </form>
</div>

<div id='divOverlayContent'>
</div>

<script language ="javascript" type ="text/javascript">
    $(function () {

        var address = $("#txtAddress"),
      cityMun = $("#TxtCityMun"),
      provState = $("#txtProvState"),
        //country = $("#ddlCountry"),
      zipcode = $("#txtZipCode"),
      allFields = $([]).add(address).add(cityMun).add(provState),
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
                "Create an account": function () {

                    var bValid = true;
                    allFields.removeClass("ui-state-error");

                    bValid = bValid && checkLength(address, "Address");

                    bValid = bValid && checkLength(cityMun, "City/Mun");
                    bValid = bValid && checkLength(provState, "Prov/State");

                    var dtoAddress = new Object();
                    dtoAddress.address = address.val();
                    dtoAddress.cityMun = cityMun.val();
                    dtoAddress.provState = provState.val();
                    //address.country = country.val();
                    dtoAddress.zipcode = zipcode.val();

                    var dto = { 'request': dtoAddress };

                    if (bValid) {

                        $.ajax({
                            type: "POST",
                            url: "../../WebServices/PayrollWebService.asmx/CreateAddress",
                            data: JSON.stringify(dto),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (msg) {
                                $("#divOverlayContent").empty();
                                $("#divOverlayContent").append(msg.d);
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


        $("#btnCreateAddress")
      .button()
      .click(function () {
          allFields.val("");
          $("#dialog-form").dialog("open");
          return false;
      });
    });


</script>

