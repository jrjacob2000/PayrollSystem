using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Pages.TimeSheet
{
    public partial class TimeSheetList : System.Web.UI.UserControl
    {
        public DateTime StartDate { 
            get{
                return (DateTime)ViewState["StartDate"];
            }
            set {
                ViewState["StartDate"] = value;
            }
        }
        public Guid EmployeeId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            grdTimeLog.RowDataBound += grdTimeLog_RowDataBound;
            BindTimeSheet();
        }

        void grdTimeLog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var remarks = e.Row.Cells[3].Text.ToLower();
                if (remarks == "saturday" || remarks == "sunday")
                    e.Row.CssClass = "gridAlternating";
            }
        }

        public void BindTimeSheet()
        {
            DataAccess.Core.DATimeSheet service = new DataAccess.Core.DATimeSheet();
            var startDate = StartDate;
            var endDate = startDate.AddDays(7).Date;
            var data = service.GetListByEmployee(EmployeeId, startDate, endDate);
            grdTimeLog.DataSource = data;
            grdTimeLog.DataBind();
        }
    }
}