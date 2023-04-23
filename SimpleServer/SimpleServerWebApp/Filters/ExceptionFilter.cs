using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Entities.Exceptions;

namespace SimpleServerWebApp.Filters
{
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            try
            {
                throw context.Exception;
            }
            catch (QueryException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 400,
                    Content = context.Exception.Message
                };
            }
            catch (Exception)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 500,
                    Content = "Error inesperado [FILTER]: " + context.Exception.Message
                };
            }
        }
    }
}
