<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Payroll.Web.Pages.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script>
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
            $("#spinner").timespinner();

            //$("#culture").change(function () {
            //    var current = $("#spinner").timespinner("value");
            //    Globalize.culture($(this).val());
            //    $("#spinner").timespinner("value", current);
            //});
        });
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>
	<label for="spinner">Time spinner:</label>
	<input id="spinner" name="spinner" value="08:30 PM" role ="spinbutton">
</p>

<div class="demo-description">
<p>
	A custom widget extending spinner. Use the Globalization plugin to parse and output
	a timestamp, with custom step and page options. Cursor up/down spins minutes, page up/down
	spins hours.
</p>
</div>

    
</asp:Content>
