using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SqlDatabaseManager.Application.Authentication;

namespace SqlDatabaseManager.Web.Filters
{
    public class SessionNotFoundFilter : ExceptionFilterAttribute
    {
        public SessionNotFoundFilter()
        {
            Order = 1000;
        }

        public override void OnException(ExceptionContext context)
        {
            if (!(context.Exception is SessionException))
            {
                return;
            }

            context.Result = new ObjectResult(context.Exception.Message)
            {
                StatusCode = StatusCodes.Status404NotFound
            };
        }
    }
}