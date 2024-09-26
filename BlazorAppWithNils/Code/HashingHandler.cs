using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.Intrinsics.Arm;
using BCrypt.Net;

namespace BlazorAppWithNils.Code
{
    public class HashingHandler
    {
        public string MD5Hashing(string textToHash)
        {
            byte[] inputByte = Encoding.ASCII.GetBytes(textToHash);
            MD5 mD5 = MD5.Create();
            byte[] hashedValue = mD5.ComputeHash(inputByte);
            return Convert.ToBase64String(hashedValue);
        }
        public string MD256Hashing(string textToHash)
        {
            byte[] inputByte = Encoding.ASCII.GetBytes(textToHash);
            SHA256 sHA256 = SHA256.Create();
            byte[] hashedValue = sHA256.ComputeHash(inputByte);
            return Convert.ToBase64String(hashedValue);
        }

        public string HMACHashing(string textToHash)
        {
            byte[] myKey = Encoding.ASCII.GetBytes("DenErMinKey");
            byte[] inputByte = Encoding.ASCII.GetBytes(textToHash);
            HMACSHA256 hMACSHA256 = new HMACSHA256();
            hMACSHA256.Key = myKey;
            byte[] hashedValue = hMACSHA256.ComputeHash(inputByte);
            return Convert.ToBase64String(hashedValue);

        }

        public string PBKDF2Hashing(string textToHash)
        {

            byte[] inputByte = Encoding.ASCII.GetBytes(textToHash);
            byte[] saltAsByteArray = Encoding.ASCII.GetBytes("mySalt");
            var hashAlgo = new System.Security.Cryptography.HashAlgorithmName("SHA256");
            byte[] hashedValue = System.Security.Cryptography.Rfc2898DeriveBytes.Pbkdf2(inputByte, saltAsByteArray, 11, hashAlgo, 32);
            return Convert.ToBase64String(hashedValue);
        }

        //public string BcryptHashing(string textToHash)
        //{
        //  return BCrypt.Net.BCrypt.HashPassword(textToHash);
        //}
        public string BcryptHashing(string textToHash)

        // =>

        //BCrypt.Net.BCrypt.HashPassword(textToHash);
        {
            /*
             *Specifically designed for password hashing, 
             *it incorporates salting and a configurable work factor (cost) 
             *to slow down the hashing process.
            Security: Very secure and resistant to brute force attacks.
            It automatically handles salt generation.
             */
            int workFactor = 11;
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            bool enhancedEntropy = true;
            HashType hashType = HashType.SHA256;
            return BCrypt.Net.BCrypt.HashPassword(textToHash, salt, enhancedEntropy, hashType);

            BCrypt.Net.BCrypt.HashPassword(textToHash, workFactor);

        }
        public bool BCryptVerifierHashing(string textToHash, string hashedValueFromDb)
        {
            // return BCrypt.Net.BCrypt.Verify(textToHash, hashedValueDormDb);
            return BCrypt.Net.BCrypt.Verify(textToHash, hashedValueFromDb, true, BCrypt.Net.HashType.SHA256);
        }
    }
}
