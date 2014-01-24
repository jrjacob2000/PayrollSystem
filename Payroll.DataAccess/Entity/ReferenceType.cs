using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.DataAccess.Entity
{
    public class ReferenceType
    {

        public string ReferenceTypeCode
        { get; set; }

        public string Description
        {get;set;}

        public bool IsDeleted
        {get;set;}
    }
}
