﻿using Backend.Interfaces;
using Backend.Models.Token;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private List<Token> listTokens;

        public AuthenticationService()
        {
            listTokens = new List<Token>();
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

            listTokens.Add(token);
            return token;
        }

        public bool VerifyToken(string token)
        {
            if (listTokens.Any(t => t.Value == token &&
                t.ExpirationDate > DateTime.Now.ToLocalTime()))
                return true;

            return false;
        }
    }
}
