using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Pages.Administration.ReferenceManagement.TaxTable
{
    public partial class Create : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Click += btnSave_Click;
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            DataAccess.Core.DATaxTable service = new DataAccess.Core.DATaxTable();
            
            DataAccess.TaxTable tax = new DataAccess.TaxTable();
            tax.TaxCode = txtTaxCode.Text;
            tax.Description = txtDescription.Text;
            tax.Exemption = int.Parse( txtExcemption.Text);

            service.Create(tax);

            SetMessage(MessageType.Succes,"Saving Successful");
        }
    }
}