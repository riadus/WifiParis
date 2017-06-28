using System;
using System.Globalization;
using Xamarin.Forms;

namespace WifiParisComplete.XF.Converters
{
    public class BusyToBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isBusy = (bool)value;
            return isBusy ? Color.Orange : Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
