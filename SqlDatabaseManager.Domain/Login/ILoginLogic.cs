using SqlDatabaseManager.Domain.Connection;

namespace SqlDatabaseManager.Domain.Login
{
    public interface ILoginLogic
    {
        bool ConnectToDatabase(ConnectionInformation connectionInformation);
    }
}