namespace SqlDatabaseManager.Domain.Query
{
    public class MsSQLQueryCommand : IQueryCommand
    {
        public string ShowDatabases() => "SELECT name from sys.databases;";

        public string ShowTables(string databaseName) => $"USE [{databaseName}]; SELECT TABLE_NAME FROM information_schema.tables;";

        public string ShowTableContents(string databaseName, string tableName) => $"USE [{databaseName}]; select * from [{tableName}];";
    }
}