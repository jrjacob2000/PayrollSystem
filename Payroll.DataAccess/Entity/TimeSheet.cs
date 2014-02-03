using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.DataAccess.Entity
{
    public class TimeSheet
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public DateTime ReportedDate { get; set; }

        public DateTime? DateTimeIn { get; set; }

        public DateTime? DateTimeOut { get; set; }

        public string Remarks { get; set; }


    }
}
