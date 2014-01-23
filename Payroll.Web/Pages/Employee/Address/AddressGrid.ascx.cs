using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Pages.Employee.Address
{
    public partial class AddressGrid : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            bind();
        }

        void bind()
        {
            DataAccess.Core.DAEmployee service = new DataAccess.Core.DAEmployee();
            var data = service.GetAddressList();
            grdAddress.DataSource = data;
            grdAddress.DataBind();

        }
    }
}
