namespace SqlDatabaseManager.Domain.Query
{
    public class MySQLQueryCommand : IQueryCommand
    {
        public string ShowDatabases() => "show databases;";

        public string ShowTables(string databaseName) => $"SHOW TABLES IN {databaseName};";

        public string ShowTableContents(string databaseName, string tableName) => $"select * from {databaseName}.{tableName};";
    }
}