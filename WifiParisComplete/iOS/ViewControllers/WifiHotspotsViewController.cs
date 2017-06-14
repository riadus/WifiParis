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
            bindingSet.Bind (LoadButton)
                      .To (vm => vm.LoadWifiHotspotsCommand);

            bindingSet.Bind (LoadButton)
                      .For ("Title")
                      .To (vm => vm.LoadWifiHotspotsButtonText);
            bindingSet.Bind (FilterTextField)
                      .To (vm => vm.Filter);
            bindingSet.Bind (FilterTextField)
                      .For (v => v.Placeholder)
                      .To (vm => vm.FilterPlaceholder);
            bindingSet.Bind (LoadMapButton)
                      .To (vm => vm.LoadMapCommand);
            bindingSet.Bind (LoadMapButton)
                      .For ("Title")
                      .To (vm => vm.LoadMapButtonText);
            bindingSet.Bind (LoadMapButton)
                      .For (v => v.Enabled)
                      .To (vm => vm.IsLoadMapAvailable);

            bindingSet.Bind (View)
                      .For (v => v.BackgroundColor)
                      .To (vm => vm.IsBusy)
                      .WithConversion (new BusyToBackgroundColorConverter());
            var source = new MvxSimpleTableViewSource (WifiTableView, WifiItemViewCell.Key, WifiItemViewCell.Key);
            WifiTableView.Source = source;
            WifiTableView.RowHeight = 100;
            bindingSet.Bind (source)
                      .To (vm => vm.WifiHotspotsList);
            
            bindingSet.Apply ();

            WifiTableView.ReloadData ();
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            WifiTableView.BackgroundColor = UIColor.Clear;
            LoadButton.TitleLabel.LineBreakMode = UILineBreakMode.WordWrap;
            LoadButton.TitleLabel.TextAlignment = UITextAlignment.Center;
        }
    }
}

