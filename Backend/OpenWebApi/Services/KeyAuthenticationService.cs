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
        private AppDbContext _context;

        public KeyAuthenticationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckIsKeyHasAccessToTableAndMethod(string key, TableType table, HttpMethodType method)
        {
            var dbFromKey =
            await _context.ApiAccessKeys
                .Where(a => a.Key == key)
                .SingleOrDefaultAsync();

            if (dbFromKey == null)
                return false;

            var existingKeyForMethodInTable = _context.ApiKeysTablesMethods
                .Where(a => a.ApiAccessKeyId == dbFromKey.Id)
                .Where(a => a.HttpMethodId == (int)method)
                .Where(a => a.TableId == (int)table)
                .SingleOrDefault();

            if (existingKeyForMethodInTable != null)
                return true;

            return false;
        }
    }
}
