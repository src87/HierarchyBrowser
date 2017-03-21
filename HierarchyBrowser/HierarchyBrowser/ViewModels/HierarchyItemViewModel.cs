using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using HierarchyBrowser.Framework;
using HierarchyBrowser.Messaging;
using HierarchyBrowser.Models;

namespace HierarchyBrowser.ViewModels
{
    internal class HierarchyItemViewModel : IHierarchyItem
    {
        private readonly ApplicationContext _context;
        private readonly IHierarchyItem _item;

        public HierarchyItemViewModel(ApplicationContext context, IHierarchyItem item)
        {
            _context = context;
            _item = item;
            SelectedCommand = new RelayCommand(o => true, Selected);
        }

        public ICommand SelectedCommand { get; set; }

        private void Selected(object obj)
        {
            _context.Messenger.Send(new NavigationMessage{SelectedItem = this});
        }

        public string DisplayText => _item?.DisplayText;

        public List<IHierarchyItem> Parents => _item?.Parents ?? new List<IHierarchyItem>();
        public List<IHierarchyItem> Children => _item?.Children ?? new List<IHierarchyItem>();

        public List<HierarchyItemViewModel> ParentViewModels => Parents.Select(ItemToViewModel).ToList();
        public List<HierarchyItemViewModel> ChildViewModels => Children.Select(ItemToViewModel).ToList();

        private HierarchyItemViewModel ItemToViewModel(IHierarchyItem item)
        {
            return new HierarchyItemViewModel(_context, item);
        }
    }
}