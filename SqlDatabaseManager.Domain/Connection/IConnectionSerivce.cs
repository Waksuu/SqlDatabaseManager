using SqlDatabaseManager.Domain.Connection;

namespace SqlDatabaseManager.Domain.Connection
{
    public interface IConnectionSerivce
    {
        void ConnectToDatabase(ConnectionInformationDTO connectionInformation);
    }
}