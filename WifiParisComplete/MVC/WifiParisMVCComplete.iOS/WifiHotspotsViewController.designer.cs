// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WifiParisMVCComplete.iOS
{
    [Register ("WifiHotspotsViewController")]
    partial class WifiHotspotsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField FilterTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LoadButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LoadMapButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView WifiHotspotsTable { get; set; }

        [Action ("LoadButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void LoadButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (FilterTextField != null) {
                FilterTextField.Dispose ();
                FilterTextField = null;
            }

            if (LoadButton != null) {
                LoadButton.Dispose ();
                LoadButton = null;
            }

            if (LoadMapButton != null) {
                LoadMapButton.Dispose ();
                LoadMapButton = null;
            }

            if (WifiHotspotsTable != null) {
                WifiHotspotsTable.Dispose ();
                WifiHotspotsTable = null;
            }
        }
    }
}