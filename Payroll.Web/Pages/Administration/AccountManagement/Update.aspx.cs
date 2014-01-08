using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Pages.Administration.AccountManagement
{
    public partial class Update : System.Web.UI.Page
    {
        private string Id
        {
            get
            {
                return Request.QueryString["Id"].ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}