using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        private BasePage CurrentPage
        {
            get {
                return this.CurrentPage();
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
            this.CurrentPage().PageMessageChanged += CurrentPage_PageMessageChanged;
        }

        void CurrentPage_PageMessageChanged(object sender, EventArgs e)
        {
            if (CurrentPage != null)
                BindMessage();
                

        }

        void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void BindMessage()
        {
            //successMessage
            //lblMessage.Text ="<Span class=\"ui-icon ui-icon-alert\" style=\"float: left; margin-right: .3em;\"></Span>"
                

            switch (CurrentPage.PageMessage.MessageType)
            {
                case MessageType.Succes :
                    lblMessage.Text ="<Span class=\"ui-icon ui-icon-circle-check\" style=\"float: left; margin-right: .3em;\"></Span>";
                    divMessage.Attributes.Add("class", "ui-state-highlight");
                    //divMessage.Attributes.Add("class", "successMessage");                    
                    break;
                case MessageType.Information :
                    lblMessage.Text ="<Span class=\"ui-icon ui-icon-info\" style=\"float: left; margin-right: .3em;\"></Span>";
                    divMessage.Attributes.Add("class", "ui-state-highlight");
                    //divMessage.Attributes.Add("class", "InformationMessage");
                    break;
                case MessageType.Error :
                    lblMessage.Text = "<Span class=\"ui-icon ui-icon-alert\" style=\"float: left; margin-right: .3em;\"></Span>";
                    divMessage.Attributes.Add("class", "ui-state-error style");
                    //divMessage.Attributes.Add("class", "ErrorMessage");
                    break;
            }

            lblMessage.Text = lblMessage.Text +  this.CurrentPage().PageMessage.Message ;

        }
       
    }
}
