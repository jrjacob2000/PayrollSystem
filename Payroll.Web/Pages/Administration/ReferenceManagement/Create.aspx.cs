using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Payroll.DataAccess;

namespace Payroll.Web.Pages.Administration.ReferenceManagement
{
    public partial class Create : BasePage
    {
        private string ReferenceTypeCode
        {            
            get { 
                var refTypeCode = Request.QueryString["reftypecode"];
                if (refTypeCode != null)
                    return refTypeCode.ToString();
                else
                    return 
                        null;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.Click += btnCancel_Click;
            btnSave.Click += btnSave_Click;

            if (!IsPostBack)
                InitializeControl();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var entity = new Payroll.DataAccess.Reference();
                entity.Id = Guid.NewGuid();
                entity.ReferenceTypeCode = ddlReferenceType.SelectedValue.ToUpper().Replace(" ", "");//this.ReferenceTypeCode.ToUpper().Replace(" ","");
                entity.ReferenceCode = txtRoleCode.Text.ToUpper().Replace(" ", ""); ;
                entity.ReferenceValue = txtRoleDesc.Text;

                Payroll.DataAccess.Security.DReferences service = new DataAccess.Security.DReferences();
                service.CreateReference(entity);

                SetMessage(MessageType.Succes, "Save successfull.",true);
                Response.Redirect("~/Pages/Administration/ReferenceManagement/Default.aspx");
            }
            catch (Exception ex)
            {
                SetMessage(MessageType.Error, ex.Message);
            }
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Administration/ReferenceManagement/Default.aspx");
        }

        void InitializeControl()
        {
            //var data = RerenceTypeList.Where(x => x.ReferenceTypeCode == "REFERENCE_TYPE").Select(x => new ListItem(x.ReferenceValue, x.ReferenceCode)).ToList();
            ddlReferenceType.DataSource = RerenceTypeList;
            ddlReferenceType.DataTextField = "Description";
            ddlReferenceType.DataValueField = "ReferenceTypeCode";
            ddlReferenceType.DataBind();

            ddlReferenceType.Items.Insert(0,new ListItem("",""));
        }

        List<DataAccess.Entity.ReferenceType> RerenceTypeList
        {
            get { 
                Payroll.DataAccess.Security.DReferences service = new DataAccess.Security.DReferences();
                return service.GetReferenceTypeList();
            }
        }
    }
}
