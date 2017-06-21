using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using WifiParisComplete.Data;

namespace WifiParisMVCComplete.iOS
{

    public class WifiHotspotViewSource : UITableViewSource
    {
        private List<WifiHotspot> _data;
        public void SetSource (IEnumerable<WifiHotspot> data)
        {
            _data = data.ToList ();
        }

        public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
        {
            var cellTemp = tableView.DequeueReusableCell ("Cell_Id");
            var cell = (WifiHotspotCell)cellTemp;
            cell.UpdateData (_data [indexPath.Row]);
            return cell;
        }

        public override nint RowsInSection (UITableView tableview, nint section)
        {
            return _data?.Count () ?? 0;
        }
    }
}