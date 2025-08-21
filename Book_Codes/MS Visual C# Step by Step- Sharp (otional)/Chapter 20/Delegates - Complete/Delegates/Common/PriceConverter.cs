using System;
using Windows.UI.Xaml.Data;

namespace Delegates.Common
{
    /// <summary>
    /// Value converter that converts prices to strings using the local currency.
    /// </summary>
    public sealed class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                return $"{value:C}";
            }
            else
            {
                return "";
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
