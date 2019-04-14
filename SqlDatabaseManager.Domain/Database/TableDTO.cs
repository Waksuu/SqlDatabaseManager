using System.Data;

namespace SqlDatabaseManager.Domain.Database
{
    public class TableDTO
    {
        public string Name { get; set; }
        public DataSet TableContents { get; set; }
    }
}