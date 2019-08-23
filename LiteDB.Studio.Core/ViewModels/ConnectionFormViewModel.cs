using System;
using System.Threading.Tasks;
using LiteDB.Studio.Core.Extensions;
using LiteDB.Studio.Core.Services.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace LiteDB.Studio.Core.ViewModels
{
    public class ConnectionFormViewModel : MvxNavigationViewModel, IMvxViewModelResult<ConnectionString>
    {
        private readonly IPlatformService _platformService;

        private ConnectionMode _connectionMode;
        
        public string AbsoluteFilePath { get; set; }
        public string Password { get; set; }
        public bool Upgrade { get; set; }
        public bool IsReadOnly { get; set; }
        public bool UseUtc { get; set; }
        public TimeSpan? Timeout { get; set; }


        public IMvxCommand<ConnectionMode> SetConnectionModeCommand { get; }
        public IMvxCommand BrowseFileCommand { get; }

        public IMvxCommand CancelCommand { get; }
        public IMvxCommand ConfirmCommand { get; }
        
        public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        public ConnectionFormViewModel(IPlatformService platformService, IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
            _platformService = platformService;

            SetConnectionModeCommand = new MvxCommand<ConnectionMode>(SetConnectionMode);
            BrowseFileCommand = new MvxCommand(BrowseFile);

            CancelCommand = new MvxAsyncCommand(Cancel);
            ConfirmCommand = new MvxAsyncCommand(ConfirmConnectionString);
        }

        private void SetConnectionMode(ConnectionMode mode)
        {
            _connectionMode = mode;
        }

        private  void BrowseFile()
        {
            AbsoluteFilePath = _platformService.BrowseFile() ?? string.Empty;
        }

        private Task Cancel()
        {
            return NavigationService.Close(this, null);
        }

        private Task ConfirmConnectionString()
        {
            var connectionString = new ConnectionString
            {
                Mode = _connectionMode,
                Filename = AbsoluteFilePath,
                Upgrade = Upgrade,
                UtcDate = UseUtc,
                ReadOnly = IsReadOnly
            };

            if (Password.IsNotNullOrEmptyOrWhiteSpace())
            {
                connectionString.Password = Password;
            }

            if (Timeout.HasValue)
            {
                connectionString.Timeout = Timeout.Value;
            }
            

            return NavigationService.Close(this, connectionString);
        }
    }
}