using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.DataAccess.Core
{
    public  class DATimeSheet
    {
        public Guid Create(EmployeeTimeSheet time)
        {
            PayrollDataContext context = new PayrollDataContext();
            if (time.Id == Guid.Empty)
                time.Id = Guid.NewGuid();

            time.IsDeleted = false;
            context.EmployeeTimeSheets.InsertOnSubmit(time);
            context.SubmitChanges();

            return time.Id;
        }

        public void Update(EmployeeTimeSheet time)
        {
            PayrollDataContext context = new PayrollDataContext();

            var timesheet = context.EmployeeTimeSheets.Where(x => x.Id == time.Id).FirstOrDefault();
            timesheet.ReportedDate = time.ReportedDate;
            timesheet.DateTimeIn  = time.DateTimeIn;
            timesheet.DateTimeOut = time.DateTimeOut;
            
            context.SubmitChanges();

        }

        public EmployeeTimeSheet GetById(Guid id)
        {
            PayrollDataContext context = new PayrollDataContext();            

            return context.EmployeeTimeSheets.Where(x => x.Id == id).FirstOrDefault();

            
        }

        public void Exists(EmployeeTimeSheet time)
        {
            PayrollDataContext context = new PayrollDataContext();

            var timesheet = context.EmployeeTimeSheets.Where(x => x.Id == time.Id).FirstOrDefault();
            timesheet.ReportedDate = time.ReportedDate;
            timesheet.DateTimeIn = time.DateTimeIn;
            timesheet.DateTimeOut = time.DateTimeOut;

            context.SubmitChanges();

        }

        public List<Entity.TimeSheet> GetListByEmployee(Guid employeeId, DateTime startDate, DateTime endDate)
        {
            PayrollDataContext context = new PayrollDataContext();
            return context.GetTimeSheetByEmployee(employeeId, startDate, endDate)
                .Select(x =>
                    new Entity.TimeSheet()
                    { 
                    Id = x.id.HasValue ? x.id.Value : Guid.Empty,
                    EmployeeId = x.EmployeeId.HasValue ? x.EmployeeId.Value: Guid.Empty,
                    ReportedDate = x.ReportedDate.Value,
                    DateTimeIn = x.DateTimeIn,
                    DateTimeOut = x.DateTimeOut,
                    Remarks = x.Remarks
                    })
                 .ToList();

            //return context.EmployeeTimeSheets.Where(x=> x.IsDeleted == false && x.EmployeeId == employeeId).ToList();

        }
    }
}
