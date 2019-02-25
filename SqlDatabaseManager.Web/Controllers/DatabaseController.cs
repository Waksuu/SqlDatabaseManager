using Microsoft.AspNetCore.Mvc;
using SqlDatabaseManager.Base.Database;
using SqlDatabaseManager.Service.Database;
using System;

namespace SqlDatabaseManager.Web.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly IDatabaseLogic _databaseLogic;

        public DatabaseController(IDatabaseLogic databaseLogic)
        {
            _databaseLogic = databaseLogic;
        }

        public IActionResult Index(Guid sessionId)
        {
            var connection = DatabaseConnection._instance.GetSession(sessionId);

            var databases = _databaseLogic.GetDatabases(connection);
            return View(databases);
        }
    }
}