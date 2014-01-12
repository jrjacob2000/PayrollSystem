<%@ Page Title="Role Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Payroll.Web.Pages.Administration.RoleManagement.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th style="width :45px">Role:</th>
            <td> <asp:DropDownList ID="ddlRole" runat ="server"  AutoPostBack ="true"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:CheckBoxList ID="chkOperation" runat ="server"  CssClass="CheckboxList"></asp:CheckBoxList>
            </td>
        </tr>
         <tr>
                <td> </td>
                <td style ="padding-top :10px ; text-align :right ">
                    <asp:Button ID="btnSave" Text ="Save" runat ="server" />
                </td>
            </tr>
    </table>
    
    </div>
</asp:Content>
