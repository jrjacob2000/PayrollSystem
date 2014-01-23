using System;
using System.IO;
using System.Web;
using System.Web.UI;


namespace Payroll.Web
{
    public class FormlessPage:Page
    {
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        public string RenderPage()
        {
            
                StringWriter writer = new StringWriter();
                HttpContext.Current.Server.Execute(this, writer, false);
                return writer.ToString();
           
        }
    }
}
