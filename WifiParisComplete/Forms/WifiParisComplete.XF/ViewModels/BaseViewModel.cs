using GalaSoft.MvvmLight;

namespace WifiParisComplete.XF.ViewModels
{
    public class BaseViewModel : ViewModelBase
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