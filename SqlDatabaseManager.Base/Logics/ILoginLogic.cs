using SqlDatabaseManager.Base.Models;

namespace SqlDatabaseManager.Base.Logics
{
    public interface ILoginLogic
    {
        bool ConnectToDatabase(ConnectionInformation connectionInformation);
    }
}