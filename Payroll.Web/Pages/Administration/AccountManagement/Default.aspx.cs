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
            grdAccounts.RowDeleting += new GridViewDeleteEventHandler(grdAccounts_RowDeleting);
            grdAccounts.RowCommand += new GridViewCommandEventHandler(grdAccounts_RowCommand);
            btnNewAccount.ServerClick += new EventHandler(btnNewAccount_ServerClick);

            if (!IsPostBack)
                BindGrid();
        }

 
        void btnNewAccount_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Administration/AccountManagement/Create.aspx");
        }


        void grdAccounts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {           
        }

        void grdAccounts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int rowindex = Convert.ToInt32(e.CommandArgument);
                string id = grdAccounts.DataKeys[rowindex].Value.ToString();
         

                Response.Redirect("~/Pages/Administration/AccountManagement/update.aspx?id=" + id);
            }
            else if (e.CommandName == "Delete")
            {
                int rowindex = Convert.ToInt32(e.CommandArgument);
                Guid id = new Guid( grdAccounts.DataKeys[rowindex].Value.ToString());

                DataAccess.Security.DAccounts daAccount = new DataAccess.Security.DAccounts();
                daAccount.DeleteAccount(id);

                var acct = daAccount.Get(id);

                SetMessage(MessageType.Succes, string.Format("<b>{0}</b> was deleted successfully", acct.UserName));
                BindGrid();
            }
        }

        void BindGrid()
        {
            DataAccess.Security.DAccounts daAccount = new DataAccess.Security.DAccounts();
            grdAccounts.DataSource = daAccount.List();
            grdAccounts.DataBind();
        }

    }
}
