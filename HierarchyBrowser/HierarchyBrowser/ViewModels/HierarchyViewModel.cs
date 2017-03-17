using HierarchyBrowser.Framework;
using HierarchyBrowser.Models;

namespace HierarchyBrowser.ViewModels
{
    internal class HierarchyViewModel : ViewModelBase
    {
        private IHierarchyItem _item;
        public IHierarchyItem Item
        {
            get => _item;
            set
            {
                _item = value;
                SelectedItemViewModel = new SelectedItemViewModel
                {
                    Item = _item
                };
                OnPropertyChanged();
            }
        }

        private SelectedItemViewModel _selectedItemViewModel;
        public SelectedItemViewModel SelectedItemViewModel
        {
            get => _selectedItemViewModel;
            set
            {
                _selectedItemViewModel = value;
                OnPropertyChanged();
            }
        }
    }
}