using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Controls
{
    public partial class MainHorizonalSiteMapConcreate : System.Web.UI.UserControl
    {
        private HorizontalMenuItemCollection _items = new HorizontalMenuItemCollection();

        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                return;

            if (this.CurrentApplication().NavigationProvider != null)
            {
                NavigationNodesList Nodes = this.CurrentApplication().NavigationProvider.GetNodes();
                if (Nodes != null)
                {
                    foreach (NavigationNode childNode in Nodes)
                    {
                        HorizontalMenuItem menuItem = new HorizontalMenuItem(childNode.Text);
                        menuItem.ChildItems.AddRange(GetSubItems(childNode));
                        this._items.Add(menuItem);
                    }
                }
            }
        }

        private List<HorizontalSubMenuItem> GetSubItems(NavigationNode node)
        {
            List<HorizontalSubMenuItem> result = new List<HorizontalSubMenuItem>();
            foreach (NavigationNode childNode in node.Children)
            {
                HorizontalSubMenuItem menuItem = new HorizontalSubMenuItem(childNode.Text, childNode.Url);
                if (childNode.Children.Count > 0) menuItem.ChildItems.AddRange(GetSubItems(childNode));
                result.Add(menuItem);
            }
            return result;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            // <div id="nav">
           // writer.AddAttribute(HtmlTextWriterAttribute.Id, "nav");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "content-wrapper");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            

            //<nav>
            writer.AddAttribute(HtmlTextWriterAttribute.Id, "menu");
            writer.RenderBeginTag("Nav");

            // <ul id="menu">
            //writer.AddAttribute(HtmlTextWriterAttribute.Id, "menu");
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);

            int position = 1;
            _items.ForEach(item =>
            {
                //string cssClass = position == _items.Count ? "menu-wrapper" : null;
                item.RenderItem(writer, null);
                position++;
            });

            // </ul>
            writer.RenderEndTag();
            //</nav>
            writer.RenderEndTag();
            // </div>
            writer.RenderEndTag();

            base.Render(writer);
        }

        private void RegisterClientScript()
        {
            if (!Page.ClientScript.IsStartupScriptRegistered(typeof(MainHorizonalSiteMapConcreate), "HorizontalMenuStartup"))
            {
                string script = @"if (window.attachEvent) window.attachEvent('onload', sfHorizontalMenuHover);";
                Page.ClientScript.RegisterStartupScript(typeof(MainHorizonalSiteMapConcreate), "HorizontalMenuStartup", script, true);
            }

            if (!Page.ClientScript.IsClientScriptBlockRegistered(typeof(MainHorizonalSiteMapConcreate), "HorizontalMenuHover"))
            {
                string script = @"
                    sfHorizontalMenuHover = function() {
	                    if(document.getElementsByTagName('nav')){
		                    var sfEls = document.getElementsByTagName('nav').getElementsByTagName('LI');
		                    for (var i=0; i<sfEls.length; i++) {
			                    sfEls[i].onmouseover=function() {
				                    this.className+=' sfhover';
			                    }
			                    sfEls[i].onmouseout=function() {
				                    this.className=this.className.replace(new RegExp(' sfhover\\b'), '');
			                    }
		                    }
	                    }
                    }
                ";
                Page.ClientScript.RegisterClientScriptBlock(typeof(MainHorizonalSiteMapConcreate), "HorizontalMenuHover", script, true);
            }
        }
    }
}