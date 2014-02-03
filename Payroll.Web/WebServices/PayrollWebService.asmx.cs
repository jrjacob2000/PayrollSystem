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
        public string CreateTimeSheet(TimeSheetRequest request)
        {
            DataAccess.Core.DATimeSheet service = new DataAccess.Core.DATimeSheet();
            DataAccess.EmployeeTimeSheet entity = new DataAccess.EmployeeTimeSheet();
            entity.Id = Guid.NewGuid();
            entity.EmployeeId = new Guid(request.EmpId);
            entity.ReportedDate = DateTime.Parse( request.Date );
            entity.DateTimeIn = DateTime.Parse(request.DateTimeIn);
            entity.DateTimeOut = DateTime.Parse(request.DateTimeOut);

            if (entity.DateTimeIn.HasValue)
            {
                if (entity.DateTimeIn.Value.Date != entity.ReportedDate)
                    return ("Date time-in should be equal to Reported date");

                if (entity.DateTimeOut < entity.DateTimeIn)
                    return ("Date time-out cannot be less than Date time-in");
            }
            else
            {
                if (entity.DateTimeOut.HasValue)
                    return ("Date time-in is required");
            }
            
            service.Create(entity);
            return "Saving successful";

        }

        [WebMethod]
        public string UpdateTimeSheet(TimeSheetRequest request)
        {
            DataAccess.Core.DATimeSheet service = new DataAccess.Core.DATimeSheet();
            DataAccess.EmployeeTimeSheet entity = new DataAccess.EmployeeTimeSheet();

            if (new Guid(request.Id) == Guid.Empty)
                entity.Id = Guid.NewGuid();
            else
                entity.Id = new Guid(request.Id);

            entity.EmployeeId = new Guid(request.EmpId);
            entity.ReportedDate = DateTime.Parse(request.Date);
            entity.DateTimeIn = DateTime.Parse(request.DateTimeIn);
            entity.DateTimeOut = DateTime.Parse(request.DateTimeOut);

            if (entity.DateTimeIn.HasValue)
            {
                if (entity.DateTimeIn.Value.Date != entity.ReportedDate)
                    return ("Date time-in should be equal to Reported date");

                if (entity.DateTimeOut < entity.DateTimeIn)
                    return ("Date time-out cannot be less than Date time-in");
            }
            else
            {
                if (entity.DateTimeOut.HasValue)
                    return ("Date time-in is required");
            }

            if (new Guid(request.Id) == Guid.Empty)
                service.Create(entity);
            else
                service.Update(entity);

            /*Return list of timesheet*/

            var startDate = DateTime.Now.GetFirstDayOfWeek().Date.AddDays(1); ;

            FormlessPage page = new FormlessPage();
            var ctrl = (Payroll.Web.Pages.TimeSheet.TimeSheetList)page.LoadControl("~/Pages/TimeSheet/TimeSheetList.ascx");

            ctrl.EmployeeId = new Guid(request.EmpId);
            ctrl.StartDate = DateTime.Now.GetFirstDayOfWeek().Date.AddDays(1);

            page.Controls.Add(ctrl);

            return page.RenderPage();

        }

         [WebMethod]
        public string GetTimeSheet(GetTimeSheetRequest request)
        {
            DataAccess.Core.DATimeSheet service = new DataAccess.Core.DATimeSheet();

            var entity = service.GetById(new Guid(request.Id));


            FormlessPage page = new FormlessPage();
            var ctrl = (Payroll.Web.Pages.TimeSheet.Update)page.LoadControl("~/Pages/TimeSheet/Update.ascx");

            ctrl.ReportedDate = request.ReportedDate.ToDate();
            ctrl.EmployeeId = request.EmpId.ToString();
            ctrl.Id = request.Id;
            if (entity != null)
            {                
                ctrl.ReportedDate = entity.ReportedDate;
                ctrl.DateTimeIn = entity.DateTimeIn;
                ctrl.DateTimeOut = entity.DateTimeOut;
            }
           

            page.Controls.Add(ctrl);

            return page.RenderPage();
           
         }

         [WebMethod]
         public string GetTimeSheetList(GetTimeSheetRequest request)
         {
             DataAccess.Core.DATimeSheet service = new DataAccess.Core.DATimeSheet();
             var startDate = DateTime.Now.GetFirstDayOfWeek().Date.AddDays(1); 

             FormlessPage page = new FormlessPage();
             var ctrl = (Payroll.Web.Pages.TimeSheet.TimeSheetList)page.LoadControl("~/Pages/TimeSheet/TimeSheetList.ascx");
          
             ctrl.EmployeeId = new Guid(request.EmpId);
             ctrl.StartDate = DateTime.Now.GetFirstDayOfWeek().Date.AddDays(1); 
                          
             page.Controls.Add(ctrl);

             return page.RenderPage();

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

    public class TimeSheetRequest
    {
        public string Id { get; set; }
        public string EmpId { get; set; }        
        public string Date {get;set;}
        public string DateTimeIn { get; set; }
        public string DateTimeOut { get; set; }
                   
    }

    public class GetTimeSheetRequest
    {
        public string Id { get; set; }
        public string EmpId { get; set; }
        public string ReportedDate { get; set; }
        
    }
}
