using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Payroll.Web
{
    public class Global : BaseApplication
    {

        protected override List<IPermissionProvider> GetPermissionProviders()
        {
            List<IPermissionProvider> result = new List<IPermissionProvider>();
            result.Add(new PermissionProvider());
            return result;
        }

        public override INavigationProvider NavigationProvider
        {
            get {
                return new NavigationProvider();
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected override string UnauthorizedUrl
        {
            get { 
                return "~/Pages/Public/UnAuthorized.aspx";  
            }
        }

        protected override string LoginUrl
        {
            get { return "~/Pages/Public/Login.aspx"; }
        }

        public override string ApplicationCode
        {
            get { return "ParollSystem"; }
        }
    }
}