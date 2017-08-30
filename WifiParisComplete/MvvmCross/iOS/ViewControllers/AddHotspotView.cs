using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using WifiParisComplete.iOS.Converters;
using WifiParisComplete.ViewModels;

namespace WifiParisComplete.iOS.Views
{
    public partial class AddHotspotView : MvxViewController<AddNewHotspotViewModel>
    {
        public AddHotspotView() : base("AddHotspotView", null)
        {
            this.DelayBind(SetBindings);
        }

        private void SetBindings()
        {
            var bindingSet = this.CreateBindingSet<AddHotspotView, AddNewHotspotViewModel>();
            bindingSet.Bind(TitleLabel)
               .To(vm => vm.TitleLabel);

            bindingSet.Bind(WifiNameLabel)
               .To(vm => vm.NameLabel);
            bindingSet.Bind(WifiNameTextfield)
               .To(vm => vm.Name);
            bindingSet.Bind(WifiNameTextfield)
               .For(v => v.BackgroundColor)
               .To(vm => vm.IsNameValid)
               .WithConversion(new ValidToBackgroundColorConverter());
            
            bindingSet.Bind(AddressLabel)
               .To(vm => vm.AddressLabel);
            bindingSet.Bind(AddressTextfield)
               .To(vm => vm.Address);
			bindingSet.Bind(AddressTextfield)
			  .For(v => v.BackgroundColor)
			  .To(vm => vm.IsAddressValid)
			  .WithConversion(new ValidToBackgroundColorConverter());
            
			bindingSet.Bind(PostalCodeLabel)
               .To(vm => vm.PostalCodeLabel);
            bindingSet.Bind(PostalCodeTexfield)
			   .To(vm => vm.PostalCode);
			bindingSet.Bind(PostalCodeTexfield)
			  .For(v => v.BackgroundColor)
			  .To(vm => vm.IsPostalCodeValid)
			  .WithConversion(new ValidToBackgroundColorConverter());
            
			bindingSet.Bind(CityLabel)
			   .To(vm => vm.CityLabel);
			bindingSet.Bind(CityTextfield)
			   .To(vm => vm.City);
			bindingSet.Bind(CityTextfield)
			  .For(v => v.BackgroundColor)
			  .To(vm => vm.IsCityValid)
			  .WithConversion(new ValidToBackgroundColorConverter());
            
			bindingSet.Bind(LatLabel)
			   .To(vm => vm.LatLabel);
			bindingSet.Bind(LatTextfield)
			   .To(vm => vm.Lat);
			bindingSet.Bind(LatTextfield)
			  .For(v => v.BackgroundColor)
			  .To(vm => vm.IsLatValid)
			  .WithConversion(new ValidToBackgroundColorConverter(), true);
            
			bindingSet.Bind(LongLabel)
			   .To(vm => vm.LongLabel);
            bindingSet.Bind(LongTextfield)
               .To(vm => vm.Long);
		   bindingSet.Bind(LongTextfield)
			  .For(v => v.BackgroundColor)
			  .To(vm => vm.IsLongValid)
			  .WithConversion(new ValidToBackgroundColorConverter(), true);
            
            bindingSet.Bind(CancelButton)
               .For("Title")
               .To(vm => vm.OkButtonTxt);
            bindingSet.Bind(CancelButton)
               .To(vm => vm.OkCommand);
			bindingSet.Bind(OkButton)
			   .For("Title")
			   .To(vm => vm.CancelButtonTxt);
			bindingSet.Bind(OkButton)
			   .To(vm => vm.CancelCommand);
            
            bindingSet.Apply();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

