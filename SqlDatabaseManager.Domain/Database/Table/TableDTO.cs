using System.Data;

namespace SqlDatabaseManager.Domain.Database.Table
{
    public class TableDTO
    {
        public string Name { get; set; }
        public DataSet TableContents { get; set; }
    }
}