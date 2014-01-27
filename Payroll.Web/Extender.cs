using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll.Web
{
    public static class Extender
    {
        public static BaseApplication CurrentApplication(this object item)
        {
            return HttpContext.Current.ApplicationInstance as BaseApplication;
        }

        public static BasePage CurrentPage(this object item)
        {
            return HttpContext.Current.Handler as BasePage;
        }

        public static Operator Operator(this object item)
        {
            Operator result = null;
            if (HttpContext.Current.Items["Operator"] == null)
            {
                if (HttpContext.Current.User != null)
                {

                    var security = new Payroll.DataAccess.Security.DAccounts();

                    result = security.GetOperator(HttpContext.Current.User.Identity.Name);
                                      

                    if (result != null) HttpContext.Current.Items["Operator"] = result;
                    return result;
                }
                return null;
            }
            return HttpContext.Current.Items["Operator"] as Operator;
        }

    }
}