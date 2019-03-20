using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SqlDatabaseManager.Domain.ObjectExplorerData
{
    public class TableDefinition
    {
        public string Name { get; set; }
        public DataSet TableContents { get; set; }
    }
}
