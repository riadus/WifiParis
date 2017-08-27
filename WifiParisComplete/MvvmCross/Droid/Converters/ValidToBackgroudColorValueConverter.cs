using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using MvvmCross.Platform.Converters;

namespace WifiParisComplete.Droid
{
    public class ValidToBackgroudColorValueConverter : MvxValueConverter<bool, Drawable>
    {
        protected override Drawable Convert(bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !value ? new ColorDrawable(Color.OrangeRed) : new ColorDrawable();
        }
    }
}
