using System.Collections.ObjectModel;
using HierarchyBrowser.Framework;
using HierarchyBrowser.Helpers;

namespace HierarchyBrowser.ViewModels
{
    internal class HierarchyViewModel : ViewModelBase
    {
        private readonly ApplicationContext _context;
        private readonly ILinePositionCalculator _positionCalculator;

        public HierarchyViewModel(ApplicationContext context, ILinePositionCalculator positionCalculator)
        {
            _context = context;
            _positionCalculator = positionCalculator;
            Lines = new ObservableCollection<HierarchyLine>();
        }

        private HierarchyItemViewModel _item;
        public HierarchyItemViewModel Item
        {
            get => _item;
            set
            {
                _item = value;
                SelectedItemViewModel = new SelectedItemViewModel(_context)
                {
                    Item = _item
                };
                Lines = _positionCalculator.CalculatePositions(_item);
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

        private ObservableCollection<HierarchyLine> _lines;
        public ObservableCollection<HierarchyLine> Lines
        {
            get => _lines;
            set
            {
                _lines = value;
                OnPropertyChanged();
            }
        }
    }
}