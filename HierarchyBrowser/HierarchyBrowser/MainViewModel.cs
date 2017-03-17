using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Threading;

namespace HierarchyBrowser
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly IDataProvider _dataProvider;
        private DispatcherTimer _timer;
        private const int TimerInterval = 500;
        private string _lastSearchText;

        public MainViewModel()
        {
            _dataProvider = new FakeDataProvider();
            SearchCommand = new RelayCommand(o => true, Search);
            StartTimer();
        }

        public ICommand SearchCommand { get; }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }

        private List<IHierarchyItem> _results;
        public List<IHierarchyItem> Results
        {
            get => _results;
            set
            {
                _results = value;
                OnPropertyChanged();
            }
        }

        private IHierarchyItem _selectedItem;
        public IHierarchyItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        private void Search(object o)
        {
            Results = _dataProvider.Get(_searchText).ToList();
        }

        private void StartTimer()
        {
            _lastSearchText = _searchText;

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(TimerInterval)
            };
            _timer.Tick += TimerElapsed;
            _timer.Start();
        }

        private void TimerElapsed(object sender, EventArgs e)
        {
            if (_lastSearchText != _searchText)
                Search(null);
        }
    }
}
