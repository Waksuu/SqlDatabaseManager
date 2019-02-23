﻿using SqlDatabaseManager.Base.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SqlDatabaseManager.Web.Models
{
    public class ConnectionInformationViewModel
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