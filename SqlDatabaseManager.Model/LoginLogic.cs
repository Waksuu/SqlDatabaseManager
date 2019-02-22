using SqlDatabaseManager.Base.Enums;
using SqlDatabaseManager.Base.Factories;
using SqlDatabaseManager.Base.Logics;
using SqlDatabaseManager.Base.Models;
using SqlDatabaseManager.Base.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace SqlDatabaseManager.Logic
{
    public class LoginLogic : ILoginLogic
    {
        private readonly IDatabaseRepository _databaseRepository;

        public LoginLogic(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public IEnumerable<string> GetDatabasesName(ConnectionInformation connectionInformation)
        {
            List<string> databases = new List<string>();
            DbConnectionStringBuilder builder = DatabaseFactory.DbConnectionStringBuilderFactory(connectionInformation);

            using (DbConnection connection = DatabaseFactory.DbConnectionFactory(connectionInformation.DatabaseType, builder.ConnectionString))
            {
                DbCommand command = connection.CreateCommand();
                command.CommandText = QueryFactory.ShowDatabases(connectionInformation.DatabaseType);
                command.CommandType = CommandType.Text;

                connection.Open();

                using (IDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        databases.Add(dr[0].ToString());
                    }
                }
            }

            return databases;
        }
    }
}