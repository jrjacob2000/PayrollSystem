using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Payroll.Web.Controls
{
    [ToolboxData("<{0}:ExtendedGridview runat=server></{0}:ExtendedGridview>")]
    public class ExtendedGridview : GridView
    {
        public ExtendedGridview():base()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.RowDataBound += ExtendedGridview_RowDataBound;
            //jquery ui class
            this.CssClass = "ui-state-default";
            this.Attributes.Add("Style", "Width:100%");
        }

        void ExtendedGridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.CssClass = "gridHeader";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.RowState == DataControlRowState.Alternate)
                    e.Row.CssClass = "gridAlternating";

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
                            button.ToolTip = "Edit";
                            button.Attributes.Add("icon", "ui-icon-pencil");
                            button.Attributes.Add("Style", "display: inline-block;");
                        }

                        if (button != null && button.CommandName == "Delete")
                        {
                            // Add delete confirmation
                            button.OnClientClick = "if (!confirm('Are you sure " +
                                   "you want to delete this record?')) return;";
                            button.CssClass = "ui-icon ui-icon-close";
                            button.ToolTip = "Delete";
                            button.Attributes.Add("Style", "display: inline-block");
                        }
                    }
                }
            }
        }
    }
}