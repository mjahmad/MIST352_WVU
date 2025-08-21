using System;
using Windows.UI.Xaml.Data;

namespace Delegates.Common
{
    /// <summary>
    /// Value converter that converts True to Yes and False to No, for displaying age restrictions.
    /// </summary>
    public sealed class AgeRestrictedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool)value ? "Yes" : "No";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
