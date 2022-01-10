using BusinessLayer.Authentification;
using BusinessLayer.Models;
using BusinessLayer.Utils;
using DataLayer;
using DataLayer.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer.Services
{
    public class AuthService
    {
        private readonly DataManager _dataManager;
        private readonly UserService _userService;

        public AuthService(DataManager dataManager, UserService userService)
        {
            _dataManager = dataManager;
            _userService = userService;
        }

        public ClaimsIdentity GetIdentity(string email, string password)
        {
            var hasher = new Hasher();
            var hashedPassword = hasher.GetHashedStringSha3(password);
            try
            {
                UserModel userModel = _userService.GetUserModelByEmail(email);
                if (userModel.User.Password == hashedPassword)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, userModel.User.Email),
                    };
                    foreach (var role in userModel.User.Roles)
                    {
                        claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.ToString()));
                    }
                    ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                    return claimsIdentity;
                }

            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public string GetToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

    }
}
