using MvvmCross.Core.ViewModels;

namespace WifiParisComplete.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        private int _busyCounter;

        protected int BusyCounter {
            get {
                return _busyCounter;
            }
            set {
                _busyCounter = value;
                RaisePropertyChanged (nameof (IsBusy));
            }
        }

        public bool IsBusy => BusyCounter > 0;
    }
}