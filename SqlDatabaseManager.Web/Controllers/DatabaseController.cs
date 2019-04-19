using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlDatabaseManager.Application.Database;
using SqlDatabaseManager.Application.Login;
using SqlDatabaseManager.Domain.Database;
using SqlDatabaseManager.Domain.Login;
using SqlDatabaseManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace SqlDatabaseManager.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpPost("[action]")]
        public ActionResult<LoginResultDTO> Login(ConnectionInformationViewModel connectionInformationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var connectionInformation = Mapper.Mapper.ConnectionInformationMapper(connectionInformationViewModel);
            var loginResult = databaseConnectionApplicationService.CreateDatabaseConnection(connectionInformation);

            return loginResult;
        }

        [HttpDelete("[action]")]
        public IActionResult Logout(Guid sessionId)
        {
            databaseConnectionApplicationService.LogoutFromDatabase(sessionId);

            HttpContext.Session.Clear();

            return RedirectToAction(nameof(Login));
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<DatabaseDTO>> GetDatabases(Guid sessionId)
        {
            IEnumerable<DatabaseDTO> databases = null;

            try
            {
                databases = databaseApplicationService.GetDatabasesFromServer(sessionId);
            }
            catch (DbException e)
            {
                //return StatusCode(StatusCodes.Status400BadRequest, e.Message);
                return NotFound();
            }

            return Ok(databases.ToList());
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<TableDTO>> GetTables(Guid sessionId, string databaseName)
        {
            IEnumerable<TableDTO> tables = null;

            try
            {
                tables = databaseApplicationService.GetTables(sessionId, databaseName);
            }
            catch (DbException e)
            {
                //return StatusCode(StatusCodes.Status400BadRequest, e.Message);
                return NotFound();
            }

            return Ok(tables.ToList());
        }

        [HttpGet("[action]")]
        public ActionResult<TableDTO> GetTableContents(Guid sessionId, string databaseName, string tableName)
        {
            TableDTO tableDefinition = null;

            try
            {
                tableDefinition = databaseApplicationService.GetTableContents(sessionId, databaseName, tableName);
            }
            catch (DbException e)
            {
                //return StatusCode(StatusCodes.Status400BadRequest, e.Message);
                return NotFound();
            }

            return Ok(tableDefinition);
        }
    }
}