namespace SqlDatabaseManager.Domain.Query
{
    public class MySQLQuery : IQuery
    {
        public string ShowDatabases() => "show databases;";

        public string ShowTables(string databaseName) => $"SHOW TABLES IN {databaseName};";
    }
}