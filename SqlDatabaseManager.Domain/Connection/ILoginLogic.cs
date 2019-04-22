using SqlDatabaseManager.Domain.Connection;

namespace SqlDatabaseManager.Domain.Connection
{
    public interface ILoginLogic
    {
        void ConnectToDatabase(ConnectionInformationDTO connectionInformation);
    }
}