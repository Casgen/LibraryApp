using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DataLayer.Utils
{
    public static class Hasher
    {
        public static string GetHash(string text)
        {
            StringBuilder stringBuilder = new StringBuilder();
            HashAlgorithm sha = SHA256.Create();
            byte[] result = sha.ComputeHash(Encoding.UTF8.GetBytes(text.ToCharArray()));
            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
