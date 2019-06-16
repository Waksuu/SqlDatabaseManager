using SqlDatabaseManager.Domain.Database;
using System.ComponentModel.DataAnnotations;

namespace SqlDatabaseManager.Web.Models
{
    public class ConnectionInformationViewModel
    {
        [Required]
        public string ServerAddress { get; set; }

        [Required]
        public string Login { get; set; }

        public string Password { get; set; }

        [Required]
        public DatabaseType? DatabaseType { get; set; }
    }
}