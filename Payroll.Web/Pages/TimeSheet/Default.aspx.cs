using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Pages.TimeSheet
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            btnGo.ServerClick += btnGo_ServerClick;
            ddlEmployee.SelectedIndexChanged += ddlEmployee_SelectedIndexChanged;
            if (!IsPostBack)
            {
                
                BindEmployee();
                dialogTimeSheet.EmployeeId = ddlEmployee.SelectedValue;
                BindTimeSheet();
                
            }
        }

        void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            dialogTimeSheet.EmployeeId = ddlEmployee.SelectedValue;
            BindTimeSheet();
        }

        void btnGo_ServerClick(object sender, EventArgs e)
        {
            BindTimeSheet();
        }

        void BindTimeSheet()
        {
            DataAccess.Core.DATimeSheet service = new DataAccess.Core.DATimeSheet();
            var startDate = DateTime.Now.GetFirstDayOfWeek().Date;
            var endDate = startDate.AddDays(7).Date;
            var data = service.GetListByEmployee(new Guid(ddlEmployee.SelectedValue), startDate, endDate);
            grdTimeLog.DataSource = data;
            grdTimeLog.DataBind();
        }

        void BindEmployee()
        {
            DataAccess.Core.DAEmployee  service = new DataAccess.Core.DAEmployee();
            var data = service.List().Select(x =>
                new {Name = string.Format("{0}, {1}",x.LastName,x.FirstName), id = x.Id   }).ToList();
            ddlEmployee.DataSource = data;
            ddlEmployee.DataTextField = "Name";
            ddlEmployee.DataValueField = "Id";
            ddlEmployee.DataBind();
        }
    }
}
