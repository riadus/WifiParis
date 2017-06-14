using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using WifiParisComplete.Domain.Interfaces;

namespace WifiParisComplete.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private IBackendService BackendService { get; }
        public HomeViewModel (IBackendService backendService)
        {
            BackendService = backendService;
            ClickMeCommand = new MvxAsyncCommand (ClickMe);
        }

        public ICommand ClickMeCommand { get; }

        private async Task ClickMe ()
        {
            var records = await BackendService.GetRecords ();
        }
    }
}
