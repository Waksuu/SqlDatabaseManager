using Microsoft.AspNetCore.Mvc;
using SqlDatabaseManager.Base.Login;
using SqlDatabaseManager.Service.Database;
using SqlDatabaseManager.Web.Models;
using SSqlDatabaseManager.Base.Connection;
using System;

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
        public IActionResult Index(ConnectionInformationViewModel connectionViewModel)
        {
            if (ModelIsIncomplete())
            {
                return View();
            }

            ConnectionInformation connection = Map(connectionViewModel);

            bool connectionResult = CheckIfConnectionIsValid(connection);

            if (ConnectionFailed(connectionResult))
            {
                return View(); // TODO: Return view with error or handle it in js
            }

            Guid sessionId = GenerateNewSession(connection);

            Response.Cookies.Append("connection", sessionId.ToString());

            return RedirectToAction("Index", "Database");
        }

        #region Private Methods

        private bool ModelIsIncomplete() => !ModelState.IsValid;

        private ConnectionInformation Map(ConnectionInformationViewModel connectionViewModel) => Mapper.Mapper.ConnectionInformationMapper(connectionViewModel);

        private bool CheckIfConnectionIsValid(ConnectionInformation connection) => _loginLogic.ConnectToDatabase(connection);

        private bool ConnectionFailed(bool connectionSuccess) => !connectionSuccess;

        private Guid GenerateNewSession(ConnectionInformation connection)
        {
            Guid sessionId = Guid.NewGuid();
            DatabaseConnection._instance.SetConnection(sessionId, connection);
            return sessionId;
        }

        #endregion Private Methods
    }
}