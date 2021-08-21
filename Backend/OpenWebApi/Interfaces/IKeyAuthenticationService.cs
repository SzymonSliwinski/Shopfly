using Common.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWebApi.Interfaces
{
    interface IKeyAuthenticationService
    {
        Task<bool> CheckIsKeyHasAccessToTableAndMethod(string key, TableType table, HttpMethodType method);

    }
}
