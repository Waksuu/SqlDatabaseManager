namespace SqlDatabaseManager.Domain.Query
{
    public class MsSQLQuery : IQuery
    {
        public string ShowDatabases() => "SELECT name from sys.databases";
    }
}