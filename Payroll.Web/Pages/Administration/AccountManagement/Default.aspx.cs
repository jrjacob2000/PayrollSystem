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
            //grdAccounts.RowEditing += grdAccounts_RowEditing;
            grdAccounts.RowCommand += new GridViewCommandEventHandler(grdAccounts_RowCommand);
            lbCreate.Click += lbCreate_Click;

            if (!IsPostBack)
                BindGrid();
        }

        void grdAccounts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int rowindex = Convert.ToInt32(e.CommandArgument);
                string id = grdAccounts.DataKeys[rowindex].Value.ToString();

                Response.Redirect("~/Pages/Administration/AccountManagement/update.aspx?id=" + id);
            }
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
