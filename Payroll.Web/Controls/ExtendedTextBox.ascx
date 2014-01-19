<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExtendedTextBox.ascx.cs" Inherits="Payroll.Web.Controls.ExtendedTextBox" %>
<asp:TextBox ID="txtExtended" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvExtended" runat="server" ControlToValidate="txtExtended" ErrorMessage="*"></asp:RequiredFieldValidator>
