using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Query;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace SqlDatabaseManager.Domain.Database
{
    public class DatabaseLogic : IDatabaseLogic
    {
        private readonly IDatabaseFactory databaseFactory;
        private readonly IQueryFactory queryFactory;

        public DatabaseLogic(IDatabaseFactory databaseFactory, IQueryFactory queryFactory)
        {
            this.databaseFactory = databaseFactory;
            this.queryFactory = queryFactory;
        }

        public IEnumerable<DatabaseDefinition> GetDatabases(ConnectionInformation connectionInformation)
        {
            List<DatabaseDefinition> databases = new List<DatabaseDefinition>();

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

        private DbConnectionStringBuilder GetConnectionStringBuilder(ConnectionInformation connectionInformation) => databaseFactory.DbConnectionStringBuilderFactory(connectionInformation);

        private DbConnection ConnectToDatabase(DatabaseType databaseType, string connectionString) => databaseFactory.DbConnectionFactory(databaseType, connectionString);

        private DbCommand GenerateQuery(DatabaseType databaseType, DbConnection connection)
        {
            var query = queryFactory.GetQuery(databaseType);

            DbCommand command = connection.CreateCommand();
            command.CommandText = query.ShowDatabases();
            command.CommandType = CommandType.Text;
            return command;
        }

        private void WriteQueryResults(List<DatabaseDefinition> databases, DbCommand command)
        {
            using (IDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    databases.Add(new DatabaseDefinition { DatabaseName = dr[0].ToString() });
                }
            }
        }

        #endregion Private Methods
    }
}