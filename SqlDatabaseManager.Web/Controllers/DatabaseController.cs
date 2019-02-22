using Microsoft.AspNetCore.Mvc;
using SqlDatabaseManager.Base.Logics;
using SqlDatabaseManager.Base.Models;
using SqlDatabaseManager.Base.Repositories;

namespace SqlDatabaseManager.Web.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly ILoginLogic _loginLogic;

        public DatabaseController(ILoginLogic loginLogic)
        {
            _loginLogic = loginLogic;
        }

        [HttpPost]
        public IActionResult Index([Bind(
            nameof(ConnectionInformation.ServerAddress), nameof(ConnectionInformation.Login),
            nameof(ConnectionInformation.Password), nameof(ConnectionInformation.DatabaseType))]
        ConnectionInformation connection)
        {
            var databases = _loginLogic.GetDatabasesName(connection);
            return View(databases);
        }
    }
}