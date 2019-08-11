using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace LiteDB.Studio.Core.ViewModels
{
    public class StudioViewModel : MvxNavigationViewModel
    {
        public bool IsConnectedToDatabase { get; set; }
        public IMvxCommand ConnectToDatabaseCommand { get; }
        public IMvxCommand DisconnectFromDatabaseCommand { get; }

        public StudioViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
            ConnectToDatabaseCommand = new MvxAsyncCommand(ConnectToDatabase);
            DisconnectFromDatabaseCommand = new MvxCommand(DisconnectFromDatabase);
        }

        private async Task ConnectToDatabase()
        {
            var connectionString = await NavigationService.Navigate<ConnectionFormViewModel, string>();
            
            // TODO: Add actual logic here to connect to the database in service
            if (connectionString != null)
            {
                IsConnectedToDatabase = true;
            }
        }

        private void DisconnectFromDatabase()
        {
            // TODO: Add actual logic here to disconnect from the database in service
            IsConnectedToDatabase = false;
        }
    }
}