using System;
using Org.BouncyCastle.Bcpg;

namespace SignatureGenerator
{
    class PgpGenerator
    {
        public static string GenerateDatSignature(byte[] clearData, char[] passPhrase, string fileName)
        {
            var bytes = ByteArrayHandler.Encrypt(clearData, passPhrase, fileName, SymmetricKeyAlgorithmTag.Cast5, false);
            string result = Convert.ToBase64String(bytes);
            return result;
        }
        public static string Decrypt(string passPhrase)
        {
            string result = "ByteArrayHandler.";
            return result;
        }
    }
}
