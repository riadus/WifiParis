using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WifiParisComplete.XF.Pages
{
    public partial class WifiHotspotsPage : ContentPage
    {
        public WifiHotspotsPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.WifiHotspots;
        }
    }
}
