using BCrypt.Net;

namespace BlazorAppWithNils.Code
{
    public class ImplementedHashingHandler
    {
        public string BcryptHashing(string textToHash)
        {
           
            int workFactor = 11;
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            bool enhancedEntropy = true;
            HashType hashType = HashType.SHA256;
            return BCrypt.Net.BCrypt.HashPassword(textToHash, salt, enhancedEntropy, hashType);

            BCrypt.Net.BCrypt.HashPassword(textToHash, workFactor);

        }
    }
}
