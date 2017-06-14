using System;
using System.Globalization;
using MvvmCross.Platform.Converters;
using UIKit;

namespace WifiParisComplete.iOS.Converters
{
    class BusyToBackgroundColorConverter : IMvxValueConverter
    {
        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isBusy = (bool)value;

            return isBusy ? UIColor.Orange : UIColor.White;
        }

        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException ();
        }
    }
}