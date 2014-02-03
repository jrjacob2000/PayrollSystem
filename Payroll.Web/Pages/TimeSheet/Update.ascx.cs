using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Pages.TimeSheet
{
    public partial class Update : System.Web.UI.UserControl
    {
        public string EmployeeId{ get; set; }

        public string Id { get; set; }

        public DateTime ReportedDate{ get; set; }

        public DateTime? DateTimeIn{ get; set; }

        public DateTime? DateTimeOut{ get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            InitializedControl(); 
            Bind();

            //string dateTimeIn = string.Format("$(#{0}).val() + ' ' + $(#{2}).val()",TxtDateIn.ClientID,TxtTimeIn.ClientID);
            string dataTimeOut = TxtDateOut.Value + ' ' + txtTimeOut.Value;
            btnSave.Attributes.Add("onclick", string.Format("Save('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", this.Id, this.EmployeeId, this.ReportedDate, TxtDateIn.ClientID, TxtDateOut.ClientID, TxtTimeIn.ClientID, txtTimeOut.ClientID));
        }

        void btnSave_ServerClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void InitializedControl()
        {
            txtDate.Value = string.Empty;
            TxtDateIn.Value = string.Empty;
            TxtTimeIn.Value =  string.Empty;
            TxtDateOut.Value =string.Empty;
            txtTimeOut.Value = string.Empty;

        }

        void Bind()
        {
            hiddenEmployeeId.Value = EmployeeId;
            hiddenId.Value = Id;

            txtDate.Value = ReportedDate.ToShortDateString();
            TxtDateIn.Value = ReportedDate.ToShortDateString();
            TxtDateOut.Value = ReportedDate.ToShortDateString();

            if (DateTimeIn.HasValue)
            {
                TxtDateIn.Value = DateTimeIn.Value.ToShortDateString();
                TxtTimeIn.Value = DateTimeIn.Value.ToShortTimeString();
            }
            

            if (DateTimeOut.HasValue)
            {
                TxtDateOut.Value = DateTimeOut.Value.ToShortDateString();
                txtTimeOut.Value = DateTimeOut.Value.ToShortTimeString();
            }
            
        }
    }
}