using HierarchyBrowser.Models;

namespace HierarchyBrowser.Messaging
{
    internal class NavigationMessage
    {
        public IHierarchyItem SelectedItem { get; set; }
    }
}