using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Sharpen.VisualStudioExtension.Converters
{
    public class NullToCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"Converting a {nameof(Visibility)} to a {typeof(object).Name} via {nameof(NullToCollapsedConverter)} is not supported.");
        }
    }
}
