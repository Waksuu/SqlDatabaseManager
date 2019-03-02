using System.Collections.Generic;

namespace SqlDatabaseManager.Domain.ObjectExplorerData
{
    public class DatabaseDefinition
    {
        public string Name { get; set; }
        public IEnumerable<TableDefinition> Tables { get; set; }
    }
}