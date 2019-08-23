using LiteDB.Studio.Core.Attributes;
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
        }

        public void DisconnectFromDatabase()
        {
            _databaseInstance.Dispose();
            _databaseInstance = null;
        }
    }
}