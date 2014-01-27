using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Payroll.DataAccess;

namespace Payroll.Web.Pages.Administration.ReferenceManagement
{
    public partial class Default : BasePage
    {
        List<Reference> _data;
        private List<Reference> Data
        {
            get {
                if (_data == null)
                {
                    _data = new DataAccess.Security.DReferences().GetReferenceList();
                    return _data;
                }
                else
                    return _data;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNewReference.ServerClick += new EventHandler(btnNewReference_ServerClick);
            repAccordion.ItemDataBound += new RepeaterItemEventHandler(repAccordion_ItemDataBound);

            if (!IsPostBack)
            {
                
            }
            Bind();
        }

        void repAccordion_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string refTypeCode = ((Payroll.DataAccess.Entity.ReferenceType)(e.Item.DataItem)).ReferenceTypeCode;

                GridView gvDetails = e.Item.FindControl("gvDetails") as GridView;
                gvDetails.DataSource = Data.Where(x => x.ReferenceTypeCode.ToLower() == refTypeCode.ToLower());
                gvDetails.DataBind();
            }
        }

        
        void btnNewReference_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Administration/ReferenceManagement/Basic/Create.aspx?reftypecode=ROLE");
        }
               

        public override Operation SecurityContext
        {
            get
            {
                return new Operations.ManageReferencesSecurity();
            }
        }

        private void Bind()
        {
            var dataTypes = new DataAccess.Security.DReferences().GetReferenceTypeList();

            repAccordion.DataSource = dataTypes;
            repAccordion.DataBind();
        }

        protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var item = (Guid)e.Keys["Id"];
            DataAccess.Security.DReferences service = new DataAccess.Security.DReferences();
            service.DeleteReference(item);
            Response.Redirect("~/Pages/Administration/ReferenceManagement/Basic/Default.aspx");
        }



        protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView gvDetails = (GridView)sender;

            var item = gvDetails.Rows[e.NewEditIndex];
            Response.Redirect("~/Pages/Administration/ReferenceManagement/Basic/update.aspx?id=" + item.Cells[0].Text);
            //DataAccess.Security.DReferences service = new DataAccess.Security.DReferences();
            //service.DeleteReference(item);
        }

        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
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
    }
}
