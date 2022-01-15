using Common;
using Common.Interfaces;
using Common.Models.Token;
using Common.Utilieties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopPanelWebApi.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private List<Token> _listTokens;

        public AuthenticationService()
        {
            _listTokens = new List<Token>();
        }

        public Token GenerateToken()
        {
            var token = new Token
            {
                Value = Guid.NewGuid().ToString(),
                ExpirationDate = DateTime.Now.AddMinutes(60).ToLocalTime()
            };

            _listTokens.Add(token);
            return token;
        }

        public bool VerifyToken(string token)
        {
            if (_listTokens.Any(t => t.Value == token &&
                t.ExpirationDate > DateTime.Now.ToLocalTime()))
                return true;

            return false;
        }

        public void RemoveToken(string token)
        {
            var tokenFound = _listTokens.Where(t => t.Value == token).SingleOrDefault();
            if (tokenFound != null)
                _listTokens.Remove(tokenFound);
        }
    }
}
