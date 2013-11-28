using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Payroll.Web.Pages.Public
{
    public partial class Login :BasePage 
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            btn_Logon.Click += btn_Logon_Click;
        }

        void btn_Logon_Click(object sender, EventArgs e)
        {
            var security = new DataAccess.Security.DAccounts();
            if(security.ValidateAccount(UserName.Text,Password.Text))
            {
                FormsAuthentication.RedirectFromLoginPage
                   (UserName.Text, RememberMe.Checked);
            }
            else
            {
                FailureText.Text = "Invalid credentials. Please try again.";
            }
        }
    }
}