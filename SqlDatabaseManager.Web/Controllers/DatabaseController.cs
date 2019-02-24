using Microsoft.AspNetCore.Mvc;
using SqlDatabaseManager.Base.Logics;
using SqlDatabaseManager.Base.Models;
using System.Collections.Generic;

namespace SqlDatabaseManager.Web.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly IDatabaseLogic _databaseLogic;

        public DatabaseController(IDatabaseLogic databaseLogic)
        {
            _databaseLogic = databaseLogic;
        }

        public IActionResult Index(ConnectionInformation connection)
        {
            var databases = _databaseLogic.GetDatabases(connection);
            return View(databases);
        }
    }
}