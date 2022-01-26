using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //method's job: pass me a string, I'll give you the correspond SecurityKey value.
        public static SecurityKey CreateSecurityKey(string securityKey) //securityKey: comes from appsettings.json file SecurityKey value. (we pass it in JwtHelpers.cs file.)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); //there are two types of keys, symmetric and asymmetric keys, we'll be using the former one here.
        }
    }
}
