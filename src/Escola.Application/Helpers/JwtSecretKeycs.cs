using System;
using System.Security.Cryptography;
using System.Text;

namespace Enceja.Domain.Helpers
{
    public static class JwtSecretKey
    {
        public static string GenerateSecretKey(int size = 32)
        {
            var keyBytes = new byte[size];
            RandomNumberGenerator.Fill(keyBytes); 
            return Convert.ToBase64String(keyBytes);
        }

        public static byte[] GetKeyBytes(string secretKey)
        {
            return Encoding.UTF8.GetBytes(secretKey);
        }
    }
}
