using System.Collections.ObjectModel;
using HierarchyBrowser.Models;
using HierarchyBrowser.ViewModels;

namespace HierarchyBrowser.Helpers
{
    internal interface ILinePositionCalculator
    {
        ObservableCollection<HierarchyLine> CalculatePositions(IHierarchyItem item);
    }
}