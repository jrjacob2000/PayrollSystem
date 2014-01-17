<%@ Page Title="New Employee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Create.aspx.cs" Inherits="Payroll.Web.Pages.Employee.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>
            Personal Info</h2>
        <table class="tableForm">
            <tr>
                <th>
                    Title:
                </th>
                <td>
                    <asp:TextBox ID="txtTile" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    First Name:
                </th>
                <td>
                    <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Middle Name:
                </th>
                <td>
                    <asp:TextBox ID="txtMname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Last Name:
                </th>
                <td>
                    <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Age:
                </th>
                <td>
                    <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Birth Date:
                </th>
                <td>
                    <asp:TextBox ID="txtBirthDate" CssClass="datepicker" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Sex:
                </th>
                <td>
                    <asp:TextBox ID="txtSex" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Civil Status:
                </th>
                <td>
                    <asp:TextBox ID="txtCivilStatus" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Home Phone:
                </th>
                <td>
                    <asp:TextBox ID="txtHomePhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Mobile Phone:
                </th>
                <td>
                    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <h2>
            Present Home Address</h2>
        <table class="tableForm">
            <tr>
                <th>
                    Address:
                </th>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    City/Mun.:
                </th>
                <td>
                    <asp:TextBox ID="TxtCityMun" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Prov./Stat:
                </th>
                <td>
                    <asp:TextBox ID="txtProvState" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Country:
                </th>
                <td>
                    <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Zip Code:
                </th>
                <td>
                    <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <h2>
            Statutory Information</h2>
        <table class="tableForm">
            <tr>
                <th>
                    Tax Status:
                </th>
                <td>
                    <asp:TextBox ID="txtTaxStatus" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    SSS No.:
                </th>
                <td>
                    <asp:TextBox ID="txtSSSNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    T.I.N:
                </th>
                <td>
                    <asp:TextBox ID="txtTIN" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Pag-Ibig No.:
                </th>
                <td>
                    <asp:TextBox ID="txtPagIbig" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    PhilHealth No.:
                </th>
                <td>
                    <asp:TextBox ID="txtPhilHealth" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <h2>
            Current Work Information
        </h2>
        <table class="tableForm">
            <tr>
                <th>
                    Employee Number:
                </th>
                <td>
                    <asp:TextBox ID="txtEmployeeNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Department:
                </th>
                <td>
                    <asp:DropDownList ID="ddlDropDown" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    Position:
                </th>
                <td>
                    <asp:TextBox ID="txtPosition" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Hire Date:
                </th>
                <td>
                    <asp:TextBox ID="txtHiredDate" CssClass="datepicker" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Employement Type:
                </th>
                <td>
                    <asp:TextBox ID="ddlEmployementType" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    SalaryRate:
                </th>
                <td>
                    <asp:TextBox ID="txtSalaryRate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Current Salary:
                </th>
                <td>
                    <asp:TextBox ID="txtCurrentSalary" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Employee Status:
                </th>
                <td>
                    <asp:DropDownList ID="ddlEmployeeStatus" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <h2>
            Bank Info</h2>
        <table class="tableForm">
            <tr>
                <th>
                    Bank Name:
                </th>
                <td>
                    <asp:DropDownList ID="ddlBank" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    Account Number:
                </th>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>
                </td>
            </tr>
        </table>
        <div style="text-align: right; width: 400px">
            <asp:Button ID="btnCancel" runat="server" CssClass="ui-button-text-only" Text="Cancel" />
            <asp:Button ID="btnSave" runat="server" Text="Save" />
        </div>
    </div>
</asp:Content>
