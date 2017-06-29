using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
namespace WifiParisComplete.XF.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			SimpleIoc.Default.Register<HomeViewModel>();
			SimpleIoc.Default.Register<HotspotsMapViewModel>();
			SimpleIoc.Default.Register<WifiHotspotsViewModel>();
        }

		public HomeViewModel Home => ServiceLocator.Current.GetInstance<HomeViewModel>();
		public WifiHotspotsViewModel WifiHotspots => ServiceLocator.Current.GetInstance<WifiHotspotsViewModel>();
    }
}
