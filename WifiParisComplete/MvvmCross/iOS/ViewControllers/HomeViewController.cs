using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using WifiParisComplete.iOS.Converters;
using WifiParisComplete.ViewModels;

namespace WifiParisComplete.iOS
{
    public partial class HomeViewController : MvxViewController<HomeViewModel>
    {
        public HomeViewController () : base ("HomeView", null)
        {
            this.DelayBind (SetBindings);
        }

        private void SetBindings ()
        {
            var bindingSet = this.CreateBindingSet<HomeViewController, HomeViewModel> ();

            bindingSet.Bind (NavigateButton)
                                      .To (vm => vm.NavigateToWifiPageCommand);

            bindingSet.Bind (NavigateButton)
                                      .For ("Title")
                                      .To (vm => vm.NavigationToWifiPageButtonText);

			bindingSet.Bind(AddNewButton)
									  .To(vm => vm.NavigateToAddNewPageCommand);

			bindingSet.Bind(AddNewButton)
									  .For("Title")
									  .To(vm => vm.NavigationToAddNewPageButtonText);


			bindingSet.Bind (View)
                      .For (v => v.BackgroundColor)
                      .To (vm => vm.IsBusy)
                      .WithConversion(new BusyToBackgroundColorConverter());

            bindingSet.Apply ();
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            NavigateButton.TitleLabel.LineBreakMode = UILineBreakMode.WordWrap;
            NavigateButton.TitleLabel.TextAlignment = UITextAlignment.Center;

			AddNewButton.TitleLabel.LineBreakMode = UILineBreakMode.WordWrap;
			AddNewButton.TitleLabel.TextAlignment = UITextAlignment.Center;
        }
    }
}

