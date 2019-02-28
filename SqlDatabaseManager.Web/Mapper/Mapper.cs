using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Web.Models;
using System;

namespace SqlDatabaseManager.Web.Mapper
{
    public class Mapper
    {
        public static ConnectionInformation ConnectionInformationMapper(ConnectionInformationViewModel connectionViewModel)
        {
            ValidateState(connectionViewModel);

            return MapModel(connectionViewModel);
        }

        private static void ValidateState(ConnectionInformationViewModel connectionViewModel)
        {
            if (connectionViewModel == null)
                throw new InvalidOperationException(string.Format(Domain.Properties.Resources.MappingError, nameof(connectionViewModel)));

            if (!connectionViewModel.DatabaseType.HasValue)
                throw new InvalidOperationException(string.Format(Domain.Properties.Resources.MappingError, nameof(connectionViewModel.DatabaseType)));
        }

        private static ConnectionInformation MapModel(ConnectionInformationViewModel connectionViewModel)
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