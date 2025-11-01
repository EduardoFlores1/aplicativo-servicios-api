using Caja.Servicios.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Caja.Servicios.Application.Exception
{
    public class ExceptionManager : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(new BaseExceptionModel { 
                StatusCode = 500,
                ErrorCode = "InternalServerError",
                Message = context.Exception.Message
            });

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
