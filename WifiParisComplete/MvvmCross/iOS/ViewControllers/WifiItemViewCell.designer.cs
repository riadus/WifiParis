// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace WifiParisComplete.iOS
{
    [Register ("WifiItemViewCell")]
    partial class WifiItemViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel AddressLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DistanceLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel HotspotNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PostalCodeLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AddressLabel != null) {
                AddressLabel.Dispose ();
                AddressLabel = null;
            }

            if (DistanceLabel != null) {
                DistanceLabel.Dispose ();
                DistanceLabel = null;
            }

            if (HotspotNameLabel != null) {
                HotspotNameLabel.Dispose ();
                HotspotNameLabel = null;
            }

            if (PostalCodeLabel != null) {
                PostalCodeLabel.Dispose ();
                PostalCodeLabel = null;
            }
        }
    }
}