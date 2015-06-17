using System;
using System.IO;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Security;

namespace SignatureGenerator
{
    class ByteArrayHandler
    {
        public static byte[] Encrypt(byte[] clearData, char[] passPhrase, string fileName, SymmetricKeyAlgorithmTag algorithm, bool armor)
        {
            if (fileName == null)
            {
                fileName = PgpLiteralData.Console;
            }

            byte[] compressedData = Compress(clearData, fileName, CompressionAlgorithmTag.Zip);

            var bOut = new MemoryStream();

            Stream output = bOut;
            if (armor)
            {
                output = new ArmoredOutputStream(output);
            }

            var encGen = new PgpEncryptedDataGenerator(algorithm, new SecureRandom());
            encGen.AddMethod(passPhrase);

            Stream encOut = encGen.Open(output, compressedData.Length);

            encOut.Write(compressedData, 0, compressedData.Length);
            encOut.Close();

            if (armor)
            {
                output.Close();
            }

            return bOut.ToArray();
        }

        private static byte[] Compress(byte[] clearData, string fileName, CompressionAlgorithmTag algorithm)
        {
            var bOut = new MemoryStream();

            var comData = new PgpCompressedDataGenerator(algorithm);
            Stream cos = comData.Open(bOut); // open it with the final destination
            var lData = new PgpLiteralDataGenerator();

            // we want to Generate compressed data. This might be a user option later,
            // in which case we would pass in bOut.
            Stream pOut = lData.Open(
                   cos, // the compressed output stream
                   PgpLiteralData.Binary,
                   fileName, // "filename" to store
                   clearData.Length, // length of clear data
                   DateTime.UtcNow // current time
                   );

            pOut.Write(clearData, 0, clearData.Length);
            pOut.Close();

            comData.Close();

            return bOut.ToArray();
        }
    }
}
