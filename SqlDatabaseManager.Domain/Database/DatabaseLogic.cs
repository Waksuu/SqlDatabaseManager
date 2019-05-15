using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Query;
using System.Collections.Generic;
using System.Data;

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

        public IEnumerable<DatabaseDTO> GetDatabases(ConnectionInformationDTO connectionInformation)
        {
            List<DatabaseDTO> databases = new List<DatabaseDTO>();

            string connectionString = GenerateConnectionString(connectionInformation);

            using (IDbConnection connection = ConnectToDatabase(connectionInformation.DatabaseType, connectionString))
            {
                var queryCommand = queryFactory.GetQueryCommand(connectionInformation.DatabaseType);
                IDbCommand command = GenerateCommand(connection, queryCommand.ShowDatabases());

                connection.Open();

                using (IDataReader reader = command.ExecuteReader())
                {
                    ValidateAmountOfFieldsReturnedFromQuery(reader, 1);
                    while (reader.Read())
                    {
                        databases.Add(new DatabaseDTO { Name = reader[0].ToString() });
                    }
                }
            }

            return databases;
        }

        public IEnumerable<TableDTO> GetTables(ConnectionInformationDTO connectionInformation, string databaseName)
        {
            List<TableDTO> tables = new List<TableDTO>();

            string connectionString = GenerateConnectionString(connectionInformation);

            using (IDbConnection connection = ConnectToDatabase(connectionInformation.DatabaseType, connectionString))
            {
                var queryCommand = queryFactory.GetQueryCommand(connectionInformation.DatabaseType);
                IDbCommand command = GenerateCommand(connection, queryCommand.ShowTables(databaseName));

                connection.Open();

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ValidateAmountOfFieldsReturnedFromQuery(reader, 1);
                        string tableName = reader[0].ToString();

                        tables.Add(new TableDTO { Name = tableName });
                    }
                }
            }

            return tables;
        }

        public TableDTO GetTableContents(ConnectionInformationDTO connectionInformation, string databaseName, string tableName)
        {
            TableDTO table = new TableDTO
            {
                TableContents = new DataSet()
            };

            string connectionString = GenerateConnectionString(connectionInformation);

            using (IDbConnection connection = ConnectToDatabase(connectionInformation.DatabaseType, connectionString))
            {
                var queryCommand = queryFactory.GetQueryCommand(connectionInformation.DatabaseType);
                IDbCommand command = GenerateCommand(connection, queryCommand.ShowTableContents(databaseName, tableName));

                connection.Open();

                IDbDataAdapter dbDataAdapter = databaseFactory.DataAdapterFactory(connectionInformation.DatabaseType);
                dbDataAdapter.SelectCommand = command;
                dbDataAdapter.Fill(table.TableContents);
            }
            table.Name = tableName;

            return table;
        }

        #region Shared Methods

        private string GenerateConnectionString(ConnectionInformationDTO connectionInformation) => databaseFactory.DbConnectionStringBuilderFactory(connectionInformation).ConnectionString;

        private IDbConnection ConnectToDatabase(DatabaseType databaseType, string connectionString) => databaseFactory.DbConnectionFactory(databaseType, connectionString);

        private IDbCommand GenerateCommand(IDbConnection connection, string query)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            return command;
        }

        private void ValidateAmountOfFieldsReturnedFromQuery(IDataReader dr, int numberOfFields)
        {
            if (dr.FieldCount != numberOfFields)
                throw new QueryException(string.Format(Domain.Properties.Resources.InvalidFieldCount, numberOfFields));
        }

        #endregion Shared Methods
    }
}