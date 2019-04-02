using System;
using System.Collections.Generic;

namespace SqlDatabaseManager.Domain.ObjectExplorerData
{
    public class DatabaseDTO
    {
        public string Name { get; set; }
        public IEnumerable<TableDTO> Tables { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DatabaseDTO definition &&
                   Name == definition.Name;
        }

        public override int GetHashCode() => HashCode.Combine(Name);
    }
}