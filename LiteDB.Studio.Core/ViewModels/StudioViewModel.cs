using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace LiteDB.Studio.Core.ViewModels
{
    public class StudioViewModel : MvxNavigationViewModel
    {
        public IMvxCommand OpenConnectionFormModalCommand { get; }

        public StudioViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
            OpenConnectionFormModalCommand = new MvxAsyncCommand(OpenConnectionFormModal);
        }

        private async Task OpenConnectionFormModal()
        {
            await NavigationService.Navigate<ConnectionFormViewModel>();
        }
    }
}