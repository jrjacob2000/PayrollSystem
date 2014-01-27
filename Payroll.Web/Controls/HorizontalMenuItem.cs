using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Payroll.Web.Controls
{
    public class HorizontalMenuItem
    {
        #region Fields

        private HorizontalSubMenuItemCollection _childItems;

        #endregion

        #region Properties

        public HorizontalSubMenuItemCollection ChildItems
        {
            get { return _childItems; }
        }

        public string Text
        {
            get;
            set;
        }

        public string NavigateUrl
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        public HorizontalMenuItem() : this(null) { }

        public HorizontalMenuItem(string text)
        {
            _childItems = new HorizontalSubMenuItemCollection();
            Text = text; 
        }

        public HorizontalMenuItem(string text, string navigateUrl)
        {
            _childItems = new HorizontalSubMenuItemCollection();
            Text = text;
            NavigateUrl = navigateUrl;
        }

        #endregion

        #region Public Methods

        public void RenderItem(HtmlTextWriter htmlTextWriter, string cssClass)
        {
            if (!string.IsNullOrEmpty(cssClass))
            {
                htmlTextWriter.AddAttribute(HtmlTextWriterAttribute.Class, cssClass);
            }
            // <li>
            htmlTextWriter.RenderBeginTag(HtmlTextWriterTag.Li);
            // <span>
            htmlTextWriter.RenderBeginTag(HtmlTextWriterTag.Span);
            if (!string.IsNullOrEmpty(NavigateUrl))
            {
                htmlTextWriter.AddAttribute(HtmlTextWriterAttribute.Href, NavigateUrl);
                htmlTextWriter.RenderBeginTag(HtmlTextWriterTag.A);

                // Text
                htmlTextWriter.Write(Text);

                // </a>
                htmlTextWriter.RenderEndTag();
            }
            else
                // Text
                htmlTextWriter.Write(Text);        
           

            // </span>
            htmlTextWriter.RenderEndTag();

            if (ChildItems.Count > 0)
            {
                // <ul>
                htmlTextWriter.RenderBeginTag(HtmlTextWriterTag.Ul);
                ChildItems.ForEach(item => item.Render2(htmlTextWriter));
                // </ul>
                htmlTextWriter.RenderEndTag();
            }

            // </li>
            htmlTextWriter.RenderEndTag();
        }

        #endregion
    }

    public class HorizontalMenuItemCollection : List<HorizontalMenuItem>
    {
    }
}
