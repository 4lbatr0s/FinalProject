using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; } //This'll be our actual Token value that we'll be giving to User for it's credential value.
        public DateTime Expiration { get; set; } //token's expiration time
    }
}
