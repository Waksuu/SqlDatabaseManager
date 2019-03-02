namespace SqlDatabaseManager.Domain.Query
{
    public class MsSQLQuery : IQuery
    {
        public string ShowDatabases() => "SELECT name from sys.databases;";

        public string ShowTables(string databaseName) => $"USE [{databaseName}]; SELECT * FROM information_schema.tables;";

    }
}