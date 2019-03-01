using Microsoft.AspNetCore.Mvc;
using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Database;
using SqlDatabaseManager.Domain.Login;
using SqlDatabaseManager.Domain.Security;
using SqlDatabaseManager.Web.Models;
using System;

namespace SqlDatabaseManager.Web.Controllers
{
    public class DatabaseController : Controller
    {
        private const string connection = "connection";

        private readonly IDatabaseLogic databaseLogic;
        private readonly IDatabaseConnectionService databaseConnectionService;
        private readonly ISession session;

        public DatabaseController(IDatabaseLogic databaseLogic, IDatabaseConnectionService databaseConnectionService, ISession session)
        {
            this.databaseLogic = databaseLogic;
            this.databaseConnectionService = databaseConnectionService;
            this.session = session;
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

            ConnectionInformation connectionInformation = Map(connectionViewModel);

            var loginResult = databaseConnectionService.CreateDatabaseConnection(connectionInformation);

            if (ErrorOccured(loginResult))
            {
                ViewBag.LoginError = loginResult.ErrorMessage;

                return View();
            }

            Response.Cookies.Append("connection", loginResult.SessionId.ToString());

            return RedirectToAction("Index");
        }

        #region Login Methods

        private bool ModelIsIncomplete() => !ModelState.IsValid;

        private ConnectionInformation Map(ConnectionInformationViewModel connectionViewModel) => Mapper.Mapper.ConnectionInformationMapper(connectionViewModel);

        private bool ErrorOccured(LoginResult loginResult) => !string.IsNullOrWhiteSpace(loginResult.ErrorMessage);

        #endregion Login Methods

        public IActionResult Index()
        {
            Guid sessionId = Guid.Empty;
            ValidateSessionCookie();
            sessionId = GetSessionCookie();

            ConnectionInformation connectionInformation = session.GetSession(sessionId);

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