using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web
{
    public abstract class Operation
    {
        public bool IsAuthorized()
        {
            return this.CurrentPage().IsOperationAuthorized(this);
            //SGSReferenceApplication app = HttpContext.Current.ApplicationInstance as SGSReferenceApplication;
            //if (app != null) return app.IsOperationAuthorized(this);
            //return true;
        }

        public override string ToString()
        {
            Type t = this.GetType();
            string operationName = t.Name;
            if (t.IsNested) operationName = t.DeclaringType.Name + "." + operationName;
            return operationName;
        }

        public virtual string Description
        {
            get { return this.ToString(); }
        }
    }
}