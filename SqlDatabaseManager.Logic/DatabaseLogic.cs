using SqlDatabaseManager.Base.Factories;
using SqlDatabaseManager.Base.Logics;
using SqlDatabaseManager.Base.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace SqlDatabaseManager.Logic
{
    public class DatabaseLogic : IDatabaseLogic
    {
        public IEnumerable<string> GetDatabases(ConnectionInformation connectionInformation)
        {
            if (!connectionInformation.DatabaseType.HasValue)
                return null; //TODO: Throw exception

            List<string> databases = new List<string>();
            DbConnectionStringBuilder builder = DatabaseFactory.DbConnectionStringBuilderFactory(connectionInformation);

            using (DbConnection connection = DatabaseFactory.DbConnectionFactory(connectionInformation.DatabaseType.Value, builder.ConnectionString))
            {
                DbCommand command = connection.CreateCommand();
                command.CommandText = QueryFactory.ShowDatabases(connectionInformation.DatabaseType.Value);
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