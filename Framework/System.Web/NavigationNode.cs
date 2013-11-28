using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web
{

    public class NavigationSections : List<NavigationSection>
    {

    }

    public class NavigationSection : NavigationEntriesList
    {

        public string Text { get; set; }
        public NavigationSection(string text)
        {

            Text = text;

        }

    }

    public class NavigationEntriesList : List<NavigationEntry>
    {

        public NavigationEntry Add(string text)
        {

            return this.Add(text, null, null);
        }

        public NavigationEntry Add(string text, string url)
        {

            return this.Add(text, url, null);
        }

        public NavigationEntry Add(string text, string url, string description)
        {

            NavigationEntry item = new NavigationEntry(text, url, description);
            this.Add(item);
            return item;
        }

    }

    public class NavigationEntry
    {

        public string Text { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public NavigationEntry() { }
        public NavigationEntry(string text)
        {

            Text = text;

        }

        public NavigationEntry(string text, string url)
            :

            this(text)
        {

            Url = url;

        }

        public NavigationEntry(string text, string url, string description)
            :

            this(text, url)
        {

            Description = description;

        }

    }

    public class NavigationNode : NavigationEntry
    {

        private NavigationNodesList _children = new NavigationNodesList();
        public NavigationNodesList Children
        {

            get { return _children; }
            set { _children = value; }
        }

        public NavigationNode(string text) : base(text) { }
        public NavigationNode(string text, string url) : base(text, url) { }
        public NavigationNode(string text, string url, string description) : base(text, url, description) { }
        public NavigationNode Add(string text)
        {

            return this.Add(text, null, null);
        }

        public NavigationNode Add(string text, string url)
        {

            return this.Add(text, url, null);
        }

        public NavigationNode Add(string text, string url, string description)
        {

            NavigationNode item = new NavigationNode(text, url, description);
            this.Children.Add(item);
            return item;
        }

    }

    public class NavigationNodesList : List<NavigationNode>
    {

        public NavigationNode Add(string text)
        {

            return this.Add(text, null, null);
        }

        public NavigationNode Add(string text, string url)
        {

            return this.Add(text, url, null);
        }

        public NavigationNode Add(string text, string url, string description)
        {

            NavigationNode item = new NavigationNode(text, url, description);
            this.Add(item);
            return item;
        }

    }

}



