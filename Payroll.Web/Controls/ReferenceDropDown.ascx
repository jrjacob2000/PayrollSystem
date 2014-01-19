<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReferenceDropDown.ascx.cs" Inherits="Payroll.Web.Controls.ReferenceDropDown" %>
<asp:DropDownList ID="ddlReference" runat="server"></asp:DropDownList>
<asp:RequiredFieldValidator ID="rfvExtended" runat="server" ControlToValidate="ddlReference" ErrorMessage="*"></asp:RequiredFieldValidator>