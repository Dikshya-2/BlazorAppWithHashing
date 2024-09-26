using Newtonsoft.Json;
using System.Security.Cryptography;

namespace BlazorAppWithNils.Code
{
    public class AsymetriskEncryptionHandler
    {
        private string _privatekey;
        public string _publicKey;
        private readonly HttpClient _httpclient;

        public AsymetriskEncryptionHandler(HttpClient httpClient)
        {
            _httpclient = httpClient;

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                _privatekey = rsa.ToXmlString(true);
                _publicKey = rsa.ToXmlString(false);
            }
        }
        public async Task<string> AsymetriskEncryp(string textToEncrypt)
        {
            string[] param = new string[] { textToEncrypt, _publicKey };

            string serializedObject = JsonConvert.SerializeObject(param);
            StringContent sc = new StringContent(serializedObject, System.Text.Encoding.UTF8, "applicaton/json");
            var encryptedValue = await _httpclient.PostAsync("https://localhost:7293/api/Encryptor", sc);// min webapp url
            string encryptedValueString = encryptedValue.Content.ReadAsStringAsync().Result;
            return encryptedValueString;
        }

        public async Task<string> AsymetriskDecryp(string textToDecrypt)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(_privatekey);
                byte[] byteArrayTextDecrypt = Convert.FromBase64String(textToDecrypt);
                byte[] decrypValue = rsa.Decrypt(byteArrayTextDecrypt, true);
                string decrypValueString = System.Text.Encoding.UTF8.GetString(decrypValue);
                return decrypValueString;
            }
        }

    }
}
