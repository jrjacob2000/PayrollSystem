using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Controls
{
    public partial class ExtendedTextBox : System.Web.UI.UserControl
    {
        public string Text
        {
            get
            {
                return txtExtended.Text;
            }
            set
            {
                txtExtended.Text = value;
            }
        }
        public bool Required
        {
            get
            {
                if (ViewState["Required"] == null)
                    return false;
                else
                    return (bool)ViewState["Required"];
            }
            set
            {
                ViewState["Required"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            rfvExtended.Enabled = Required;
            txtExtended.CssClass = this.Attributes["CssClass"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

      

    }
}