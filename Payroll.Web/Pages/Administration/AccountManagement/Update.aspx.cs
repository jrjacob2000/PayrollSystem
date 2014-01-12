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
            btnCancel.Click += btnCancel_Click;
            btnSave.Click += btnSave_Click;
            if (!IsPostBack)
            {
                BindRoles();
                Bind();                
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            DataAccess.Security.DAccountProfile daProfile = new DataAccess.Security.DAccountProfile();
            DataAccess.Security.DAccounts daAccount = new DataAccess.Security.DAccounts();

            var acct = daAccount.Get(Id);


            DataAccess.AccountProfile profileEntity = daProfile.GetAccoutProfileById(acct.ProfileId);

            //Profile
            profileEntity.Id = Guid.NewGuid();
            profileEntity.FirstName = txtFname.Text;
            profileEntity.LastName = txtLname.Text;
            profileEntity.FullName = string.Format("{0} {1}", txtFname.Text, txtLname.Text);
            profileEntity.Title = txtTitle.Text;
            profileEntity.JobTitle = txtJobTitle.Text;
            profileEntity.IsMale = bool.Parse(ddlSex.SelectedValue);
            profileEntity.IsDeleted = false;
                       
            //Roles
            List<string> roleCodes = new List<string>();
            roleCodes = chkRoles.Items.Cast<ListItem>().Where(x => x.Selected).Select(x => x.Value).ToList();
            
            try
            {
                daProfile.UpdateAccountProfile(profileEntity);
                daAccount.AddRoles(Id, roleCodes);
                SetMessage(MessageType.Succes, "Saving Successfull", true);
            }
            catch (System.Transactions.TransactionAbortedException ex)
            {
                SetMessage(MessageType.Error, ex.Message);
            }
            catch (Exception ex)
            {
                SetMessage(MessageType.Error, ex.Message);
            }

            RedirectToReferrerUrl();

            //daProfile.DeleteAccountProfile(profId.Value, false);
            //throw (ex);
                       
                        
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            RedirectToReferrerUrl();
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
            var roleList = data.GetReferenceByType("ROLE");
            

            chkRoles.DataSource = roleList;
            chkRoles.DataTextField = "ReferenceValue";
            chkRoles.DataValueField = "ReferenceCode";
            chkRoles.DataBind();

        }

    }
}
