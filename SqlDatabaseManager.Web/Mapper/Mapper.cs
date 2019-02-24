using SqlDatabaseManager.Base.Models;
using SqlDatabaseManager.Web.Models;

namespace SqlDatabaseManager.Web.Mapper
{
    public class Mapper
    {
        public static ConnectionInformation ConnectionInformationMapper(ConnectionInformationViewModel connectionViewModel)
        {
            ConnectionInformation connection = new ConnectionInformation();
            connection.ServerAddress = connectionViewModel.ServerAddress;
            connection.Login = connectionViewModel.Login;
            connection.Password = connectionViewModel.Password;
            connection.DatabaseType = connectionViewModel.DatabaseType.Value;

            return connection;
        }
    }
}