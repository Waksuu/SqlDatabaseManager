using SqlDatabaseManager.Base.Enums;
using System.ComponentModel.DataAnnotations;

namespace SqlDatabaseManager.Base.Models
{
    public class ConnectionInformation
    {
        [Required(ErrorMessage = "Field Database Address is required")]
        public string ServerAddress { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please select Database Type")]
        public DatabaseType? DatabaseType { get; set; }
    }
}