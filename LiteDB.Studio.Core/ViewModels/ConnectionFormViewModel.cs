using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace LiteDB.Studio.Core.ViewModels
{
    public class ConnectionFormViewModel : MvxNavigationViewModel, IMvxViewModelResult<string>
    {
        public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        public IMvxCommand CancelCommand { get; }
        public IMvxCommand ConfirmCommand { get; }

        public ConnectionFormViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
            CancelCommand = new MvxAsyncCommand(Cancel);
            ConfirmCommand = new MvxAsyncCommand(ConfirmConnectionString);
        }

        private Task Cancel()
        {
            return NavigationService.Close(this, null);
        }

        private Task ConfirmConnectionString()
        {
            return NavigationService.Close(this, string.Empty);
        }
    }
}