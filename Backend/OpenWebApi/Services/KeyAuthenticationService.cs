using Common;
using Common.Models.ApiModels;
using OpenWebApi.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace OpenWebApi.Services
{
    public class KeyAuthenticationService : IKeyAuthenticationService
    {
        public KeyAuthenticationService()
        { }

        public async Task<bool> CheckIsKeyHasAccessToTableAndMethod(AppDbContext context, string key, TableType table, HttpMethodType method)
        {
            var dbFromKey =
            await context.ApiAccessKeys
                .Where(a => a.Key == key)
                .SingleOrDefaultAsync();

            if (dbFromKey == null)
                return false;

            var existingKeyForMethodInTable = context.ApiKeysTablesMethods
                .Where(a => a.ApiAccessKeyId == dbFromKey.Id)
                .Where(a => a.HttpMethod == method)
                .Where(a => a.Table == table)
                .SingleOrDefault();

            if (existingKeyForMethodInTable != null)
                return true;

            return false;

        }
    }
}
