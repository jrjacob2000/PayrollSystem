<%@ Page Title="Account Creation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Payroll.Web.Pages.Administration.AccountManagement.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width :200px">

    <asp:Wizard ID="wzdAccount" CssClass="Wizard" runat="server"  DisplaySideBar="False">
        <WizardSteps>
            <asp:WizardStep ID="WizardStep1"  runat="server" Title="Profile Creation">
                 <div style="font-size :20px; padding-left :20px">
                    User Profile
                 </div>
                <table >
                    <tr style="padding-left :20px">
                        <th >Title:</th>
                        <td><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>First Name:</th>
                        <td>
                            <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>Last Name:</th>
                        <td><asp:TextBox ID="txtLname" runat="server"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <th>Job Title:</th>
                        <td><asp:TextBox ID="txtJobTitle" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Sex:</th>
                        <td><asp:DropDownList ID="ddlSex" runat="server">
                            <asp:ListItem Value ="" Text=""></asp:ListItem>
                            <asp:ListItem Value ="true" Text="Male"></asp:ListItem>
                            <asp:ListItem Value ="false" Text="Female"></asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                </table>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep2" runat="server" Title="Account Creation">
                 <div style="font-size :20px; padding-left :20px">
                     User Account
                 </div>
                   <table>
                    <tr>
                        <th>UserName:</th>
                        <td><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Email:</th>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>Password:</th>
                        <td><asp:TextBox  TextMode ="Password" ID="txtPassword" runat="server"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <th>Confirm Password:</th>
                        <td><asp:TextBox  TextMode ="Password" ID="txtConfirmPassword" runat="server"></asp:TextBox></td>
                    </tr>
                    
                </table>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep3"  runat ="server" Title ="Roles">
                 <div style="font-size :20px; padding-left :20px">
                    User Roles
                 </div>
                <div style="padding-left :15px">
                <asp:CheckBoxList ID="chkRoles"  CssClass="CheckboxList" runat="server"  Height="16px"  >
                </asp:CheckBoxList>
                    </div>
            </asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
       
        </div>
</asp:Content>
