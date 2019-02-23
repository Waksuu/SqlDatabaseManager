using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SqlDatabaseManager.Base.Logics;
using SqlDatabaseManager.Base.Models;

namespace SqlDatabaseManager.Web.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILoginLogic _loginLogic;

        public LoginController(ILoginLogic loginLogic)
        {
            _loginLogic = loginLogic;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  
        public IActionResult Index([Bind(
            nameof(ConnectionInformation.ServerAddress), nameof(ConnectionInformation.Login),
            nameof(ConnectionInformation.Password), nameof(ConnectionInformation.DatabaseType))]
        ConnectionInformation connection)
        {
            var connectionSuccess = _loginLogic.ConnectToDatabase(connection);

            if (connectionSuccess)
                return RedirectToAction("Index", "Database", connection);
            else
                return View(); // TODO: Return view with error or handle it in js
        }
    }
}
