using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchyBrowser
{
    internal interface IHierarchyItem
    {
        string DisplayText { get; }
        List<IHierarchyItem> Parents { get; }
        List<IHierarchyItem> Children { get; }
    }
}
