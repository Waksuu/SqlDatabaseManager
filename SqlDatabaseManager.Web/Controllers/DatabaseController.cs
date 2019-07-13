﻿using Microsoft.AspNetCore.Mvc;
using SqlDatabaseManager.Application.Authentication;
using SqlDatabaseManager.Application.Connection;
using SqlDatabaseManager.Application.Database;
using SqlDatabaseManager.Domain.Database;
using SqlDatabaseManager.Domain.Database.Table;
using SqlDatabaseManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlDatabaseManager.Web.Controllers
{
    [ApiController]
    [Route("api/database")]
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
        public ActionResult<Guid> Login(ConnectionInformationViewModel connectionInformationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var connectionInformation = Mapper.Mapper.ConnectionInformationMapper(connectionInformationViewModel);
            Guid sessionId;

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

        [HttpDelete("logout")]
        public ActionResult Logout(Guid sessionId)
        {
            try
            {
                databaseConnectionApplicationService.LogoutFromDatabase(sessionId);
            }
            catch (SessionException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<DatabaseDTO>> GetDatabases(Guid sessionId)
        {
            IEnumerable<DatabaseDTO> databases;
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

        [HttpGet("tables")]
        public ActionResult<IEnumerable<TableDTO>> GetTables(Guid sessionId, string databaseName)
        {
            IEnumerable<TableDTO> tables;
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

        [HttpGet("table-contents")]
        public ActionResult<TableDTO> GetTableContents(Guid sessionId, string databaseName, string tableName)
        {
            TableDTO tableDefinition;
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