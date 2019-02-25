using SqlDatabaseManager.Base.Factories;
using SqlDatabaseManager.Base.Logics;
using SqlDatabaseManager.Base.Models;
using System;
using System.Data.Common;

namespace SqlDatabaseManager.Logic
{
    public class LoginLogic : ILoginLogic
    {
        private readonly IDatabaseFactory _databaseFactory;

        public LoginLogic(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public bool ConnectToDatabase(ConnectionInformation connectionInformation)
        {
            DbConnectionStringBuilder builder = _databaseFactory.DbConnectionStringBuilderFactory(connectionInformation);

            using (DbConnection connection = _databaseFactory.DbConnectionFactory(connectionInformation.DatabaseType, builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
    }
}