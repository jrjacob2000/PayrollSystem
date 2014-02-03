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
        protected DateTime StartDate
        {
            get {
                if (ViewState["StartDate"] == null)
                    return DateTime.Now.GetFirstDayOfWeek().Date.AddDays(1);
                else
                    return (DateTime)ViewState["StartDate"];
            }
            set {
                ViewState["StartDate"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            btnGo.ServerClick += btnGo_ServerClick;
            ddlEmployee.SelectedIndexChanged += ddlEmployee_SelectedIndexChanged;
            //grdTimeLog.RowDataBound += new GridViewRowEventHandler(grdTimeLog_RowDataBound);
            btnNext.ServerClick += new EventHandler(btnNext_ServerClick);
            btnPrev.ServerClick += new EventHandler(btnPrev_ServerClick);

            if (!IsPostBack)
            {
                BindEmployee();
                grdTimeSheet.EmployeeId = new Guid(ddlEmployee.SelectedValue);
                BindTimeSheet();
                
            }
        }

        void btnPrev_ServerClick(object sender, EventArgs e)
        {
            StartDate = StartDate.AddDays(-7).Date;
            BindTimeSheet();
        }

        void btnNext_ServerClick(object sender, EventArgs e)
        {
            StartDate = StartDate.AddDays(7).Date;
            BindTimeSheet();
        }

       
       
        void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTimeSheet();
        }

        void btnGo_ServerClick(object sender, EventArgs e)
        {
            
            BindTimeSheet();
        }

        void BindTimeSheet()
        {
            grdTimeSheet.EmployeeId = new Guid(ddlEmployee.SelectedValue);
            grdTimeSheet.StartDate = StartDate;
            grdTimeSheet.BindTimeSheet();

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
