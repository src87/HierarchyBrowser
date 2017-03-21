using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using HierarchyBrowser.Helpers;

namespace HierarchyBrowser.Converters
{
    public class IndentLevelToMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                int margin = HierarchyValues.BaseMarginSize + ((int) value * HierarchyValues.IndentSize);
                return new Thickness(margin, 0, 0, 0);
            }

            return new Thickness();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}