namespace SqlDatabaseManager.Domain.Query
{
    public class MsSQLQueryCommand : IQueryCommand
    {
        public string ShowDatabases() => "SELECT name from sys.databases;";

        public string ShowDatabasesWithAccess() => "SELECT name FROM sys.sysdatabases WHERE HAS_DBACCESS(name) = 1";

        public string ShowTables(string databaseName) => $"USE [{databaseName}]; SELECT * FROM information_schema.tables;";

    }
}