using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using WifiParisComplete.Data;
using Java.Lang;
using System.Linq;
using Android.App;

namespace WifiParisMVCComplete.Droid
{
    public class HotspotsAdapter : BaseAdapter
    {
        private List<WifiHotspot> HotspotsWifi { get; }
        private Activity Activity { get; }
        public HotspotsAdapter (Activity activity, IEnumerable<WifiHotspot> hotspotsWifi)
        {
            HotspotsWifi = hotspotsWifi.ToList();
            Activity = activity;
        }

        public override int Count => HotspotsWifi.Count ();

        public override Java.Lang.Object GetItem (int position)
        {
            return new JavaWrapperObject<WifiHotspot> { Object = HotspotsWifi [position] };
        }

        public override long GetItemId (int position)
        {
            return position;
        }

        public override View GetView (int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? Activity.LayoutInflater.Inflate (Resource.Layout.HotspotWifiItem, parent, false);

            var name = view.FindViewById<TextView> (Resource.Id.nameTextView);
            var address = view.FindViewById<TextView> (Resource.Id.adressTextView);
            var postalCode = view.FindViewById<TextView> (Resource.Id.postalCodeTextView);
            var distance = view.FindViewById<TextView> (Resource.Id.distanceTextView);
            var hotspotWifi = HotspotsWifi [position];

            name.Text = hotspotWifi.Name;
            address.Text = hotspotWifi.Address.Street;
            postalCode.Text = hotspotWifi.Address.PostalCode;
            distance.Text = "";
            return view;
        }

    }
}
