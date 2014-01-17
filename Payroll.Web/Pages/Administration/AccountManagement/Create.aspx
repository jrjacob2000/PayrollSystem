<%@ Page Title="Account Creation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Create.aspx.cs" Inherits="Payroll.Web.Pages.Administration.AccountManagement.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 200px">
        <asp:Wizard ID="wzdAccount" CssClass="Wizard" runat="server" DisplaySideBar="False" DisplayCancelButton="true">
            <WizardSteps>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Profile Creation">
                    <h2>
                        User Profile
                    </h2>
                    <table class="tableForm">
                        <tr>
                            <th>
                                Title:
                            </th>
                            <td>
                                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                First Name:
                            </th>
                            <td>
                                <span>
                                    <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtxtFname" ControlToValidate="txtFname" runat="server"
                                        ErrorMessage="*" ></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Last Name:
                            </th>
                            <td>
                                <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtLname"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            
                        </tr>
                        <tr>
                            <th>
                                Job Title:
                            </th>
                            <td>
                                <asp:TextBox ID="txtJobTitle" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Sex:
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlSex" runat="server">
                                    <asp:ListItem Value="" Text=""></asp:ListItem>
                                    <asp:ListItem Value="true" Text="Male"></asp:ListItem>
                                    <asp:ListItem Value="false" Text="Female"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlSex"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            
                        </tr>
                    </table>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep2" runat="server" Title="Account Creation">
                    <h2>
                        User Account
                    </h2>
                    <table class="tableForm">
                        <tr>
                            <th>
                                UserName:
                            </th>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtUserName"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Email:
                            </th>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtEmail"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Password:
                            </th>
                            <td>
                                <asp:TextBox TextMode="Password" ID="txtPassword" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtPassword"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Confirm Password:
                            </th>
                            <td>
                                <asp:TextBox TextMode="Password" ID="txtConfirmPassword" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtConfirmPassword"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep3" runat="server" Title="Roles">
                    <h2>
                        User Roles
                    </h2>
                    <div style="padding-left: 15px">
                        <asp:CheckBoxList ID="chkRoles" CssClass="CheckboxList" runat="server" Height="16px">
                        </asp:CheckBoxList>
                    </div>
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
    </div>
</asp:Content>
