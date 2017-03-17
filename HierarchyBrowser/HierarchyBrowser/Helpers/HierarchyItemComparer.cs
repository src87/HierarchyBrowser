using System.Collections.Generic;
using System.Linq;
using HierarchyBrowser.Models;

namespace HierarchyBrowser.Helpers
{
    internal class HierarchyItemComparer : IComparer<IHierarchyItem>
    {
        public int Compare(IHierarchyItem x, IHierarchyItem y)
        {
            if (x == null && y == null)
                return 0;

            if (x == null)
                return -1;

            if (y == null)
                return 1;

            var xWords = x.DisplayText.Split(' ');
            var yWords = y.DisplayText.Split(' ');

            var compareLast = string.CompareOrdinal(xWords.LastOrDefault(), yWords.LastOrDefault());
            if (compareLast != 0)
                return compareLast;

            return string.CompareOrdinal(x.DisplayText, y.DisplayText);
        }
    }
}