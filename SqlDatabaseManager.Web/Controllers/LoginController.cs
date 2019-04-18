using Microsoft.AspNetCore.Mvc;
using SqlDatabaseManager.Application.Login;
using SqlDatabaseManager.Domain.Login;
using SqlDatabaseManager.Web.Models;
using System;

namespace SqlDatabaseManager.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IDatabaseConnectionApplicationService databaseConnectionApplicationService;

        public LoginController(IDatabaseConnectionApplicationService databaseConnectionApplicationService)
        {
            this.databaseConnectionApplicationService = databaseConnectionApplicationService;
        }

        [HttpPost]
        [Route("[action]")]
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
    }
}