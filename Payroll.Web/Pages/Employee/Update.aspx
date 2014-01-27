<%@ Page Title="Edit Employee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Payroll.Web.Pages.Employee.Update" %>
<%@ Register TagPrefix="uc" TagName="DropDownReference" Src="~/Controls/ReferenceDropDown.ascx" %>
<%@ Register TagPrefix="uc" TagName="TextBox" Src="~/Controls/ExtendedTextBox.ascx" %>

<%@ Register TagPrefix="uc" TagName="CreateAddressDialog" Src="~/Pages/Employee/Address/CreateAddress.ascx" %>

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
                    <uc:TextBox ID="txtTitle" runat="server"></uc:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    First Name:
                </th>
                <td>
                    <uc:TextBox ID="txtFname" Required ="true" runat="server"></uc:TextBox>
                    
                </td>
            </tr>
            <tr>
                <th>
                    Middle Name:
                </th>
                <td>
                    <uc:TextBox ID="txtMname" runat="server"></uc:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Last Name:
                </th>
                <td>
                    <uc:TextBox ID="txtLname" runat="server" Required ="true"></uc:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Age:
                </th>
                <td>
                    <uc:TextBox ID="txtAge" runat="server" Required="true"></uc:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Birth Date:
                </th>
                <td>
                    <uc:TextBox ID="txtBirthDate" CssClass="datepicker" runat="server" Required="true"></uc:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Sex:
                </th>
                <td>                    
                    <asp:DropDownList ID="ddlSex" runat ="server">
                        <asp:ListItem />
                        <asp:ListItem Value ="M" Text ="Male"/>
                        <asp:ListItem Value ="F" Text ="Female"/>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvSex" runat ="server" ErrorMessage ="" ControlToValidate ="ddlSex"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    Civil Status:
                </th>
                <td>
                    <uc:DropDownReference runat ="server" ReferenceType ="CivilStatus" Required ="true" ID="ddlCivilStatus" />
                </td>
            </tr>
            <tr>
                <th>
                    Home Phone:
                </th>
                <td>
                    <uc:TextBox ID="txtHomePhone" runat="server"></uc:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Mobile Phone:
                </th>
                <td>
                    <uc:TextBox ID="txtMobile" runat="server"></uc:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Email:
                </th>
                <td>
                    <uc:TextBox ID="txtEmail" runat ="server" />
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
                    <uc:TextBox ID="txtAddress" runat="server" Required ="true"></uc:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    City/Mun.:
                </th>
                <td>
                    <uc:TextBox ID="TxtCityMun" runat="server" Required="true"></uc:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Prov./Stat:
                </th>
                <td>
                    <uc:TextBox ID="txtProvState" runat="server" Required="true"></uc:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Country:
                </th>
                <td>
                    <uc:DropDownReference runat ="server" ReferenceType ="Country" ID="ddlCountry" />
                </td>
            </tr>
            <tr>
                <th>
                    Zip Code:
                </th>
                <td>
                    <uc:TextBox ID="txtZipCode" runat="server"></uc:TextBox>
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
                    <uc:DropDownReference runat ="server" Required="true" ReferenceType ="TaxStatus" ID="ddlTaxStatus" />
                </td>
            </tr>
            <tr>
                <th>
                    SSS No.:
                </th>
                <td>
                    <uc:TextBox ID="txtSSSNumber" runat="server" Required="true"></uc:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    T.I.N:
                </th>
                <td>
                    <uc:TextBox ID="txtTIN" runat="server"></uc:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Pag-Ibig No.:
                </th>
                <td>
                    <uc:TextBox ID="txtPagIbig" runat="server"></uc:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    PhilHealth No.:
                </th>
                <td>
                    <uc:TextBox ID="txtPhilHealth" runat="server"></uc:TextBox>
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
                    <uc:TextBox ID="txtEmployeeNumber" Required="true" runat="server"></uc:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Department:
                </th>
                <td>
                    <uc:DropDownReference runat ="server" Required="true" ReferenceType ="Department" ID="ddlDepartment" />
                </td>
            </tr>
            <tr>
                <th>
                    Position:
                </th>
                <td>
                    <uc:DropDownReference runat ="server" Required="true" ReferenceType ="Position" ID="ddlPosition" />
                </td>
            </tr>
            <tr>
                <th>
                    Hire Date:
                </th>
                <td>
                    <uc:TextBox ID="txtHiredDate" Required="true" CssClass="datepicker" runat="server"></uc:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Employement Type:
                </th>
                <td>
                    <uc:DropDownReference runat ="server" Required="true" ReferenceType ="EmployementType" ID="ddlEmployeeType" />
                </td>
            </tr>
            <tr>
                <th>
                    SalaryRate:
                </th>
                <td>
                    <uc:TextBox ID="txtSalaryRate" runat="server"></uc:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Current Salary:
                </th>
                <td>
                    <uc:TextBox ID="txtCurrentSalary" Required="true" runat="server"></uc:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Employee Status:
                </th>
                <td>
                    <uc:DropDownReference runat ="server" Required="true" ReferenceType ="EmployeeStatus" ID="ddlEmpStatus" />
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
                    <uc:DropDownReference runat ="server" Required="true" ReferenceType ="Bank" ID="ddlBankName" />
                </td>
            </tr>
            <tr>
                <th>
                    Account Number:
                </th>
                <td>
                    <uc:TextBox ID="txtAccountNumber" runat="server"></uc:TextBox>
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
            <asp:Button ID="btnCancel" runat="server" CssClass="ui-button-text-only" Text="Cancel" CausesValidation="false" />
            <asp:Button ID="btnSave" runat="server" Text="Save" />
        </div>
        <%--<uc:CreateAddressDialog id="dialogAddress" runat="server"></uc:CreateAddressDialog>--%>
    </div>
</asp:Content>
