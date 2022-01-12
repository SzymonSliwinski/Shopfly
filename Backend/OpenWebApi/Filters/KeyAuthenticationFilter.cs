using Common;
using Common.Models.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OpenWebApi.Interfaces;
using System;
using System.Linq;

namespace OpenWebApi.Filters
{
    public class KeyAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public TableType Table { get; set; }
        public HttpMethodType Method { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authService = (IKeyAuthenticationService)context.HttpContext
                .RequestServices
                .GetService(typeof(IKeyAuthenticationService));

            var result = true;
            if (!context.HttpContext.Request.Headers.ContainsKey("ApiKey"))
                result = false;

            var key = string.Empty;

            if (result)
            {
                key = context.HttpContext
                    .Request
                    .Headers
                    .First(c => c.Key == "ApiKey")
                    .Value;

                var dbContext = (AppDbContext)context.HttpContext
                 .RequestServices
                  .GetService(typeof(AppDbContext));

                if (!authService.CheckIsKeyHasAccessToTableAndMethod(dbContext, key, Table, Method).Result)
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
