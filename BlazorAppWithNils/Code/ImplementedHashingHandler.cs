using BCrypt.Net;
using System.Security.Cryptography;
using System.Text;

namespace BlazorAppWithNils.Code
{
    public class ImplementedHashingHandler
    {
        //public string BcryptHashing(string textToHash)
        //{

        //    int workFactor = 11;
        //    string salt = BCrypt.Net.BCrypt.GenerateSalt();
        //    bool enhancedEntropy = true;
        //    HashType hashType = HashType.SHA256;
        //    return BCrypt.Net.BCrypt.HashPassword(textToHash, salt, enhancedEntropy, hashType);

        //    BCrypt.Net.BCrypt.HashPassword(textToHash, workFactor);

        //}
        public string SHA256Hashing(string textToHash)
        {
            byte[] inputByte = Encoding.ASCII.GetBytes(textToHash);
            SHA256 sHA256 = SHA256.Create();
            byte[] hashedValue = sHA256.ComputeHash(inputByte);
            return Convert.ToBase64String(hashedValue);
        }
    }
}
