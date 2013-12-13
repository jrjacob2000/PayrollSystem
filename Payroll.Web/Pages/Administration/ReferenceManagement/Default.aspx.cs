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
            lbCreate.Click += lbCreate_Click;

            if (!IsPostBack)
            {
                Bind();
            }
        }

        void lbCreate_Click(object sender, EventArgs e)
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

            grdReference.DataSource = dataTypes;
            grdReference.DataBind();
        }

        protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var item = (Guid)e.Keys["Id"];
            DataAccess.Security.DReferences service = new DataAccess.Security.DReferences();
            service.DeleteReference(item);
            Bind();
        }

        protected void grdReference_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string refTypeCode = grdReference.DataKeys[e.Row.RowIndex].Value.ToString();

                GridView gvDetails = e.Row.FindControl("gvDetails") as GridView;
                gvDetails.DataSource = Data.Where(x => x.ReferenceTypeCode == refTypeCode);
                gvDetails.DataBind();
            }
        }

        protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView gvDetails = (GridView)sender;

            var item = gvDetails.Rows[e.NewEditIndex];
            Response.Redirect("~/Pages/Administration/ReferenceManagement/Create.aspx?id=" + item.Cells[0].Text);
            //DataAccess.Security.DReferences service = new DataAccess.Security.DReferences();
            //service.DeleteReference(item);
            Bind();
        }
    }
}