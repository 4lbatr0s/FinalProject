using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //creadential: username, password etc...
        //here our credential is our SecurityKey, remember the API-Business-Database-JWT relation illustration on the Joplin.
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //this here does a hashing, uses securityKey as the key value and HmacSha512 as the algorithm.
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
