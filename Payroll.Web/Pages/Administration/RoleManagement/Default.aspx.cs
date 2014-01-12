using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Pages.Administration.RoleManagement
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlRole.SelectedIndexChanged += ddlRole_SelectedIndexChanged;
            btnSave.Click += btnSave_Click;
 
            if (!IsPostBack)
            {
                InitializeControls();
                Bind();
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Security.DAccounts daAccount = new DataAccess.Security.DAccounts();

                daAccount.DeletePrivileges(ddlRole.SelectedValue); 

                foreach (ListItem item in chkOperation.Items)
                {
                    if (item.Selected)
                        daAccount.AddPrivilege(item.Value, ddlRole.SelectedValue);
                }
                SetMessage(MessageType.Succes, "Saving Success");
            }
            catch(Exception ex)
            {
                SetMessage(MessageType.Error, string.Format("Saving Faile: {0}",ex.Message));
            }
        }

 

        void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind();
        }

        void InitializeControls()
        {
            DataAccess.Security.DReferences data = new DataAccess.Security.DReferences();
            var roleList = data.GetReferenceByType("ROLE");

            ddlRole.DataSource = roleList;
            ddlRole.DataTextField = "ReferenceValue";
            ddlRole.DataValueField = "ReferenceCode";
            ddlRole.DataBind();

            var operations = data.GetReferenceByType("Operation");

            chkOperation.DataSource = operations;
            chkOperation.DataTextField = "ReferenceValue";
            chkOperation.DataValueField = "ReferenceCode";
            chkOperation.DataBind();

        }

        void Bind()
        {
            DataAccess.Security.DAccounts daAccount = new DataAccess.Security.DAccounts();
            chkOperation.ClearSelection();

            var userOpertion = daAccount.GetPrivileges(ddlRole.SelectedValue);
            foreach (ListItem item in chkOperation.Items)
            {
                item.Selected = userOpertion.Select(x => x.Code).ToList().Contains(item.Value);
            }
        }
    }
}