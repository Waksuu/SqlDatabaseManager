using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace SqlDatabaseManager.Web.Filters
{
    public class GenericDatabaseExceptionFilter : ExceptionFilterAttribute
    {
        public GenericDatabaseExceptionFilter()
        {
            Order = 2000;
        }

        public override void OnException(ExceptionContext context)
        {
            if (!(context.Exception is Exception))
            {
                return;
            }

            context.Result = new ObjectResult(context.Exception.Message)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }
}