using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using WifiParisComplete.ViewModels;

namespace WifiParisComplete.iOS
{
    public partial class HomeViewController : MvxViewController<HomeViewModel>
    {
        public HomeViewController () : base ("HomeViewController", null)
        {
            this.DelayBind (() => {
                var bindingSet = this.CreateBindingSet<HomeViewController, HomeViewModel> ();

                bindingSet.Bind (SyncButton)
                          .To (vm => vm.ClickMeCommand);

                bindingSet.Apply ();
            });
        }
    }
}

