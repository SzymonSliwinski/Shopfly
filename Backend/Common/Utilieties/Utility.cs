using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Common.Utilieties
{
    public class Utility
    {
        /// <summary>
        /// return path where photos of settings are stored and name for them by universal time to be sure files are unique
        /// </summary>
        /// <returns></returns>
        public static (string, string) GetSettingsPhotosPathAndUniqueFileName()
        {
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\..\\..\\Frontend\\src\\assets\\settings\\".ToString();
            var fileName = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();

            return (filePath, fileName);
        }


        public static string GetHashedPassword(string plainPassword)
        {
            string salt = "YOMENIK";
            using SHA256 sha256Hash = SHA256.Create();
            var result = sha256Hash.ComputeHash("");

            return builder.ToString();
        }

    }
}
