using Microsoft.AspNetCore.Mvc;
using SqlDatabaseManager.Application.Connection;
using SqlDatabaseManager.Application.Database;
using SqlDatabaseManager.Domain.Database;
using SqlDatabaseManager.Domain.Database.Table;
using SqlDatabaseManager.Web.Filters;
using SqlDatabaseManager.Web.Models;
using System;
using System.Collections.Generic;

namespace SqlDatabaseManager.Web.Controllers
{
    [ApiController]
    [Route("api/databases")]
    public class DatabaseController : Controller
    {
        private readonly IDatabaseApplicationService databaseApplicationService;
        private readonly IDatabaseConnectionApplicationService databaseConnectionApplicationService;

        public DatabaseController(IDatabaseApplicationService databaseApplicationService, IDatabaseConnectionApplicationService databaseConnectionApplicationService)
        {
            this.databaseApplicationService = databaseApplicationService;
            this.databaseConnectionApplicationService = databaseConnectionApplicationService;
        }

        [HttpPost("login")]
        [GenericDatabaseExceptionFilter]
        public ActionResult<Guid> Login(ConnectionInformationViewModel connectionInformationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var connectionInformation = Mapper.Mapper.ConnectionInformationMapper(connectionInformationViewModel);
            Guid sessionId = databaseConnectionApplicationService.CreateDatabaseConnection(connectionInformation);
            return Ok(sessionId);
        }

        [HttpDelete("logout")]
        [SessionNotFoundFilter]
        [GenericDatabaseExceptionFilter]
        public ActionResult Logout(Guid sessionId)
        {
            databaseConnectionApplicationService.LogoutFromDatabase(sessionId);
            return NoContent();
        }

        [HttpGet("")]
        [SessionNotFoundFilter]
        [GenericDatabaseExceptionFilter]
        public ActionResult<IEnumerable<DatabaseDTO>> GetDatabases(Guid sessionId)
        {
            IEnumerable<DatabaseDTO> databases = databaseApplicationService.GetDatabasesFromServer(sessionId);
            return Ok(databases);
        }

        [HttpGet("tables")]
        [SessionNotFoundFilter]
        [GenericDatabaseExceptionFilter]
        public ActionResult<IEnumerable<TableDTO>> GetTables(Guid sessionId, string databaseName)
        {
            IEnumerable<TableDTO> tables = databaseApplicationService.GetTables(sessionId, databaseName);
            return Ok(tables);
        }

        [HttpGet("table-contents")]
        [SessionNotFoundFilter]
        [GenericDatabaseExceptionFilter]
        public ActionResult<TableDTO> GetTableContents(Guid sessionId, string databaseName, string tableName)
        {
            TableDTO tableDefinition = databaseApplicationService.GetTableContents(sessionId, databaseName, tableName);
            return Ok(tableDefinition);
        }
    }
}