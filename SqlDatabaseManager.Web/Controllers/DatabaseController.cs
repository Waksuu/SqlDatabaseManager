using Microsoft.AspNetCore.Mvc;
using SqlDatabaseManager.Base.Database;
using SqlDatabaseManager.Service.Database;
using System;

namespace SqlDatabaseManager.Web.Controllers
{
    public class DatabaseController : Controller
    {
        private const string connection = "connection";
        private readonly IDatabaseLogic _databaseLogic;

        public DatabaseController(IDatabaseLogic databaseLogic)
        {
            _databaseLogic = databaseLogic;
        }

        public IActionResult Index()
        {
            Guid sessionId = Guid.Empty;
            ValidateSessionCookie();
            sessionId = GetSessionCookie();

            var connectionInformation = DatabaseConnection._instance.GetConnection(sessionId);

            var databases = _databaseLogic.GetDatabases(connectionInformation);

            return View(databases);
        }

        #region Private Methods

        private void ValidateSessionCookie()
        {
            if (!Request.Cookies.ContainsKey(connection))
            {
                throw new InvalidOperationException(Base.Properties.Resources.SessionError);
            }
        }

        private Guid GetSessionCookie()
        {
            if (!Guid.TryParse(Request.Cookies[connection], out Guid sessionId) || sessionId == Guid.Empty)
            {
                throw new InvalidCastException(Base.Properties.Resources.InvalidSessionCast);
            }

            return sessionId;
        }

        #endregion Private Methods
    }
}