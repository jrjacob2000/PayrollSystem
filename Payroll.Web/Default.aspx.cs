using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Pages
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public override Operation SecurityContext
        {
            get
            {
                return new Operations.ViewHome();
            }
        }
    }
}