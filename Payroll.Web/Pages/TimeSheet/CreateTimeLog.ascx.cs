using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Pages.TimeSheet
{
    public partial class CreateTimeLog : System.Web.UI.UserControl
    {
        public string EmployeeId
        {
            get {
                return ViewState["EmployeeId"].ToString();
            }
            set { ViewState["EmployeeId"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
