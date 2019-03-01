﻿using Microsoft.AspNetCore.Mvc;
using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Database;
using SqlDatabaseManager.Domain.Login;
using SqlDatabaseManager.Domain.Security;
using SqlDatabaseManager.Web.Models;
using System;
using System.Threading.Tasks;

namespace SqlDatabaseManager.Web.Controllers
{
    public class DatabaseController : Controller
    {
        private const string connection = "connection";

        private readonly IDatabaseStartupService databaseStartupService;
        private readonly IDatabaseConnectionService databaseConnectionService;
        private readonly ISession session;

        public DatabaseController(IDatabaseStartupService databaseStartupService, IDatabaseConnectionService databaseConnectionService, ISession session)
        {
            this.databaseStartupService = databaseStartupService;
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

            Response.Cookies.Append("connection", loginResult.SessionId.ToString());

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

            var databases = await databaseStartupService.GetDatabaseDefinitionsAsync(sessionId);

            return View(databases);
        }

        #region Index Methods

        private Guid GetSessionId()
        {
            Guid sessionId = Guid.Empty;
            ValidateSessionCookie();
            sessionId = GetSessionCookie();
            return sessionId;
        }

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