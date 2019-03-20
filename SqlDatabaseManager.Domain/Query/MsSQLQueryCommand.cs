namespace SqlDatabaseManager.Domain.Query
{
    public class MsSQLQueryCommand : IQueryCommand
    {
        public string ShowDatabases() => "SELECT name from sys.databases;";

        public string ShowDatabasesWithAccess() => "SELECT name FROM sys.sysdatabases WHERE HAS_DBACCESS(name) = 1";

        public string ShowTables(string databaseName) => $"USE [{databaseName}]; SELECT TABLE_SCHEMA, TABLE_NAME FROM information_schema.tables;";

        public string ShowTableContents(string tableName, string databaseName) => $"select * from [{databaseName}].{tableName}";
    }
}