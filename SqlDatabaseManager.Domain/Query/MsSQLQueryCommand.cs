namespace SqlDatabaseManager.Domain.Query
{
    public class MsSQLQueryCommand : IQueryCommand
    {
        public string ShowDatabases() => "SELECT name from sys.databases;";

        public string ShowTables(string databaseName) => $"USE [{databaseName}]; SELECT * FROM information_schema.tables;";

    }
}