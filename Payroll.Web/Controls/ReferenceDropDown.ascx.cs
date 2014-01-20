using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Controls
{
    public partial class ReferenceDropDown : System.Web.UI.UserControl
    {
        public string SelectedValue
        {
            get {
                return ddlReference.SelectedValue;
            }
            set
            {
                ddlReference.SelectedValue = value;
            }
        }
        public bool Required
        {
            get
            {
                if (ViewState["Required"] == null)
                    return false;
                else
                    return (bool)ViewState["Required"];
            }
            set
            {
                ViewState["Required"] = value;
            }
        }

        public string ReferenceType
        {
            get
            {
                if (ViewState["ReferenceType"] != null)
                    return ViewState["ReferenceType"].ToString();
                else
                    return string.Empty;
            }
            set
            {
                ViewState["ReferenceType"] = value;
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            rfvExtended.Enabled = Required;
            ddlReference.CssClass = this.Attributes["CssClass"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Bind();
        }

        void Bind()
        {
            DataAccess.Security.DReferences data = new DataAccess.Security.DReferences();
            var roleList = data.GetReferenceByType(ReferenceType);


            ddlReference.DataSource = roleList;
            ddlReference.DataTextField = "ReferenceValue";
            ddlReference.DataValueField = "ReferenceCode";
            ddlReference.DataBind();

            ddlReference.Items.Insert(0, new ListItem(""));
        }
    }
}