using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlDatabaseManager.Domain.Database
{
    public interface IDatabaseService
    {
        Task<ObjectExplorer> GetObjectExplorerDataAsync(Guid sessionId);
    }
}