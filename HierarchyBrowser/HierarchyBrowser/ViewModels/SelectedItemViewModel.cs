using HierarchyBrowser.Framework;
using HierarchyBrowser.Models;

namespace HierarchyBrowser.ViewModels
{
    internal class SelectedItemViewModel : ViewModelBase
    {
        private readonly ApplicationContext _context;

        public SelectedItemViewModel(ApplicationContext context)
        {
            _context = context;
        }

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