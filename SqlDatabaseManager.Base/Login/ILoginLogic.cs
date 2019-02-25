using SSqlDatabaseManager.Base.Connection;

namespace SqlDatabaseManager.Base.Login
{
    public interface ILoginLogic
    {
        bool ConnectToDatabase(ConnectionInformation connectionInformation);
    }
}