using Microsoft.AspNetCore.Mvc;
using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Database;
using SqlDatabaseManager.Domain.Login;
using SqlDatabaseManager.Web.Models;
using System;

namespace SqlDatabaseManager.Web.Controllers
{
    public class DatabaseController : Controller
    {
        private const string connection = "connection";

        private readonly IDatabaseLogic databaseLogic;
        private readonly ILoginLogic loginLogic;

        public DatabaseController(IDatabaseLogic databaseLogic, ILoginLogic loginLogic)
        {
            this.databaseLogic = databaseLogic;
            this.loginLogic = loginLogic;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(ConnectionInformationViewModel connectionViewModel)
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

            return RedirectToAction("Index");
        }

        #region Login Methods

        private bool ModelIsIncomplete() => !ModelState.IsValid;

        private ConnectionInformation Map(ConnectionInformationViewModel connectionViewModel) => Mapper.Mapper.ConnectionInformationMapper(connectionViewModel);

        private bool CheckIfConnectionIsValid(ConnectionInformation connection) => loginLogic.ConnectToDatabase(connection);

        private bool ConnectionFailed(bool connectionSuccess) => !connectionSuccess;

        private Guid GenerateNewSession(ConnectionInformation connection)
        {
            Guid sessionId = Guid.NewGuid();
            DatabaseConnection.instance.SetConnection(sessionId, connection);
            return sessionId;
        }

        #endregion Login Methods

        public IActionResult Index()
        {
            Guid sessionId = Guid.Empty;
            ValidateSessionCookie();
            sessionId = GetSessionCookie();

            var connectionInformation = DatabaseConnection.instance.GetConnection(sessionId);

            var databases = databaseLogic.GetDatabases(connectionInformation);

            return View(databases);
        }

        #region Index Methods

        private void ValidateSessionCookie()
        {
            if (!Request.Cookies.ContainsKey(connection))
            {
                throw new InvalidOperationException(Domain.Properties.Resources.SessionError);
            }
        }

        private Guid GetSessionCookie()
        {
            if (!Guid.TryParse(Request.Cookies[connection], out Guid sessionId) || sessionId == Guid.Empty)
            {
                throw new InvalidCastException(Domain.Properties.Resources.InvalidSessionCast);
            }

            return sessionId;
        }

        #endregion Index Methods
    }
}