using System.Windows;

namespace HierarchyBrowser.Helpers
{
    internal static class HierarchyValues
    {
        public static int BaseMarginSize => 5;
        public static int IndentSize => 20;

        public static int ParentIndentLevel => 1;
        public static int SelectedIndentLevel => 2;
        public static int ChildIndentLevel => 4;

        public static int HorizontalLineSize => 10;
        public static int HorizontalLineXPos => (IndentSize / 2) - (HorizontalLineSize / 2);

        public static double ItemHeight => 24;
        public static double SelectedItemHeight => 60;

        public static int SelectedItemVerticalMargin => 10;
    }
}