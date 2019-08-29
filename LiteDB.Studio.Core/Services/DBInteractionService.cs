using System.Collections.Generic;
using System.Linq;
using LiteDB.Studio.Core.Attributes;
using LiteDB.Studio.Core.Models.CollectionView;
using LiteDB.Studio.Core.Services.Interfaces;

namespace LiteDB.Studio.Core.Services
{
    [LazySingletonService]
    public class DBInteractionService : IDBInteractionService
    {
        private LiteDatabase _databaseInstance;

        public bool IsConnectedToDatabase => _databaseInstance != null;

        public void ConnectToDatabase(ConnectionString connectionString)
        {
            if (_databaseInstance != null)
            {
                return;
            }

            _databaseInstance = new LiteDatabase(connectionString);

            /*var testModelCollection = _databaseInstance.GetCollection<TestModel>();
            if (testModelCollection.Count() <= 0)
            {
                var list = Enumerable.Range(0, 10).Select(_ => new TestModel()).ToList();
                testModelCollection.Insert(list);
            }*/

            //_databaseInstance.Execute("");
        }

        public void DisconnectFromDatabase()
        {
            _databaseInstance.Dispose();
            _databaseInstance = null;
        }

        public IEnumerable<CollectionItem> GetCollections()
        {
            CollectionItem MapToCollectionItem(BsonDocument collectionDocument)
            {
                var collectionItem = new CollectionItem
                {
                    Name = collectionDocument.AsDocument["name"].AsString,
                };

                switch (collectionDocument.AsDocument["type"].AsString)
                {
                    case "system":
                        collectionItem.Type = CollectionItemType.SystemCollection;
                        break;
                    case "user":
                        collectionItem.Type = CollectionItemType.UserCollection;
                        break;
                    default:
                        collectionItem.Type = CollectionItemType.Undefined;
                        break;
                }

                return collectionItem;
            }

            return _databaseInstance.GetCollection("$cols")
                .Query()
                .Where("type = 'system' or type = 'user'")
                .OrderBy("name")
                .ToDocuments()
                .Select(MapToCollectionItem);
        }
    }
}