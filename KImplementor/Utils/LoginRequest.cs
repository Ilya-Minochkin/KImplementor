using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KImplementor.Utils
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public LoginRequest()
        {
        }
    }
}
