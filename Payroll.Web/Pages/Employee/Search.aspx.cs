using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Pages.Employee
{
    public partial class Search : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            grdEmployees.RowDataBound += grdEmployees_RowDataBound;
            grdEmployees.RowEditing += grdEmployees_RowEditing;
            grdEmployees.RowDeleting += grdEmployees_RowDeleting;
            if (!IsPostBack)
                Bind();
        }

        void grdEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var item = (Guid)e.Keys["Id"];
            DataAccess.Core.DAEmployee service = new DataAccess.Core.DAEmployee();
            service.Delete(item);
            Bind();
        }
        
        void grdEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gvDetails = (GridView)sender;

            var item = gvDetails.Rows[e.NewEditIndex];
            string id = gvDetails.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect("~/Pages/Employee/update.aspx?id=" + id);//item.Cells[0].Text);
            //DataAccess.Security.DReferences service = new DataAccess.Security.DReferences();
            //service.DeleteReference(item);
        }

        void grdEmployees_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // loop all data rows
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    // check all cells in one row
                    foreach (Control control in cell.Controls)
                    {
                        
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

        void Bind()
        {
            DataAccess.Core.DAEmployee empService = new DataAccess.Core.DAEmployee();
            var data = empService.List();

            grdEmployees.DataSource = data;
            grdEmployees.DataBind();
        }
    }
}