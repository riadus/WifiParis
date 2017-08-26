// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WifiParisComplete.iOS
{
    [Register ("HomeViewController")]
    partial class HomeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AddNewButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton NavigateButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AddNewButton != null) {
                AddNewButton.Dispose ();
                AddNewButton = null;
            }

            if (NavigateButton != null) {
                NavigateButton.Dispose ();
                NavigateButton = null;
            }
        }
    }
}