using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HierarchyBrowser.Models;
using HierarchyBrowser.ViewModels;

namespace HierarchyBrowser.Helpers
{
    internal class LinePositionCalculator : ILinePositionCalculator
    {
        private ObservableCollection<HierarchyLine> _collection;

        public ObservableCollection<HierarchyLine> CalculatePositions(IHierarchyItem item)
        {
            _collection = new ObservableCollection<HierarchyLine>();

            CalculateParentLines(item);
            CalculateChildLines(item);

            return _collection;
        }

        private void CalculateParentLines(IHierarchyItem item)
        {
            var xStart = HierarchyValues.BaseMarginSize + HierarchyValues.HorizontalLineXPos;
            var xEnd = HierarchyValues.BaseMarginSize + HierarchyValues.HorizontalLineXPos + HierarchyValues.HorizontalLineSize;

            for (var i = 0; i < item.Parents.Count; i++)
            {
                var yBase = i * (int) HierarchyValues.ItemHeight;
                var yValue = yBase + (int) HierarchyValues.ItemHeight / 2;
                var line = new HierarchyLine
                {
                    X1 = xStart,
                    X2 = xEnd,
                    Y1 = yValue,
                    Y2 = yValue,
                };
                _collection.Add(line);
            }

            if (item.Parents.Any())
            {
                var yParentEnd = item.Parents.Count * (int) HierarchyValues.ItemHeight;
                var yValue = yParentEnd + HierarchyValues.SelectedItemVerticalMargin + (int) HierarchyValues.SelectedItemHeight / 2;
                var verticalLine = new HierarchyLine
                {
                    X1 = xEnd,
                    X2 = xEnd,
                    Y1 = (int) HierarchyValues.ItemHeight / 2,
                    Y2 = yValue
                };

                var horizontalLine = new HierarchyLine
                {
                    X1 = xEnd,
                    X2 = HierarchyValues.BaseMarginSize + HierarchyValues.SelectedIndentLevel * HierarchyValues.IndentSize,
                    Y1 = yValue,
                    Y2 = yValue
                };

                _collection.Add(verticalLine);
                _collection.Add(horizontalLine);
            }
        }

        private void CalculateChildLines(IHierarchyItem item)
        {
            var ySelectedItemEnd = (item.Parents.Count * (int) HierarchyValues.ItemHeight) + (int) HierarchyValues.SelectedItemHeight + HierarchyValues.SelectedItemVerticalMargin;
            var xBase = HierarchyValues.BaseMarginSize + (HierarchyValues.ChildIndentLevel - 1) * HierarchyValues.IndentSize;
            var xStartChild = xBase + HierarchyValues.HorizontalLineXPos;
            var xEndChild = xStartChild + HierarchyValues.HorizontalLineSize;
            var lastYValue = 0;

            for (var i = 0; i < item.Children.Count; i++)
            {
                var yBase = HierarchyValues.SelectedItemVerticalMargin + i * (int) HierarchyValues.ItemHeight;
                var yValue = ySelectedItemEnd + yBase + (int) HierarchyValues.ItemHeight / 2;
                var line = new HierarchyLine
                {
                    X1 = xStartChild,
                    X2 = xEndChild,
                    Y1 = yValue,
                    Y2 = yValue,
                };
                _collection.Add(line);
                lastYValue = yValue;
            }

            if (item.Children.Any())
            {
                var verticalLine = new HierarchyLine
                {
                    X1 = xStartChild,
                    X2 = xStartChild,
                    Y1 = ySelectedItemEnd,
                    Y2 = lastYValue
                };
                _collection.Add(verticalLine);
            }
        }
    }
}