using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Payroll.Web.Pages.Administration.AccountManagement
{
    public partial class Create : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            wzdAccount.FinishButtonClick += wzdAccount_FinishButtonClick;
            wzdAccount.CancelButtonClick += wzdAccount_CancelButtonClick;

            if (!IsPostBack)
                BindRoles();
        }

        void wzdAccount_CancelButtonClick(object sender, EventArgs e)
        {
            RedirectToReferrerUrl();
        }

        void wzdAccount_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            DataAccess.Security.DAccountProfile daProfile = new DataAccess.Security.DAccountProfile();
            DataAccess.Security.DAccounts daAccount = new DataAccess.Security.DAccounts();
            

            DataAccess.AccountProfile profileEntity = new DataAccess.AccountProfile();

            //Profile
            profileEntity.Id = Guid.NewGuid();
            profileEntity.FirstName = txtFname.Text;
            profileEntity.LastName = txtLname.Text;
            profileEntity.FirstName = string.Format("{0} {1}", txtFname.Text, txtLname.Text);
            profileEntity.Title = txtTitle.Text;
            profileEntity.JobTitle = txtJobTitle.Text;
            profileEntity.IsMale = bool.Parse(ddlSex.SelectedValue);
            profileEntity.IsDeleted = false;


            //Account
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                return;
            }
            DataAccess.Account acctEntity = new DataAccess.Account();
            acctEntity.Id = Guid.NewGuid();
            acctEntity.UserName = txtUserName.Text;
            acctEntity.Email = txtEmail.Text;
            acctEntity.Password = txtConfirmPassword.Text;
            acctEntity.IsDeleted = false;
            acctEntity.ChangePasswordOnFirstLogon = true;
            acctEntity.CreatedDate = DateTime.Now;

            
            //Roles
            List<string> roleCode = new List<string>();
            roleCode = chkRoles.Items.Cast<ListItem>().Where(x => x.Selected).Select(x => x.Value).ToList();


                try
                {
                    daProfile.CreateAccountProfile(profileEntity);
                    acctEntity.ProfileId = profileEntity.Id;
                    daAccount.CreateAccount(acctEntity);
                    daAccount.AddRoles(acctEntity.Id, roleCode);
                    SetMessage(MessageType.Succes, "Saving Successfull",true);
                }
                catch (System.Transactions.TransactionAbortedException ex)
                {
                    SetMessage(MessageType.Error, ex.Message,true);
                }
                catch (Exception ex)
                {
                    SetMessage(MessageType.Error, ex.Message, true);
                }

                RedirectToReferrerUrl();

            //daProfile.DeleteAccountProfile(profId.Value, false);
            //throw (ex);
                       
                        
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
