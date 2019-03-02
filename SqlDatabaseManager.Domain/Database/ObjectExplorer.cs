using System;
using System.Collections.Generic;
using System.Text;

namespace SqlDatabaseManager.Domain.Database
{
    public class ObjectExplorer
    {
        public IEnumerable<DatabaseDefinition> DatabaseDefinitions { get; set; }
    }
}
