using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using LiteDB.Studio.Core.Models.CollectionView;
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
        public List<CollectionItem> CollectionItemTree { get; private set; }


        public IMvxCommand ConnectToDatabaseCommand { get; }
        public IMvxCommand DisconnectFromDatabaseCommand { get; }

        public StudioViewModel(IDBInteractionService dbInteractionService, IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
            _dbInteractionService = dbInteractionService;

            CollectionItemTree = new List<CollectionItem>();

            ConnectToDatabaseCommand = new MvxAsyncCommand(ConnectToDatabase);
            DisconnectFromDatabaseCommand = new MvxCommand(DisconnectFromDatabase);
        }

        public override async Task RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            await base.RaisePropertyChanged(changedArgs);

            switch (changedArgs.PropertyName)
            {
                case nameof(IsConnectedToDatabase):
                    InitializeCollectionItemTree();
                    break;
            }
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

        private void InitializeCollectionItemTree()
        {
            var intermediateList = new List<CollectionItem>();
            if (IsConnectedToDatabase)
            {
                var collections = _dbInteractionService.GetCollections().ToList();
                var systemCollectionsFolder = new CollectionItem
                {
                    Name = "System",
                    Type = CollectionItemType.Folder,
                    Children = new List<CollectionItem>(collections.Where(col => col.Type == CollectionItemType.SystemCollection))
                };

                var rootItem = new CollectionItem
                {
                    Name = "Root",
                    Type = CollectionItemType.Root,
                    Children = new List<CollectionItem>(new[] {systemCollectionsFolder}.Concat(collections.Where(col => col.Type == CollectionItemType.UserCollection)))
                };

                intermediateList.Add(rootItem);
            }

            CollectionItemTree = intermediateList;
        }
    }
}