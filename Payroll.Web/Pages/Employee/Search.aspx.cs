using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Pages.Employee
{
    public partial class Search : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            grdEmployees.RowEditing += grdEmployees_RowEditing;
            grdEmployees.RowDeleting += grdEmployees_RowDeleting;
            if (!IsPostBack)
                Bind();
        }

        void grdEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var item = (Guid)e.Keys["Id"];
            DataAccess.Core.DAEmployee service = new DataAccess.Core.DAEmployee();
            service.Delete(item);
            Bind();
        }
        
        void grdEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gvDetails = (GridView)sender;

            var item = gvDetails.Rows[e.NewEditIndex];
            string id = gvDetails.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect("~/Pages/Employee/update.aspx?id=" + id);//item.Cells[0].Text);
            //DataAccess.Security.DReferences service = new DataAccess.Security.DReferences();
            //service.DeleteReference(item);
        }
            

        void Bind()
        {
            DataAccess.Core.DAEmployee empService = new DataAccess.Core.DAEmployee();
            var data = empService.List();

            grdEmployees.DataSource = data;
            grdEmployees.DataBind();
        }
    }
}
