using SqlDatabaseManager.Domain.Database;

namespace SqlDatabaseManager.Domain.Query
{
    public interface IQueryFactory
    {
        IQueryCommand GetQueryCommand(DatabaseType databaseType);
    }
}