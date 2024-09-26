using Microsoft.AspNetCore.DataProtection;

namespace BlazorAppWithNils.Code
{
    public class SymetriskEncrypttionHandler
    {
        private readonly IDataProtector _dataProtector;
        public SymetriskEncrypttionHandler(IDataProtectionProvider protector)
        {
            // this will create key 
            _dataProtector = protector.CreateProtector("NilsErMinFavoritLær");
        }
        public string Protect(string textToEncrypt) =>
            _dataProtector.Protect(textToEncrypt);

        public string UnProtect(string textToEncrypt) =>
           _dataProtector.Unprotect(textToEncrypt);
    }
}

