using System.Collections.Generic;

namespace SqlDatabaseManager.Domain.ObjectExplorerData
{
    public class ObjectExplorerDefinition
    {
        public IEnumerable<DatabaseDefinition> DatabaseDefinitions { get; set; }
    }
}