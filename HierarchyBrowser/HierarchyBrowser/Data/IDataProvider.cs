using System.Collections.Generic;
using HierarchyBrowser.Models;

namespace HierarchyBrowser.Data
{
    internal interface IDataProvider
    {
        IEnumerable<IHierarchyItem> Get(string text);
    }
}