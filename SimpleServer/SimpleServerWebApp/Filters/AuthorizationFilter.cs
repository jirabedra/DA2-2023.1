using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Entities;

namespace SimpleServerWebApp.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string headerToken = context.HttpContext.Request.Headers["Authorization"];
            if (headerToken is null)
            {
                context.Result = new ContentResult()
                {
                    Content = "Se requiere un token",
                    StatusCode = 401
                };
            }
            else
            {
                try
                {
                    Guid token = Guid.Parse(headerToken);
                    VerifyToken(token, context);
                }
                catch (FormatException)
                {
                    context.Result = new ContentResult()
                    {
                        Content = "El formato del token es invalido",
                        StatusCode = 401

                    };
                }

            }
        }

        private void VerifyToken(Guid aToken, AuthorizationFilterContext aContext)
        {
            var userLogic = GetUserLogic(aContext);
            if (!userLogic.IsValidToken(aToken))
            {
                aContext.Result = new ContentResult()
                {
                    Content = "Token invalido",
                    StatusCode = 401
                };
            }
            else
            {
                User aUser = userLogic.GetUserByToken(aToken);
                aContext.HttpContext.Items.Add("user", aUser);
            }
        }

        private IUserService GetUserLogic(AuthorizationFilterContext context)
        {
            return context.HttpContext.RequestServices.GetService(typeof(IUserService)) as IUserService;
        }
    }
}

