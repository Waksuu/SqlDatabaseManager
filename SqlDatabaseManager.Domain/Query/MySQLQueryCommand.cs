namespace SqlDatabaseManager.Domain.Query
{
    public class MySQLQueryCommand : IQueryCommand
    {
        public string ShowDatabases() => "show databases;";

        public string ShowDatabasesWithAccess()
        {
            throw new System.NotImplementedException();
        }

        public string ShowTables(string databaseName) => $"SHOW TABLES IN {databaseName};";
    }
}