<%@ Page Title ="Login" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Payroll.Web.Pages.Public.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="~/Styles/site.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <div style="border:solid; border-width :2px; border-radius:10px; width :300px; margin:100px auto;">
        <div style="padding-bottom :10px; border-bottom :solid ; border-width :2px; height:20px">
            <h2 style="padding :10px; margin :0">Login</h2>
        </div>
        <div style=" padding-left :20px;padding-bottom :20px; padding-right :20px;">
          <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <fieldset>
                    <legend>Log in Form</legend>
                    <ol>
                        <li>
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="UserName">User name</asp:Label>
                            <asp:TextBox runat="server" ID="UserName" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                        </li>
                        <li>
                            <asp:Label ID="Label2" runat="server" AssociatedControlID="Password">Password</asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="The password field is required." />
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="RememberMe" />
                            <asp:Label ID="Label3" runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Remember me?</asp:Label>
                        </li>
                    </ol>
                    <div style ="text-align :right ">
                    <asp:Button  ID="btn_Logon" runat="server" CommandName="Login" Text="Log in" />
                        </div>
                </fieldset>
        </div>
    </div>
    </form>
</body>
</html>

