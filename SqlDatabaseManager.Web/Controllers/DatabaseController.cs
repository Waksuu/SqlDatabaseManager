using Microsoft.AspNetCore.Mvc;
using SqlDatabaseManager.Application.Database;
using SqlDatabaseManager.Application.Connection;
using SqlDatabaseManager.Application.Authentication;
using SqlDatabaseManager.Domain.Database;
using SqlDatabaseManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlDatabaseManager.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : Controller
    {
        private readonly IDatabaseApplicationService databaseApplicationService;
        private readonly IDatabaseConnectionApplicationService databaseConnectionApplicationService;

        public DatabaseController(IDatabaseApplicationService databaseApplicationService, IDatabaseConnectionApplicationService databaseConnectionApplicationService)
        {
            this.databaseApplicationService = databaseApplicationService;
            this.databaseConnectionApplicationService = databaseConnectionApplicationService;
        }

        [HttpPost("[action]")]
        public ActionResult<Guid> Login(ConnectionInformationViewModel connectionInformationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Guid sessionId = Guid.Empty;

            var connectionInformation = Mapper.Mapper.ConnectionInformationMapper(connectionInformationViewModel);

            try
            {
                sessionId = databaseConnectionApplicationService.CreateDatabaseConnection(connectionInformation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(sessionId);
        }

        [HttpDelete("[action]")]
        public ActionResult Logout(Guid sessionId)
        {
            try
            {
                databaseConnectionApplicationService.LogoutFromDatabase(sessionId);
            }
            catch(SessionException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<DatabaseDTO>> GetDatabases(Guid sessionId)
        {
            IEnumerable<DatabaseDTO> databases = null;

            try
            {
                databases = databaseApplicationService.GetDatabasesFromServer(sessionId);
            }
            catch (SessionException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(databases);
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<TableDTO>> GetTables(Guid sessionId, string databaseName)
        {
            IEnumerable<TableDTO> tables = null;

            try
            {
                tables = databaseApplicationService.GetTables(sessionId, databaseName);
            }
            catch (SessionException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(tables);
        }

        [HttpGet("[action]")]
        public ActionResult<TableDTO> GetTableContents(Guid sessionId, string databaseName, string tableName)
        {
            TableDTO tableDefinition = null;

            try
            {
                tableDefinition = databaseApplicationService.GetTableContents(sessionId, databaseName, tableName);
            }
            catch (SessionException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(tableDefinition);
        }
    }
}