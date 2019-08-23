namespace LiteDB.Studio.Core.Services.Interfaces
{
    public interface IDBInteractionService
    {
        bool IsConnectedToDatabase { get; }
        void ConnectToDatabase(ConnectionString connectionString);

        void DisconnectFromDatabase();
    }
}