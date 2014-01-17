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
                string refTypeCode = ((Payroll.DataAccess.ReferenceType)(e.Item.DataItem)).ReferenceTypeCode;

                GridView gvDetails = e.Item.FindControl("gvDetails") as GridView;
                gvDetails.DataSource = Data.Where(x => x.ReferenceTypeCode.ToLower() == refTypeCode.ToLower());
                gvDetails.DataBind();
            }
        }

        
        void btnNewReference_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Administration/ReferenceManagement/Create.aspx?reftypecode=ROLE");
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
            Bind();
        }



        protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView gvDetails = (GridView)sender;

            var item = gvDetails.Rows[e.NewEditIndex];
            Response.Redirect("~/Pages/Administration/ReferenceManagement/update.aspx?id=" + item.Cells[0].Text);
            //DataAccess.Security.DReferences service = new DataAccess.Security.DReferences();
            //service.DeleteReference(item);
            Bind();
        }
    }
}
