using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Payroll.Web;

namespace Payroll.Web.WebServices
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class PayrollWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string CreateAddress(CreateAddressRequest request)
        {
            try
            {
                DataAccess.Core.DAEmployee service = new DataAccess.Core.DAEmployee();

                DataAccess.EmployeeAddress addr = new DataAccess.EmployeeAddress();
                addr.Id = Guid.NewGuid();
                addr.EmployeeId = new Guid("7601C88B-D5D3-47FC-8F6A-0AA1C5DBDECF");//change this with real employeeId
                addr.Address = request.address;
                addr.CityMun = request.cityMun;
                addr.ProvState = request.provState;
                //addr.CountryCode = request.country;
                addr.AddressTypeCode = "Permanent";

                service.CreateAddress(addr);


                FormlessPage page = new FormlessPage();

                var ctrl = (Payroll.Web.Pages.Employee.Address.AddressGrid)page.LoadControl("~/Pages/Employee/Address/AddressGrid.ascx");

                //HtmlForm form = new HtmlForm();

                ////Add user control to the form
                //form.Controls.Add(ctrl);

                page.Controls.Add(ctrl);

                return page.RenderPage();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

    public class CreateAddressRequest
    {
        public string address{get;set;}
        public string cityMun { get; set; }
        public string provState { get; set; }
        //public string country { get; set; }
        public string zipcode { get; set; }
                   
    }
}
