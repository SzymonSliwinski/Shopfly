using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Backend.Filters
{
    public class TokenAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authService = (IAuthenticationService)context.HttpContext
                .RequestServices
                .GetService(typeof(IAuthenticationService));

            var result = true;
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
                result = false;

            string token = string.Empty;

            if (result)
            {
                token = context.HttpContext
                    .Request
                    .Headers
                    .First(c => c.Key == "Authorization")
                    .Value;

                if (!authService.VerifyToken(token))
                    result = false;
            }

            if (!result)
            {
                context.ModelState.AddModelError("Unauthorized", "No authorization");
                context.Result = new UnauthorizedObjectResult(context.ModelState);
            }
        }
    }
}
