using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlDatabaseManager.Application.Database;
using SqlDatabaseManager.Application.Login;
using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Login;
using SqlDatabaseManager.Domain.Database;
using SqlDatabaseManager.Web.Models;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace SqlDatabaseManager.Web.Controllers
{
    public class DatabaseController : Controller
    {
        private const string connection = "connection";
        private const string logged = "logged";

        private readonly IDatabaseApplicationService databaseApplicationService;
        private readonly IDatabaseConnectionApplicationService databaseConnectionApplicationService;

        public DatabaseController(IDatabaseApplicationService databaseApplicationService, IDatabaseConnectionApplicationService databaseConnectionApplicationService)
        {
            this.databaseApplicationService = databaseApplicationService;
            this.databaseConnectionApplicationService = databaseConnectionApplicationService;
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

            ConnectionInformationDTO connectionInformation = Map(connectionViewModel);

            var loginResult = await databaseConnectionApplicationService.CreateDatabaseConnectionAsync(connectionInformation);

            if (ErrorOccured(loginResult))
            {
                ViewBag.LoginError = loginResult.ErrorMessage;

                return View();
            }

            HttpContext.Session.Set(connection, loginResult.SessionId.ToByteArray());
            HttpContext.Session.SetString(logged, "true");

            return RedirectToAction(nameof(Index));
        }

        #region Login Methods

        private bool ModelIsIncomplete() => !ModelState.IsValid;

        private ConnectionInformationDTO Map(ConnectionInformationViewModel connectionViewModel) => Mapper.Mapper.ConnectionInformationMapper(connectionViewModel);

        private bool ErrorOccured(LoginResultDTO loginResult) => !string.IsNullOrWhiteSpace(loginResult.ErrorMessage);

        #endregion Login Methods

        public async Task<IActionResult> Index()
        {
            Guid sessionId = GetSessionId();

            var objectExplorer = await databaseApplicationService.GetDatabasesFromServerAsync(sessionId);

            return View(objectExplorer);
        }

        public IActionResult Table(string tableName, string databaseName)
        {
            Guid sessionId = GetSessionId();
            TableDTO tableDefinition = null;

            try
            {
                tableDefinition = databaseApplicationService.GetTableContents(sessionId, tableName, databaseName);
            }
            catch (DbException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }

            return View(tableDefinition);
        }

        public IActionResult Logout()
        {
            Guid sessionId = GetSessionId();
            databaseConnectionApplicationService.LogoutFromDatabase(sessionId);

            HttpContext.Session.Clear();

            return RedirectToAction(nameof(Login));
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
            if (!HttpContext.Session.TryGetValue(connection, out sessionId))
            {
                throw new InvalidCastException(Domain.Properties.Resources.SessionError);
            }

            return new Guid(sessionId);
        }

        #endregion Session Methods
    }
}