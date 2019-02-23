using Microsoft.AspNetCore.Mvc;
using SqlDatabaseManager.Base.Logics;
using SqlDatabaseManager.Web.Models;
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
            nameof(ConnectionInformationViewModel.ServerAddress), nameof(ConnectionInformationViewModel.Login),
            nameof(ConnectionInformationViewModel.Password), nameof(ConnectionInformationViewModel.DatabaseType))]
        ConnectionInformationViewModel connectionViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            ConnectionInformation connection = new ConnectionInformation();
            connection.ServerAddress = connectionViewModel.ServerAddress;
            connection.Login = connectionViewModel.Login;
            connection.Password = connectionViewModel.Password;
            connection.DatabaseType = connectionViewModel.DatabaseType.Value;

            var connectionSuccess = _loginLogic.ConnectToDatabase(connection);

            if (connectionSuccess)
                return RedirectToAction("Index", "Database", connection);
            else
                return View(); // TODO: Return view with error or handle it in js
        }
    }
}