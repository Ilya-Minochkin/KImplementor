using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KImplementor.Utils
{
    public class LoginResponse
    {
        public string AccessToken { get; }
        public string Email { get; }

        public LoginResponse(string accessToken, string email)
        {
            AccessToken = accessToken;
            Email = email;
        }
    }
}
