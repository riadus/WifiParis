using Foundation;
using System;
using UIKit;

namespace WifiParisMVCComplete.iOS
{
    public partial class HomeViewController : UIViewController
    {
        public HomeViewController (IntPtr handle) : base (handle)
        {
            
        }
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            NavigateToWifiHotspotsButton.TitleLabel.TextAlignment = UITextAlignment.Center;
        }
    }
}