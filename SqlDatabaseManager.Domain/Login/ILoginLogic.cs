using SqlDatabaseManager.Domain.Connection;

namespace SqlDatabaseManager.Domain.Login
{
    public interface ILoginLogic
    {
        void ConnectToDatabase(ConnectionInformationDTO connectionInformation);
    }
}