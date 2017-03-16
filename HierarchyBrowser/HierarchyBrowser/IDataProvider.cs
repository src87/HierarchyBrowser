using System.Collections.Generic;

namespace HierarchyBrowser
{
    internal interface IDataProvider
    {
        IEnumerable<IHierarchyItem> Get(string text);
    }
}