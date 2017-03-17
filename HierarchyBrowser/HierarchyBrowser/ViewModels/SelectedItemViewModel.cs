using HierarchyBrowser.Framework;
using HierarchyBrowser.Models;

namespace HierarchyBrowser.ViewModels
{
    internal class SelectedItemViewModel : ViewModelBase
    {
        private IHierarchyItem _item;
        public IHierarchyItem Item
        {
            get => _item;
            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }
    }
}