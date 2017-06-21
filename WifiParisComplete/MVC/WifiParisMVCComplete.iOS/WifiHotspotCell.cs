using System;
using UIKit;
using WifiParisComplete.Data;

namespace WifiParisMVCComplete.iOS
{
    public partial class WifiHotspotCell : UITableViewCell
    {
        public WifiHotspotCell (IntPtr handle) : base (handle)
        {
        }

        public WifiHotspot Model { get; private set; }

        public void UpdateData (WifiHotspot model)
        {
            NameLabel.Text = model.Name;
            AddressLabel.Text = model.Address.Street;
            PostalCodeLabel.Text = model.Address.PostalCode;
            DistanceLabel.Text = "";
            Model = model;
        }

        public override void LayoutSubviews ()
        {
            base.LayoutSubviews ();
            AddressLabel.LineBreakMode = UILineBreakMode.WordWrap;
            AddressLabel.Lines = 0;

            NameLabel.AdjustsFontSizeToFitWidth = true;
        }
    }
}