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
        private readonly IDatabaseFactory _databaseFactory;
        private readonly IQueryFactory _queryFactory;

        public DatabaseLogic(IDatabaseFactory databaseFactory, IQueryFactory queryFactory)
        {
            _databaseFactory = databaseFactory;
            _queryFactory = queryFactory;
        }

        public IEnumerable<string> GetDatabases(ConnectionInformation connectionInformation)
        {
            List<string> databases = new List<string>();
            DbConnectionStringBuilder builder = _databaseFactory.DbConnectionStringBuilderFactory(connectionInformation);

            using (DbConnection connection = _databaseFactory.DbConnectionFactory(connectionInformation.DatabaseType, builder.ConnectionString))
            {
                DbCommand command = connection.CreateCommand();
                command.CommandText = _queryFactory.ShowDatabases(connectionInformation.DatabaseType);
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