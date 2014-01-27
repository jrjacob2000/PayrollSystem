using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll.Web
{

    public abstract class BaseApplication : HttpApplication
    {
        public List<IPermissionProvider> PermissionProviders = new List<IPermissionProvider>();
        public string unauthorizedUrl = String.Empty;
        public string loginUrl = String.Empty;

        protected abstract List<IPermissionProvider> GetPermissionProviders();
        protected abstract string UnauthorizedUrl { get; }
        protected abstract string LoginUrl { get; }
        public abstract INavigationProvider NavigationProvider { get; }
        public abstract string ApplicationCode { get; }

        public override void Init()
        {
            base.Init();

            this.PermissionProviders = GetPermissionProviders();
            this.unauthorizedUrl = UnauthorizedUrl;
            this.loginUrl = LoginUrl; 

            //this.PostMapRequestHandler += new EventHandler(SGSReferenceApplication_PostMapRequestHandler);
        }

        //void SGSReferenceApplication_PostMapRequestHandler(object sender, EventArgs e)
        //{
        //    Page current = HttpContext.Current.Handler as Page;
        //    if (current != null)
        //    {
        //        SGSReferencePage page = this.CurrentPage();

        //        if (page == null)
        //        {
        //            if (Server.MapPath(this.Context.Request.Path) != Server.MapPath(UnauthorizedUrl))
        //            {
        //                throw new ApplicationException("All pages must inherit from SGSReference.Web.SGSReferencePage");
        //            }
        //        }
        //    }
        //}

        protected void HistorizeLogin()
        {
            string IPAddress = Request.UserHostAddress;
            string userName = HttpContext.Current.User.Identity.Name;

            //var securityService = new SGSReference.Services.SecurityService();

            //securityService.HistorizeLogin(userName, IPAddress);
        }
    }
}