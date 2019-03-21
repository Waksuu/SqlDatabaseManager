using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Database;
using SqlDatabaseManager.Domain.Login;
using SqlDatabaseManager.Web.Models;
using System;
using System.Threading.Tasks;
using SqlDatabaseManager.Domain.ObjectExplorerData;
using System.Data.Common;

namespace SqlDatabaseManager.Web.Controllers
{
    public class DatabaseController : Controller
    {
        private const string connection = "connection";

        private readonly IDatabaseService databaseService;
        private readonly IDatabaseConnectionService databaseConnectionService;

        public DatabaseController(IDatabaseService databaseService, IDatabaseConnectionService databaseConnectionService)
        {
            this.databaseService = databaseService;
            this.databaseConnectionService = databaseConnectionService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(ConnectionInformationViewModel connectionViewModel)
        {
            if (ModelIsIncomplete())
            {
                return View();
            }

            ConnectionInformation connectionInformation = Map(connectionViewModel);

            var loginResult = await databaseConnectionService.CreateDatabaseConnectionAsync(connectionInformation);

            if (ErrorOccured(loginResult))
            {
                ViewBag.LoginError = loginResult.ErrorMessage;

                return View();
            }

            HttpContext.Session.Set("connection", loginResult.SessionId.ToByteArray());
            HttpContext.Session.SetString("logged", "true");

            return RedirectToAction("Index");
        }

        #region Login Methods

        private bool ModelIsIncomplete() => !ModelState.IsValid;

        private ConnectionInformation Map(ConnectionInformationViewModel connectionViewModel) => Mapper.Mapper.ConnectionInformationMapper(connectionViewModel);

        private bool ErrorOccured(LoginResult loginResult) => !string.IsNullOrWhiteSpace(loginResult.ErrorMessage);

        #endregion Login Methods

        public async Task<IActionResult> Index()
        {
            Guid sessionId = GetSessionId();

            var objectExplorer = await databaseService.GetObjectExplorerDataAsync(sessionId);

            return View(objectExplorer);
        }

        public IActionResult Table(string tableName, string databaseName)
        {
            Guid sessionId = GetSessionId();
            TableDefinition tableDefinition = null;
            
            try
            {
                tableDefinition = databaseService.GetTableContents(sessionId, tableName, databaseName);
            }
            catch(DbException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }

            return View(tableDefinition);
        }

        public IActionResult Logout()
        {
            Guid sessionId = GetSessionId();
            databaseConnectionService.LogoutFromDatabase(sessionId);

            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }

        #region Session Methods

        private Guid GetSessionId()
        {
            Guid sessionId = Guid.Empty;
            sessionId = GetSessionCookie();
            return sessionId;
        }

        private Guid GetSessionCookie()
        {
            byte[] sessionId;
            if (!HttpContext.Session.TryGetValue("connection", out sessionId))
            {
                throw new InvalidCastException(Domain.Properties.Resources.SessionError);
            }

            return new Guid(sessionId);
        }

        #endregion Session Methods
    }
}