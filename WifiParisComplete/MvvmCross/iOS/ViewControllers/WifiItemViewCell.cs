using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using WifiParisComplete.ViewModels;

namespace WifiParisComplete.iOS
{
    public partial class WifiItemViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString ("WifiItemViewCell");
        public static readonly UINib Nib;

        static WifiItemViewCell ()
        {
            Nib = UINib.FromName ("WifiItemViewCell", NSBundle.MainBundle);
        }

        protected WifiItemViewCell (IntPtr handle) : base (handle)
        {
            this.DelayBind (SetBindings);
        }

        private void SetBindings ()
        {
            var bindingSet = this.CreateBindingSet<WifiItemViewCell, WifiHotspotItemViewModel> ();

            bindingSet.Bind (HotspotNameLabel)
                      .To (vm => vm.Name);
            bindingSet.Bind (AddressLabel)
                      .To (vm => vm.Address);
            bindingSet.Bind (PostalCodeLabel)
                      .To (vm => vm.PostalCode);
            bindingSet.Bind (DistanceLabel)
                      .To (vm => vm.Distance);

            bindingSet.Apply ();
        }

        public override void LayoutSubviews ()
        {
            base.LayoutSubviews ();
            AddressLabel.LineBreakMode = UILineBreakMode.WordWrap;
            AddressLabel.Lines = 0;
        }
    }
}
