using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Query;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace SqlDatabaseManager.Domain.Database
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

            DbConnectionStringBuilder builder = GetConnectionStringBuilder(connectionInformation);

            using (DbConnection connection = ConnectToDatabase(connectionInformation.DatabaseType, builder.ConnectionString))
            {
                DbCommand command = GenerateQuery(connectionInformation.DatabaseType, connection);

                connection.Open();

                WriteQueryResults(databases, command);
            }

            return databases;
        }

        #region Private Methods

        private DbConnectionStringBuilder GetConnectionStringBuilder(ConnectionInformation connectionInformation) => _databaseFactory.DbConnectionStringBuilderFactory(connectionInformation);

        private DbConnection ConnectToDatabase(DatabaseType databaseType, string connectionString) => _databaseFactory.DbConnectionFactory(databaseType, connectionString);

        private DbCommand GenerateQuery(DatabaseType databaseType, DbConnection connection)
        {
            var query = _queryFactory.GetQuery(databaseType);

            DbCommand command = connection.CreateCommand();
            command.CommandText = query.ShowDatabases();
            command.CommandType = CommandType.Text;
            return command;
        }

        private void WriteQueryResults(List<string> databases, DbCommand command)
        {
            using (IDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    databases.Add(dr[0].ToString());
                }
            }
        }

        #endregion Private Methods
    }
}