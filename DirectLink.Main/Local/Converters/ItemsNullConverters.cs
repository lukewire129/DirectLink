using System;
using System.Collections;
using System.Globalization;
using System.Windows.Data;

namespace DirectLink.Main.Local.Converters
{
    public class ItemsNullConverters : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return true;
            if (value is int itemsCount)
            {
                if (itemsCount == 0)
                    return true;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException ();
        }
    }
}
