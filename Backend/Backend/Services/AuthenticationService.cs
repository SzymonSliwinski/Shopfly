using ShopWebApi.Interfaces;
using Common.Models.Token;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopWebApi.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private List<Token> _listTokens;

        public AuthenticationService()
        {
            _listTokens = new List<Token>();
        }

        public bool Authenticate(string loginOrEmail, string password)//todo password
        {
            var testLogin = "123";
            var testEmail = "456";
            var testPass = "123";
            //to do compare with users in db

            return (
                (loginOrEmail == testLogin || loginOrEmail == testEmail) &&
                 password == testPass);
        }

        public Token GenerateToken()
        {
            var token = new Token
            {
                Value = Guid.NewGuid().ToString(),
                ExpirationDate = DateTime.Now.AddMinutes(20).ToLocalTime()//to do dynamic
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
    }
}
