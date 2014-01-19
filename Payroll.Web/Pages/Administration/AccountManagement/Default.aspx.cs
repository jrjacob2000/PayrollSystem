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
            grdAccounts.RowDataBound += grdAccounts_RowDataBound;
           // btnCreate.Click += new EventHandler(btnCreate_Click);
            btnNewAccount.ServerClick += new EventHandler(btnNewAccount_ServerClick);

            if (!IsPostBack)
                BindGrid();
        }

        void grdAccounts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // loop all data rows
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    // check all cells in one row
                    foreach (Control control in cell.Controls)
                    {
                        // Must use LinkButton here instead of ImageButton
                        // if you are having Links (not images) as the command button.

                        ImageButton button = control as ImageButton;

                        if (button != null && button.CommandName == "Edit")
                        {
                            button.CssClass = "ui-icon ui-icon-pencil";
                            //button.CssClass = "editButton";
                            button.ToolTip = "Edit";
                            button.Attributes.Add("icon", "ui-icon-pencil");

                            //if(e.Row.RowState == DataControlRowState.Alternate )
                            //    button.Attributes.Add("Style", "display: inline-block ;border-color:none ; background-color:#CCCCFF;");
                            //else
                            button.Attributes.Add("Style", "display: inline-block;");


                        }


                        if (button != null && button.CommandName == "Delete")
                        {
                            // Add delete confirmation
                            button.OnClientClick = "if (!confirm('Are you sure " +
                                   "you want to delete this record?')) return;";
                            button.CssClass = "ui-icon ui-icon-close";
                            button.ToolTip = "Delete";
                            //if (e.Row.RowState == DataControlRowState.Alternate)
                            //    button.Attributes.Add("Style", "display: inline-block; background-color:#CCCCFF;border-color:none");
                            //else
                            button.Attributes.Add("Style", "display: inline-block");

                        }
                    }
                }
            }
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
