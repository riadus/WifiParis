using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;
using WifiParisComplete.iOS.Converters;
using WifiParisComplete.ViewModels;

namespace WifiParisComplete.iOS
{
    public partial class WifiHotspotsViewController : MvxViewController<WifiHotspotsViewModel>
    {
        public WifiHotspotsViewController () : base ("WifiHotspotsView", null)
        {
            this.DelayBind (SetBindings);
        }

        private void SetBindings ()
        {
            var bindingSet = this.CreateBindingSet<WifiHotspotsViewController, WifiHotspotsViewModel> ();

            bindingSet.Apply ();
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
        }
    }
}

