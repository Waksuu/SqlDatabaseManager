using SqlDatabaseManager.Domain.Database;
using System.ComponentModel.DataAnnotations;

namespace SqlDatabaseManager.Web.Models
{
    public class ConnectionInformationViewModel
    {
        [Required(ErrorMessage = "Field Database Address is required")]
        public string ServerAddress { get; set; }

        [Required]
        public string Login { get; set; }

        public string Password { get; set; }

        [Required(ErrorMessage = "Please select Database Type")]
        public DatabaseType? DatabaseType { get; set; }
    }
}