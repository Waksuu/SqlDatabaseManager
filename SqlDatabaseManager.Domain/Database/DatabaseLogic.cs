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

        public DatabaseLogic(IDatabaseFactory databaseFactory, IQueryFactory queryFactory)
        {
            this.databaseFactory = databaseFactory;
            this.queryFactory = queryFactory;
        }

        public IEnumerable<DatabaseDefinition> GetDatabases(ConnectionInformation connectionInformation)
        {
            List<DatabaseDefinition> databases = new List<DatabaseDefinition>();

            DbConnectionStringBuilder builder = GetConnectionStringBuilder(connectionInformation);

            using (IDbConnection connection = ConnectToDatabase(connectionInformation.DatabaseType, builder.ConnectionString))
            {
                var queryCommand = queryFactory.GetQuery(connectionInformation.DatabaseType);
                IDbCommand command = GenerateCommand(connection, queryCommand.ShowDatabases());

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

        public IEnumerable<DatabaseDefinition> GetDatabasesWithAccess(ConnectionInformation connectionInformation)
        {
            List<DatabaseDefinition> databases = new List<DatabaseDefinition>();

            DbConnectionStringBuilder builder = GetConnectionStringBuilder(connectionInformation);

            using (IDbConnection connection = ConnectToDatabase(connectionInformation.DatabaseType, builder.ConnectionString))
            {
                var queryCommand = queryFactory.GetQuery(connectionInformation.DatabaseType);
                IDbCommand command = GenerateCommand(connection, queryCommand.ShowDatabasesWithAccess());

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

        public IEnumerable<TableDefinition> GetTables(ConnectionInformation connectionInformation, string databaseName)
        {
            List<TableDefinition> tables = new List<TableDefinition>();

            DbConnectionStringBuilder builder = GetConnectionStringBuilder(connectionInformation);

            using (IDbConnection connection = ConnectToDatabase(connectionInformation.DatabaseType, builder.ConnectionString))
            {
                var queryCommand = queryFactory.GetQuery(connectionInformation.DatabaseType);
                IDbCommand command = GenerateCommand(connection, queryCommand.ShowTables(databaseName));

                connection.Open();

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tableName = string.Empty;
                        if (IsNotEmpty(reader))
                            tableName = reader[0].ToString();

                        tables.Add(new TableDefinition { Name = tableName });
                    }
                }
            }

            return tables;
        }

        private bool IsNotEmpty(IDataReader reader) => reader.FieldCount > 0;

        public TableDefinition GetTableContents(ConnectionInformation connectionInformation, string tableName, string databaseName)
        {
            TableDefinition table = new TableDefinition
            {
                TableContents = new DataSet()
            };

            DbConnectionStringBuilder builder = GetConnectionStringBuilder(connectionInformation);

            using (IDbConnection connection = ConnectToDatabase(connectionInformation.DatabaseType, builder.ConnectionString))
            {
                var queryCommand = queryFactory.GetQuery(connectionInformation.DatabaseType);
                IDbCommand command = GenerateCommand(connection, queryCommand.ShowTableContents(tableName, databaseName));

                connection.Open();

                IDbDataAdapter dbDataAdapter = databaseFactory.DataAdapterFactory(connectionInformation.DatabaseType);
                dbDataAdapter.SelectCommand = command;
                dbDataAdapter.Fill(table.TableContents);
            }

            return table;
        }

        #region Shared Methods

        private DbConnectionStringBuilder GetConnectionStringBuilder(ConnectionInformation connectionInformation) => databaseFactory.DbConnectionStringBuilderFactory(connectionInformation);

        private IDbConnection ConnectToDatabase(DatabaseType databaseType, string connectionString) => databaseFactory.DbConnectionFactory(databaseType, connectionString);

        private IDbCommand GenerateCommand(IDbConnection connection, string query)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            return command;
        }

        #endregion Shared Methods
    }
}