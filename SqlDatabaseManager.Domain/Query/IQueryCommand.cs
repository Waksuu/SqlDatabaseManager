namespace SqlDatabaseManager.Domain.Query
{
    public interface IQueryCommand
    {
        string ShowDatabases();

        string ShowDatabasesWithAccess();

        string ShowTables(string databaseName);

        string ShowTableContents(string databaseName, string tableName);
    }
}