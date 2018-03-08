using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace sPeachVoice
{
    class Hash
    {
        public string sha256(string password)
        {
            SHA256 sha = SHA256Managed.Create();
            byte[] stringInBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashed = sha.ComputeHash(stringInBytes);
            return GetHashFromArray(hashed);
        }

        public string GetHashFromArray(byte[] hashed)
        {
            StringBuilder hashedString = new StringBuilder();
            for (int i = 0; i < hashed.Length; i++)
            {
                hashedString.Append(hashed[i].ToString("X2"));
            }
            return hashedString.ToString();
        }
    }
}
