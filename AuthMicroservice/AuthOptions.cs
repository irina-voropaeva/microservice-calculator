using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace AuthMicroservice
{
    public class AuthOptions
    {
        public const string ISSUER = "AuthMicroservice";
        public const string AUDIENCE = "AuthClient";
        const string KEY = "mykey, long enough to work with encryption!!!!123344!)(!";
        public const int LIFETIME = 5;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
