using SqlDatabaseManager.Domain.ObjectExplorerData;
using System;
using System.Threading.Tasks;

namespace SqlDatabaseManager.Domain.Database
{
    public interface IDatabaseService
    {
        Task<ObjectExplorerDefinition> GetObjectExplorerDataAsync(Guid sessionId);
    }
}