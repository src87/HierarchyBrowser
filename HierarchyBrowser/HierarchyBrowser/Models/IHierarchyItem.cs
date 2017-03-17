using System.Collections.Generic;

namespace HierarchyBrowser.Models
{
    internal interface IHierarchyItem
    {
        string DisplayText { get; }
        List<IHierarchyItem> Parents { get; }
        List<IHierarchyItem> Children { get; }
    }
}
