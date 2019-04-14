namespace SqlDatabaseManager.Domain.Query
{
    public class MySQLQueryCommand : IQueryCommand
    {
        public string ShowDatabases() => "show databases;";

        // In MySql you cannot view databases that you don't have access to
        public string ShowDatabasesWithAccess() => "show databases;";

        public string ShowTables(string databaseName) => $"SHOW TABLES IN {databaseName};";

        public string ShowTableContents(string databaseName, string tableName) => $"select * from {databaseName}.{tableName};";
    }
}