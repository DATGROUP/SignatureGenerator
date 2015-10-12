using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;

namespace SignatureGenerator
{
    class Hash
    {
        public static string calculateSHA256Hash(string input, Encoding encoding)
        {
            // step 1, calculate SHA-256 hash from input
            SHA256Managed shaM = new SHA256Managed();
            byte[] inputBytes = encoding.GetBytes(input);
            byte[] hash = shaM.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }   
    }
}
