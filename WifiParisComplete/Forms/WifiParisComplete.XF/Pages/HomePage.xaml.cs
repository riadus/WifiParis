using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WifiParisComplete.XF.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Home;
        }
    }
}
