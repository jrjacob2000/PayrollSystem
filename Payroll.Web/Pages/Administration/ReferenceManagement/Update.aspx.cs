using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Pages.Administration.ReferenceManagement
{
    public partial class Update : BasePage
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
            btnSave.Click += btnSave_Click;
            if(!IsPostBack)
                InitializeControls();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Security.DReferences refData = new DataAccess.Security.DReferences();
                var refEntity = refData.GetReferenceById(new Guid(this.Id));

                refEntity.ReferenceValue = txtDesc.Text;
                refData.UpdateReference(refEntity);

                SetMessage(MessageType.Succes, "Saving successful", true);
                Response.Redirect("~/Pages/Administration/ReferenceManagement/Default.aspx",false);
            }
            catch (Exception ex)
            {
                SetMessage(MessageType.Error, "Saving Fail", true);
                Response.Redirect("~/Pages/Administration/ReferenceManagement/Default.aspx",false);
            }
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Administration/ReferenceManagement/Default.aspx");
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

            txtCode.Text = refEntity.ReferenceCode;
            txtDesc.Text = refEntity.ReferenceValue;

        }
    }
}
