using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll.Web
{
    public interface IPermissionProvider
    {
        bool IsOperationAuthorized(Operation facts);
    }
}