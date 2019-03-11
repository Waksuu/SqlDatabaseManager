using System;
using System.Collections.Generic;

namespace SqlDatabaseManager.Domain.ObjectExplorerData
{
    public class DatabaseDefinition
    {
        public string Name { get; set; }
        public IEnumerable<TableDefinition> Tables { get; set; }

        public override bool Equals(object obj)
        {
            var definition = obj as DatabaseDefinition;
            return definition != null &&
                   Name == definition.Name;
        }

        public override int GetHashCode() => HashCode.Combine(Name);
    }
}