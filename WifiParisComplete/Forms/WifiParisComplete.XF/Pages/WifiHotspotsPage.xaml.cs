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

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Liste.SelectedItem = null;
        }
    }
}
