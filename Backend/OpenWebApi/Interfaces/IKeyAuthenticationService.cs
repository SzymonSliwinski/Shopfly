using Common;
using Common.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWebApi.Interfaces
{
    public interface IKeyAuthenticationService
    {
        Task<bool> CheckIsKeyHasAccessToTableAndMethod(AppDbContext context, string key, TableType table, HttpMethodType method);

    }
}
