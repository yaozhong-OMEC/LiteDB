using System.Threading.Tasks;
using LiteDB.Studio.Core.Services.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace LiteDB.Studio.Core.ViewModels
{
    public class StudioViewModel : MvxNavigationViewModel
    {
        private readonly IDBInteractionService _dbInteractionService;

        public bool IsConnectedToDatabase => _dbInteractionService.IsConnectedToDatabase;
        public IMvxCommand ConnectToDatabaseCommand { get; }
        public IMvxCommand DisconnectFromDatabaseCommand { get; }

        public StudioViewModel(IDBInteractionService dbInteractionService, IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
            _dbInteractionService = dbInteractionService;
            ConnectToDatabaseCommand = new MvxAsyncCommand(ConnectToDatabase);
            DisconnectFromDatabaseCommand = new MvxCommand(DisconnectFromDatabase);
        }

        private async Task ConnectToDatabase()
        {
            var connectionString = await NavigationService.Navigate<ConnectionFormViewModel, ConnectionString>();

            if (connectionString != null)
            {
                _dbInteractionService.ConnectToDatabase(connectionString);
                await RaisePropertyChanged(nameof(IsConnectedToDatabase));
            }
        }

        private void DisconnectFromDatabase()
        {
            _dbInteractionService.DisconnectFromDatabase();
            RaisePropertyChanged(nameof(IsConnectedToDatabase));
        }
    }
}