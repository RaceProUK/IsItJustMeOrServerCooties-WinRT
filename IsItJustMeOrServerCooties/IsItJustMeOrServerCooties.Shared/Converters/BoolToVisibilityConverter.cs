using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace IsItJustMeOrServerCooties.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, String language)
        {
            return "i".Equals(parameter)
                ? value is bool && (bool) value ? Visibility.Collapsed : Visibility.Visible
                : value is bool && (bool) value ? Visibility.Visible : Visibility.Collapsed;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, String language)
        {
            return "i".Equals(parameter)
                ? value is Visibility && (Visibility) value == Visibility.Collapsed
                : value is Visibility && (Visibility) value == Visibility.Visible;
        }
    }
}