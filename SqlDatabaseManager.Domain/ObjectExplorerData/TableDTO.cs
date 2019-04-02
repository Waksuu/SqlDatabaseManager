using System.Data;

namespace SqlDatabaseManager.Domain.ObjectExplorerData
{
    public class TableDTO
    {
        public string Name { get; set; }
        public DataSet TableContents { get; set; }
    }
}