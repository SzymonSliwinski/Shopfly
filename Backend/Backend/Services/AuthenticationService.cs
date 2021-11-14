using Common.Interfaces;
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

        public bool Authenticate(string email, string password)//todo password
        {
            var testEmail = "a@a.pl";
            var testPass = "123";
            //to do compare with users in db

            return (
                (email == testEmail) &&
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

        public void RemoveToken(string token)
        {
            _listTokens.Remove(_listTokens.Where(t => t.Value == token).Single());
        }
    }
}
