using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(salt + plainPassword));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

    }
}
