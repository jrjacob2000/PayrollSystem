using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Pages.Administration.ReferenceManagement
{
    public partial class View : BasePage
    {
        private string Id
        {
            get {
                return Request.QueryString["Id"].ToString();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.Click += btnCancel_Click;
            btnEdit.Click += btnEdit_Click;
            if(!IsPostBack)
                InitializeControls();
        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/Pages/Administration/ReferenceManagement/Basic/Update.aspx?id={0}", Id));
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Administration/ReferenceManagement/Basic/Default.aspx");
        }

        public override Operation SecurityContext
        {
            get
            {
                return new Operations.ManageReferencesSecurity();
            }
        }

        private void InitializeControls()
        {
            DataAccess.Security.DReferences refData = new DataAccess.Security.DReferences();

            var refEntity = refData.GetReferenceById(new Guid(this.Id));
            
            //lblRefCode.Text = refEntity.ReferenceCode;
            lblRefCodeValue.Text = refEntity.ReferenceCode;
            lblRefDescValue.Text = refEntity.ReferenceValue;

        }
    }
}
