using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Framework;


namespace System.Web
{
    public class BasePage: System.Web.UI.Page
    {
        public event EventHandler<EventArgs> PageMessageChanged;

        public PageMessage PageMessage
        {
            set {
                if (value.IsPersistent)
                {
                    Session["Message"] = value;
                }
                else
                {
                    ViewState["Message"] = value;
                    if(PageMessageChanged != null)
                        PageMessageChanged(this, EventArgs.Empty);
                }
            }
            get {
                return (PageMessage)ViewState["Message"];
            }
        }

        private void ManagePersistenMessage()
        {
            
            if (Session["Message"] != null)
            {
                var persistentMessage = (PageMessage)Session["Message"]; 
                PageMessage newMessage = new Web.PageMessage();
                newMessage.MessageType = persistentMessage.MessageType;
                newMessage.Message = persistentMessage.Message;
                newMessage.IsPersistent = false;
                Session["Message"] = null;

                this.PageMessage = newMessage;
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (!IsPostBack) PerformSecurityCheck();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                SaveReferrerUrl();
                ManagePersistenMessage();
            }
        } 

        public virtual Operation SecurityContext
        {
            get
            {
                return null;
            }
        }
        private void PerformSecurityCheck()
        {

            if ((!DesignMode) && (!IsRequestAlwaysAllowed()))
            {
                if (RejectedByPermissionProvider() || TryingToAccessUnauthorizedSiteMapNode() || IsDisabledUser())
                {
                    Operator op = this.Operator();

                    //TODO: create authentication error loggin
                    //string message = op == null ? "Unknown user: " + HttpContext.Current.User.Identity.Name : SecurityContext != null ? SecurityContext.Description : string.Empty;
                    //securityService.CreateAuthorizationError(op, op != null ? op.Id : Guid.Empty, null, Request.Url.ToString(), message);

                    HttpContext.Current.Response.Redirect(this.CurrentApplication().unauthorizedUrl);
                }
            }

            
        }

        internal bool IsOperationAuthorized(Operation operation)
        {
            //foreach (IPermissionProvider permissionProvider in this.CurrentApplication().PermissionProviders)
            //{
            //    if (!permissionProvider.IsOperationAuthorized(operation)) return false;
            //}
            return true;
        }

        private bool RejectedByPermissionProvider()
        {

            if (this.CurrentApplication().PermissionProviders != null)
            {
                BasePage currentPage = HttpContext.Current.Handler as BasePage;
                if (currentPage != null)
                {
                    if (!IsOperationAuthorized(currentPage.SecurityContext)) return true;
                }
            }
            return false;
        }

        private bool TryingToAccessUnauthorizedSiteMapNode()
        {
            if (Request.Url.AbsolutePath.ToLower() == System.Web.Security.FormsAuthentication.LoginUrl.ToLower()) return false;
            if (HttpContext.Current.User == null) return false;
            SiteMapNode mainnode = null;
            try
            {
                mainnode = SiteMap.CurrentNode;
            }
            catch
            {
                //no sitemap file
            }
            if (mainnode == null) return false;

            if (mainnode.Roles.Count == 0) return false;

            bool allow = false;
            Operator op = this.Operator();
            foreach (string role in mainnode.Roles)
            {
                if (op.IsInRole(role)) { allow = true; break; }
            }

            return (allow == false);
        }

        private bool IsDisabledUser()
        {
            return this.Operator().IsDisabled;
        }

        private static string[] _authorizedExtensions = new string[] {".axd",".ashx",".jpg",".gif",".css",".js" };
        private bool IsRequestAlwaysAllowed()
        {
            string path = HttpContext.Current.Request.Url.AbsolutePath.ToLower();
            return _authorizedExtensions.Any(x => path.EndsWith(x));
        }

        protected void SetMessage(MessageType messageType, string message)
        {
            SetMessage(messageType, message, false);
            
        }

        protected void SetMessage(MessageType messageType, string message, bool isPersistent)
        {
            PageMessage msg = new PageMessage();
            msg.IsPersistent = isPersistent;
            msg.MessageType = messageType;
            msg.Message = message;

            PageMessage = msg;
        }

        private void SaveReferrerUrl()
        {
            if (Request.UrlReferrer != null)
            {
                ReferrerUrl = Request.UrlReferrer.ToString();
            }
        }

        protected void RedirectToReferrerUrl()
        {
            Response.Redirect(ReferrerUrl, false);
        }

        protected string ReferrerUrl
        {
            get { return GetProperty<string>("ReferrerUrl", string.Empty); }
            private set { SetProperty("ReferrerUrl", value); }
        }

        protected T GetProperty<T>(string propertyName, T defaultValue)
        {
            if (ViewState[propertyName] == null)
            {
                return defaultValue;
            }
            return (T)ViewState[propertyName];
        }

        protected T GetProperty<T>(string propertyName)
        {
            return GetProperty<T>(propertyName, default(T));
        }

        protected void SetProperty(string propertyName, object value)
        {
            ViewState[propertyName] = value;
        }
    }

    public enum MessageType
    {
        Information,
        Error,
        Succes
    }

    [Serializable]
    public class PageMessage
    {
        public MessageType MessageType
        { get; set; }
        public string Message
        { get; set; }
        public bool IsPersistent
        { get; set; }
    }
}
