using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using HierarchyBrowser.Data;
using HierarchyBrowser.Framework;
using HierarchyBrowser.Helpers;
using HierarchyBrowser.Models;

namespace HierarchyBrowser.ViewModels
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
                HierarchyViewModel = new HierarchyViewModel
                {
                    Item = _selectedItem
                };
                OnPropertyChanged();
            }
        }

        private HierarchyViewModel _hierarchyViewModel;
        public HierarchyViewModel HierarchyViewModel
        {
            get => _hierarchyViewModel;
            set
            {
                _hierarchyViewModel = value;
                OnPropertyChanged();
            }
        }

        private async void Search(object o)
        {
            //Results =
            //    _dataProvider
            //        .Get(_searchText)
            //        .OrderBy(item => item, new HierarchyItemComparer())
            //        .ToList();

            Results = await
                Task.Factory.StartNew(
                    () =>
                        _dataProvider
                            .Get(_searchText)
                            .OrderBy(item => item, new HierarchyItemComparer())
                            .ToList()
            );
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
            if (_lastSearchText == _searchText)
                return;

            _lastSearchText = _searchText;
            Search(null);
        }
    }
}
