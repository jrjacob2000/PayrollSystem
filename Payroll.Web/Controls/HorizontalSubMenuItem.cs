using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Payroll.Web.Controls
{
    [ToolboxItem(false)]
    public class HorizontalSubMenuItem : HyperLink
    {
        #region Fields

        private HorizontalSubMenuItemCollection _childItems;

        #endregion

        #region Properties

        public HorizontalSubMenuItemCollection ChildItems
        {
            get { return _childItems; }
        }


        #region Constructors

        public HorizontalSubMenuItem() : this(null, null) { }

        public HorizontalSubMenuItem(string text, string navigateUrl)
        {
            _childItems = new HorizontalSubMenuItemCollection();
            Text = text;
            NavigateUrl = navigateUrl;
        }

        #endregion

        protected override void Render(HtmlTextWriter writer)
        {
            // <li>
            writer.RenderBeginTag(HtmlTextWriterTag.Li);
            base.Render(writer);
            if (ChildItems.Count > 0)
            {
                // <ul>
                writer.RenderBeginTag(HtmlTextWriterTag.Ul);
                ChildItems.ForEach(item => item.Render(writer));
                // </ul>
                writer.RenderEndTag();
            }

            // </li>
            writer.RenderEndTag();
        }

        public void Render2(HtmlTextWriter writer)
        {
            this.Render(writer);
        }



        #endregion
    }

    public class HorizontalSubMenuItemCollection : List<HorizontalSubMenuItem>
    {
    }
}