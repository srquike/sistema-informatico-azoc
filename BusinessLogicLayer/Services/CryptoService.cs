using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLogicLayer.Services
{
    public class CryptoService
    {
        public static string EncodePassword(string originalPassword)
        {
            SHA1 sHA1 = new SHA1CryptoServiceProvider();

            byte[] input = (new UnicodeEncoding()).GetBytes(originalPassword);
            byte[] hash = sHA1.ComputeHash(input);

            return Convert.ToBase64String(hash);
        }
    }
}
