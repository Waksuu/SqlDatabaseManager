using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.ObjectExplorerData;
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

        public DatabaseLogic(IDatabaseFactory databaseFactory, IQueryFactory queryFactory) //TODO: Constructor should take connection string
                                                                                           // and IQuery implementation, instead of this
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
                var query = queryFactory.GetQuery(connectionInformation.DatabaseType);
                DbCommand command = GenerateQuery(connection, query.ShowDatabases());

                connection.Open();

                using (IDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        databases.Add(new DatabaseDefinition { Name = dr[0].ToString() });
                    }
                }
            }

            return databases;
        }

        #region GetDatabases Methods

        private DbConnectionStringBuilder GetConnectionStringBuilder(ConnectionInformation connectionInformation) => databaseFactory.DbConnectionStringBuilderFactory(connectionInformation);

        private DbConnection ConnectToDatabase(DatabaseType databaseType, string connectionString) => databaseFactory.DbConnectionFactory(databaseType, connectionString);

        private DbCommand GenerateQuery(DbConnection connection, string query)
        {
            DbCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            return command;
        }

        #endregion GetDatabases Methods

        public IEnumerable<TableDefinition> GetTables(ConnectionInformation connectionInformation, DatabaseDefinition databaseDefinition) //TODO: Check if the user has privileges to view given database
        {
            List<TableDefinition> tables = new List<TableDefinition>();

            DbConnectionStringBuilder builder = GetConnectionStringBuilder(connectionInformation);

            using (DbConnection connection = ConnectToDatabase(connectionInformation.DatabaseType, builder.ConnectionString))
            {
                var query = queryFactory.GetQuery(connectionInformation.DatabaseType);
                DbCommand command = GenerateQuery(connection, query.ShowTables(databaseDefinition.Name));

                connection.Open();

                using (IDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        tables.Add(new TableDefinition { Name = $"{dr[1].ToString()}.{dr[2].ToString()}" });
                    }
                }

            }

            return tables;
        }
    }
}