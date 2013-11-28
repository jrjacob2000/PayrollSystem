using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Pages.Administration.AccountManagement
{
    public partial class Default :BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbCreate.Click += lbCreate_Click;

            if (!IsPostBack)
                BindGrid();
        }

        void lbCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Administration/AccountManagement/Create.aspx");
        }

        void BindGrid()
        {
            DataAccess.Security.DAccounts daAccount = new DataAccess.Security.DAccounts();
            grdAccounts.DataSource = daAccount.List();
            grdAccounts.DataBind();
        }

    }
}