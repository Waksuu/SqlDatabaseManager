﻿using SqlDatabaseManager.Domain.Connection;
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
                var queryCommand = queryFactory.GetQuery(connectionInformation.DatabaseType);
                DbCommand command = GenerateCommand(connection, queryCommand.ShowDatabases());

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

            using (DbConnection connection = ConnectToDatabase(connectionInformation.DatabaseType, builder.ConnectionString))
            {
                var queryCommand = queryFactory.GetQuery(connectionInformation.DatabaseType);
                DbCommand command = GenerateCommand(connection, queryCommand.ShowDatabasesWithAccess());

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

        public IEnumerable<TableDefinition> GetTables(ConnectionInformation connectionInformation, string databaseName) //TODO: Check if the user has privileges to view for given database
        {
            List<TableDefinition> tables = new List<TableDefinition>();

            DbConnectionStringBuilder builder = GetConnectionStringBuilder(connectionInformation);

            using (DbConnection connection = ConnectToDatabase(connectionInformation.DatabaseType, builder.ConnectionString))
            {
                var queryCommand = queryFactory.GetQuery(connectionInformation.DatabaseType);
                DbCommand command = GenerateCommand(connection, queryCommand.ShowTables(databaseName));

                connection.Open();

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = string.Empty;
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            name += reader[i].ToString() + ".";
                        }

                        name = name.TrimEnd('.');
                        tables.Add(new TableDefinition { Name = name });
                    }
                }
            }

            return tables;
        }


        #region Shared Methods

        private DbConnectionStringBuilder GetConnectionStringBuilder(ConnectionInformation connectionInformation) => databaseFactory.DbConnectionStringBuilderFactory(connectionInformation);

        private DbConnection ConnectToDatabase(DatabaseType databaseType, string connectionString) => databaseFactory.DbConnectionFactory(databaseType, connectionString);

        private DbCommand GenerateCommand(DbConnection connection, string query)
        {
            DbCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            return command;
        }

        #endregion Shared Methods
    }
}