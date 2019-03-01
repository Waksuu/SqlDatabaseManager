using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlDatabaseManager.Domain.Database
{
    public interface IDatabaseStartupService
    {
        Task<IEnumerable<DatabaseDefinition>> GetDatabaseDefinitionsAsync(Guid sessionId);
    }
}