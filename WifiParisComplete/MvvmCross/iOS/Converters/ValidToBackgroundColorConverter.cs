using System;
using System.Globalization;
using MvvmCross.Platform.Converters;
using UIKit;

namespace WifiParisComplete.iOS.Converters
{
    class ValidToBackgroundColorConverter : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object isReversed, CultureInfo culture)
        {
            var isValid = (bool)value && !(bool)isReversed;

            return !isValid ? UIColor.Red : UIColor.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}