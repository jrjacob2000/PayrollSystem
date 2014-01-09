using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Pages.Administration.AccountManagement
{
    public partial class Update : BasePage
    {
        private Guid Id
        {
            get
            {
                return new Guid(Request.QueryString["Id"].ToString());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRoles();
                Bind();                
            }
        }

        private void Bind()
        {
            DataAccess.Security.DAccountProfile daProfile = new DataAccess.Security.DAccountProfile();
            DataAccess.Security.DAccounts daAccount = new DataAccess.Security.DAccounts();

            var acct = daAccount.Get(Id);            

            DataAccess.AccountProfile profileEntity = daProfile.GetAccoutProfileById(acct.ProfileId);
            txtTitle.Text = profileEntity.Title;
            txtFname.Text = profileEntity.FirstName;
            txtLname.Text = profileEntity.LastName;
            txtJobTitle.Text = profileEntity.JobTitle;
            ddlSex.SelectedValue = profileEntity.IsMale.ToString().ToLower();

            lblUserName.Text = acct.UserName;
            lblEmail.Text = acct.Email;

            var roles = daAccount.GetRoles(Id);

           
            foreach (ListItem item in chkRoles.Items)
            {
                item.Selected = roles.Select(x => x.Code).ToList().Contains(item.Value);
                                
            }
            
        }

        void BindRoles()
        {
            DataAccess.Security.DReferences data = new DataAccess.Security.DReferences();
            var roleList = data.GetReferenceList().Where(x => x.ReferenceTypeCode == "ROLE" && (x.IsDeleted.HasValue ? x.IsDeleted.Value : false) == false);

            chkRoles.DataSource = roleList;
            chkRoles.DataTextField = "ReferenceValue";
            chkRoles.DataValueField = "ReferenceCode";
            chkRoles.DataBind();

        }

    }
}
