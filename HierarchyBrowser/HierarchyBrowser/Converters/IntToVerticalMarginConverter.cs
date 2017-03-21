using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HierarchyBrowser.Converters
{
    public class IntToVerticalMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                var margin = (int)value;
                return new Thickness(0, margin, 0, margin);
            }

            return new Thickness();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}