using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Utils
{
    class Hasher
    {
        public string GetHashedStringSha3(string source)
        {
            var hashAlgorithm = new Sha3Digest(512);
            var sourceAsByteArray = Encoding.ASCII.GetBytes(source);

            hashAlgorithm.BlockUpdate(sourceAsByteArray, 0, sourceAsByteArray.Length);

            var result = new byte[64];
            hashAlgorithm.DoFinal(result, 0);

            string hashedSource = BitConverter.ToString(result);
            hashedSource = hashedSource.Replace("-", "").ToLowerInvariant();

            return hashedSource;
        }
    }
}
