using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    // JWT'nin doğrulanması için hangi anahtarı kullanacaksın? Hangi algoritmayı kullanacaksın ? İşte bu metoda bunların cevabını vermiş oluyoruz.
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
