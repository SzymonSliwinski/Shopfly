using Common.Models.ApiModels;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWebApi.Filters
{
    public class KeyAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public TableType Table { get; set; }
        public HttpMethodsType Method { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {

        }
    }
}
