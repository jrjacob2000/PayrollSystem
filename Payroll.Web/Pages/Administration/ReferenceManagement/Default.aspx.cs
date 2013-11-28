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
            var refList = new DataAccess.Security.DReferences().GetReferenceList();

            grdRoles.DataSource = refList.OrderBy(x => x.ReferenceTypeCode); ;
            grdRoles.DataBind();
        }

        protected void grdRoles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var item = (Guid)e.Keys["Id"];
            DataAccess.Security.DReferences service = new DataAccess.Security.DReferences();
            service.DeleteReference(item);
            Bind();
        }
    }
}