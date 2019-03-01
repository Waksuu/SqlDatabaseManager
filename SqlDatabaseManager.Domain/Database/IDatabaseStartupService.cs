using System;
using System.Collections.Generic;
using System.Text;

namespace SqlDatabaseManager.Domain.Database
{
    public interface IDatabaseStartupService
    {
        IEnumerable<DatabaseDefinition> GetDatabaseDefinitions(Guid sessionId);
    }
}
