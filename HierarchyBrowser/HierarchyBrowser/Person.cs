using System.Collections.Generic;

namespace HierarchyBrowser
{
    internal class Person : IHierarchyItem
    {
        public Person()
        {
            Parents = new List<IHierarchyItem>();
            Children = new List<IHierarchyItem>();
        }

        public string Name { get; set; }
        public string DisplayText => Name;
        public List<IHierarchyItem> Parents { get; }
        public List<IHierarchyItem> Children { get; }
    }
}