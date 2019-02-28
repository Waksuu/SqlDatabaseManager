namespace SqlDatabaseManager.Domain.Query
{
    public class MySQLQuery : IQuery
    {
        public string ShowDatabases() => "show databases";
    }
}