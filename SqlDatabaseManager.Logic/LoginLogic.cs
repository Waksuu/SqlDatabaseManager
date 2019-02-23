using SqlDatabaseManager.Base.Factories;
using SqlDatabaseManager.Base.Logics;
using SqlDatabaseManager.Base.Models;
using System.Collections.Generic;
using System.Data.Common;

namespace SqlDatabaseManager.Logic
{
    public class LoginLogic : ILoginLogic
    {
        public bool ConnectToDatabase(ConnectionInformation connectionInformation)
        {
            DbConnectionStringBuilder builder = DatabaseFactory.DbConnectionStringBuilderFactory(connectionInformation);

            if (!connectionInformation.DatabaseType.HasValue)
                return false;

            using (DbConnection connection = DatabaseFactory.DbConnectionFactory(connectionInformation.DatabaseType.Value, builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
    }
}