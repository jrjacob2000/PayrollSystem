using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web
{
    public interface INavigationProvider
    {
        NavigationNodesList GetNodes();
        NavigationEntriesList GetEntries();
        NavigationSections GetSections();
    }
}
